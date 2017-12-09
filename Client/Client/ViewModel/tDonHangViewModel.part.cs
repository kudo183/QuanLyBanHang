using Client.DataModel;
using CustomControl;
using huypq.QueryBuilder;
using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.wpf.Utils;
using Shared;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Client.ViewModel
{
    public partial class tDonHangViewModel : BaseViewModel<tDonHangDto, tDonHangDataModel>
    {
        private string MsgSelectedItemIsNull = "please select tDonHang";
        private string MsgtChiTietDonHangsIsEmtpy = "tChiTietDonHangs Is Emtpy";

        partial void InitFilterPartial()
        {
            TonKhoCommand = new SimpleCommand(nameof(TonKhoCommand), () => TonKhoAction());
            PrintAllCommand = new SimpleCommand(nameof(PrintAllCommand), () => PrintAll());
            PrintRemainCommand = new SimpleCommand(nameof(PrintRemainCommand), () => PrintRemain());

            _MaChanhFilter = new HeaderComboBoxFilterModel(
                TextManager.tDonHang_MaChanh, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tDonHangDataModel.MaChanh),
                typeof(int?),
                nameof(rChanhDataModel.DisplayText),
                nameof(rChanhDataModel.ID))
            {
                AddCommand = new SimpleCommand("ChanhAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rKhachHangChanhView(), "Khach Hang Chanh", AfterKhachHangChanhDialog)),
                ItemSource = ReferenceDataManager<rChanhDto, rChanhDataModel>.Instance.Get()
            };

            _NgayFilter.IsSorted = HeaderFilterBaseModel.SortDirection.Descending;
        }

        protected override void BeforeLoad()
        {
            foreach (var dto in Entities)
            {
                dto.PropertyChanged -= Dto_PropertyChanged;
            }
        }

        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<rKhachHangChanhDto, rKhachHangChanhDataModel>.Instance.LoadOrUpdate();
            ReferenceDataManager<rBaiXeDto, rBaiXeDataModel>.Instance.LoadOrUpdate();
        }

        partial void ProcessDataModelBeforeAddToEntitiesPartial(tDonHangDataModel dto)
        {
            UpdateChanhs(dto);

            dto.PropertyChanged += Dto_PropertyChanged;
        }

        void AfterKhachHangChanhDialog()
        {
            ReferenceDataManager<rChanhDto, rChanhDataModel>.Instance.LoadOrUpdate();
            ReferenceDataManager<rKhachHangChanhDto, rKhachHangChanhDataModel>.Instance.LoadOrUpdate();
            foreach (var dto in Entities)
            {
                UpdateChanhs(dto);
            }
        }

        void UpdateChanhs(tDonHangDataModel dto)
        {
            var khachHangChanhs = ReferenceDataManager<rKhachHangChanhDto, rKhachHangChanhDataModel>.Instance.Get()
                 .Where(p => p.MaKhachHang == dto.MaKhachHang);

            var chanhs = new List<rChanhDataModel>();
            foreach (var item in khachHangChanhs)
            {
                var chanh = ReferenceDataManager<rChanhDto, rChanhDataModel>.Instance.GetByID(item.MaChanh);
                if (chanh.MaBaiXeNavigation == null)
                {
                    chanh.MaBaiXeNavigation = ReferenceDataManager<rBaiXeDto, rBaiXeDataModel>.Instance.GetByID(chanh.MaBaiXe);
                }
                if (item.LaMacDinh == true)
                {
                    chanhs.Insert(0, chanh);
                }
                else
                {
                    chanhs.Add(chanh);
                }
            }

            dto.MaChanhDataSource = chanhs;

            if (chanhs.Count > 0)
            {
                if (dto.MaChanh == null || chanhs.Any(p => p.ID == dto.MaChanh) == false)
                {
                    dto.MaChanh = chanhs[0].ID;
                }
            }
        }

        void Dto_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var dto = sender as tDonHangDataModel;
            switch (e.PropertyName)
            {
                case nameof(tDonHangDataModel.MaKhachHang):
                    UpdateChanhs(dto);
                    break;
            }
        }

        public SimpleCommand TonKhoCommand { get; set; }
        public SimpleCommand PrintAllCommand { get; set; }
        public SimpleCommand PrintRemainCommand { get; set; }

        private void TonKhoAction()
        {
            var data = new List<MessageBox2.MessageBox2Data>();

            if (SelectedItem == null)
            {
                SysMsg = MsgSelectedItemIsNull;
                return;
            }

            var donHang = SelectedItem;
            var qe = new QueryExpression();
            qe.AddWhereOption<WhereExpression.WhereOptionInt, int>(
                WhereExpression.Equal, nameof(tChiTietDonHangDataModel.MaDonHang), donHang.ID);

            var tChiTietDonHangs = DataService.Get<tChiTietDonHangDto, tChiTietDonHangDataModel>(qe).Items;
            if (tChiTietDonHangs.Count == 0)
            {
                SysMsg = MsgtChiTietDonHangsIsEmtpy;
                return;
            }

            var maMatHangs = tChiTietDonHangs.Select(p => p.MaMatHang).ToList();

            qe = new QueryExpression();
            qe.AddWhereOption<WhereExpression.WhereOptionInt, int>(
                WhereExpression.Equal, nameof(tTonKhoDataModel.MaKhoHang), donHang.MaKhoHang);
            qe.AddWhereOption<WhereExpression.WhereOptionDate, System.DateTime>(
                WhereExpression.Equal, nameof(tTonKhoDataModel.Ngay), System.DateTime.Now.Date);
            qe.AddWhereOption<WhereExpression.WhereOptionIntList, List<int>>(
                WhereExpression.In, nameof(tTonKhoDataModel.MaMatHang), maMatHangs);

            var tTonKhoes = DataService.Get<tTonKhoDto, tTonKhoDataModel>(qe).Items;

            foreach (var tTonKho in tTonKhoes)
            {
                data.Add(new MessageBox2.MessageBox2Data
                {
                    Title = ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.GetByID(tTonKho.MaMatHang).TenMatHangDayDu,
                    Content = tTonKho.SoLuong.ToString("N0")
                });
            }

            MessageBox2.Show("Ton Kho", data);
        }

        private void PrintAll()
        {
            if (SelectedItem == null)
            {
                SysMsg = MsgSelectedItemIsNull;
                return;
            }

            var donHang = SelectedItem as tDonHangDataModel;
            var qe = new QueryExpression();
            qe.AddWhereOption<WhereExpression.WhereOptionInt, int>(
                WhereExpression.Equal, nameof(tChiTietDonHangDataModel.MaDonHang), donHang.ID);
            var tChiTietDonHangs = DataService.Get<tChiTietDonHangDto, tChiTietDonHangDataModel>(qe).Items;

            if (tChiTietDonHangs.Count == 0)
            {
                SysMsg = MsgtChiTietDonHangsIsEmtpy;
                return;
            }

            var content = new List<string>();

            foreach (var ctdh in tChiTietDonHangs)
            {
                ctdh.MaMatHangNavigation = ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.GetByID(ctdh.MaMatHang);
                content.Add(string.Format("{0,3}  {1}", ctdh.SoLuong, ctdh.MaMatHangNavigation.TenMatHangIn));
            }

            var tenKhachHang = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.GetByID(donHang.MaKhachHang).TenKhachHang;

            Utils.PrintUtils.Print(tenKhachHang, content);
        }

        private void PrintRemain()
        {
            if (SelectedItem == null)
            {
                SysMsg = MsgSelectedItemIsNull;
                return;
            }

            var donHang = SelectedItem as tDonHangDataModel;

            var qe = new QueryExpression();
            qe.AddWhereOption<WhereExpression.WhereOptionInt, int>(
                WhereExpression.Equal, nameof(tChiTietDonHangDataModel.MaDonHang), donHang.ID);
            qe.AddWhereOption<WhereExpression.WhereOptionBool, bool>(
                WhereExpression.Equal, nameof(tChiTietDonHangDataModel.Xong), false);
            var tChiTietDonHangs = DataService.Get<tChiTietDonHangDto, tChiTietDonHangDataModel>(qe).Items;

            if (tChiTietDonHangs.Count == 0)
            {
                SysMsg = MsgtChiTietDonHangsIsEmtpy;
                return;
            }

            var content = new List<string>();

            var qe1 = new QueryExpression();
            qe1.AddWhereOption<WhereExpression.WhereOptionInt, int>(
                WhereExpression.Equal, string.Format("{0}.{1}", nameof(tChiTietChuyenHangDonHangDataModel.MaChiTietDonHangNavigation), nameof(tChiTietDonHangDataModel.MaDonHang)), donHang.ID);
            var tChiTietChuyenHangDonHangs = DataService.Get<tChiTietChuyenHangDonHangDto, tChiTietChuyenHangDonHangDataModel>(qe1).Items;

            foreach (var ctdh in tChiTietDonHangs)
            {
                var soLuong = tChiTietChuyenHangDonHangs.Where(p => p.MaChiTietDonHang == ctdh.ID).Sum(p => p.SoLuong);
                ctdh.MaMatHangNavigation = ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.GetByID(ctdh.MaMatHang);
                content.Add(string.Format("{0,3}  {1}", ctdh.SoLuong - soLuong, ctdh.MaMatHangNavigation.TenMatHangIn));
            }

            var tenKhachHang = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.GetByID(donHang.MaKhachHang).TenKhachHang;

            Utils.PrintUtils.Print(tenKhachHang, content);
        }
    }
}
