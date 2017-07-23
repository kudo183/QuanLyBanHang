using CustomControl;
using huypq.QueryBuilder;
using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using SimpleDataGrid;
using System.Collections.Generic;
using System.Linq;

namespace Client.ViewModel
{
    public partial class tDonHangViewModel : BaseViewModel<tDonHangDto>
    {
        partial void InitFilterPartial()
        {
            TonKhoCommand = new SimpleCommand(nameof(TonKhoCommand), () => TonKhoAction());
            PrintAllCommand = new SimpleCommand(nameof(PrintAllCommand), () => PrintAll());
            PrintRemainCommand = new SimpleCommand(nameof(PrintRemainCommand), () => PrintRemain());
        }

        public SimpleCommand TonKhoCommand { get; set; }
        public SimpleCommand PrintAllCommand { get; set; }
        public SimpleCommand PrintRemainCommand { get; set; }

        private void TonKhoAction()
        {
            if (SelectedItem == null)
                return;

            var donHang = SelectedItem;
            var qe = new QueryExpression();
            qe.AddWhereOption<WhereExpression.WhereOptionInt, int>(
                WhereExpression.Equal, nameof(tChiTietDonHangDto.MaDonHang), donHang.ID);

            var tChiTietDonHangs = DataService.Get<tChiTietDonHangDto>(qe).Items;

            var maMatHangs = tChiTietDonHangs.Select(p => p.MaMatHang).ToList();

            qe = new QueryExpression();
            qe.AddWhereOption<WhereExpression.WhereOptionInt, int>(
                WhereExpression.Equal, nameof(tTonKhoDto.MaKhoHang), donHang.MaKhoHang);
            qe.AddWhereOption<WhereExpression.WhereOptionDate, System.DateTime>(
                WhereExpression.Equal, nameof(tTonKhoDto.Ngay), System.DateTime.Now.Date);
            qe.AddWhereOption<WhereExpression.WhereOptionIntList, List<int>>(
                WhereExpression.In, nameof(tTonKhoDto.MaMatHang), maMatHangs);

            var tTonKhoes = DataService.Get<tTonKhoDto>(qe).Items;

            var data = new List<MessageBox2.MessageBox2Data>();

            foreach (var tTonKho in tTonKhoes)
            {
                data.Add(new MessageBox2.MessageBox2Data
                {
                    Title = ReferenceDataManager<tMatHangDto>.Instance.GetByID(tTonKho.MaMatHang).TenMatHangDayDu,
                    Content = tTonKho.SoLuong.ToString("N0")
                });
            }

            MessageBox2.Show("Ton Kho", data);
        }

        private void PrintAll()
        {
            if (SelectedItem == null)
                return;

            var donHang = SelectedItem as tDonHangDto;
            var qe = new QueryExpression();
            qe.AddWhereOption<WhereExpression.WhereOptionInt, int>(
                WhereExpression.Equal, nameof(tChiTietDonHangDto.MaDonHang), donHang.ID);
            var tChiTietDonHangs = DataService.Get<tChiTietDonHangDto>(qe).Items;

            if (tChiTietDonHangs.Count == 0)
                return;

            var content = new List<string>();

            foreach (var ctdh in tChiTietDonHangs)
            {
                ctdh.MaMatHangNavigation = ReferenceDataManager<tMatHangDto>.Instance.GetByID(ctdh.MaMatHang);
                content.Add(string.Format("{0,3}  {1}", ctdh.SoLuong, ctdh.MaMatHangNavigation.TenMatHangIn));
            }

            var tenKhachHang = ReferenceDataManager<rKhachHangDto>.Instance.GetByID(donHang.MaKhachHang).TenKhachHang;

            Utils.PrintUtils.Print(tenKhachHang, content);
        }

        private void PrintRemain()
        {
            if (SelectedItem == null)
                return;

            var donHang = SelectedItem as tDonHangDto;

            var qe = new QueryExpression();
            qe.AddWhereOption<WhereExpression.WhereOptionInt, int>(
                WhereExpression.Equal, nameof(tChiTietDonHangDto.MaDonHang), donHang.ID);
            qe.AddWhereOption<WhereExpression.WhereOptionBool, bool>(
                WhereExpression.Equal, nameof(tChiTietDonHangDto.Xong), false);
            var tChiTietDonHangs = DataService.Get<tChiTietDonHangDto>(qe).Items;

            if (tChiTietDonHangs.Count == 0)
                return;

            var content = new List<string>();

            var qe1 = new QueryExpression();
            qe1.AddWhereOption<WhereExpression.WhereOptionInt, int>(
                WhereExpression.Equal, string.Format("{0}.{1}", nameof(tChiTietChuyenHangDonHangDto.MaChiTietDonHangNavigation), nameof(tChiTietDonHangDto.MaDonHang)), donHang.ID);
            var tChiTietChuyenHangDonHangs = DataService.Get<tChiTietChuyenHangDonHangDto>(qe1).Items;

            foreach (var ctdh in tChiTietDonHangs)
            {
                var soLuong = tChiTietChuyenHangDonHangs.Where(p => p.MaChiTietDonHang == ctdh.ID).Sum(p => p.SoLuong);
                ctdh.MaMatHangNavigation = ReferenceDataManager<tMatHangDto>.Instance.GetByID(ctdh.MaMatHang);
                content.Add(string.Format("{0,3}  {1}", ctdh.SoLuong - soLuong, ctdh.MaMatHangNavigation.TenMatHangIn));
            }

            var tenKhachHang = ReferenceDataManager<rKhachHangDto>.Instance.GetByID(donHang.MaKhachHang).TenKhachHang;

            Utils.PrintUtils.Print(tenKhachHang, content);
        }
    }
}
