using Client.DataModel;
using huypq.QueryBuilder;
using Shared;
using SimpleDataGrid.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Client.ViewModel
{
    public partial class tTonKhoViewModel
    {
        partial void InitFilterPartial()
        {
            _NgayFilter.IsSorted = HeaderFilterBaseModel.SortDirection.Descending;
        }

        public void CopyTonKhoToClipboard(bool? isHangNhaLam)
        {
            if (_NgayFilter.IsUsed == false || _MaKhoHangFilter.IsUsed == false)
            {
                return;
            }

            var qe = new QueryExpression();
            if (isHangNhaLam.HasValue)
            {
                qe.AddWhereOption<WhereExpression.WhereOptionBool, bool>(
                    WhereExpression.Equal,
                    string.Format("{0}Navigation.{1}", nameof(tMatHangDto.MaLoai), nameof(rLoaiHangDto.HangNhaLam))
                    , isHangNhaLam.Value);
            }
            var matHangs = DataService.GetAll<tMatHangDto, tMatHangDataModel>(qe.WhereOptions).Items;

            qe = new QueryExpression();

            qe.AddWhereOption<WhereExpression.WhereOptionInt, int>(
              WhereExpression.Equal, nameof(tTonKhoDto.MaKhoHang), (int)_MaKhoHangFilter.FilterValue);
            qe.AddWhereOption<WhereExpression.WhereOptionDate, System.DateTime>(
            WhereExpression.Equal, nameof(tTonKhoDto.Ngay), (System.DateTime)_NgayFilter.FilterValue);
            qe.AddWhereOption<WhereExpression.WhereOptionIntList, List<int>>(
                WhereExpression.In, nameof(tTonKhoDto.MaMatHang), matHangs.Select(p => p.ID).ToList());

            var tTonKhoes = DataService.GetAll<tTonKhoDto, tTonKhoDataModel>(qe.WhereOptions).Items;

            var builder = new StringBuilder();

            var matHangsDictionary = matHangs.ToDictionary(p => p.ID, p => p);

            var sortedList = new SortedList<string, string>();

            var tongSoCoun = 0;
            var tongSoKg = 0;
            for (int i = 0; i < tTonKhoes.Count; i++)
            {
                var mh = matHangsDictionary[tTonKhoes[i].MaMatHang];
                var tenMH = mh.TenMatHangDayDu;
                var soKg = (tTonKhoes[i].SoLuong * mh.SoKy) / 10;
                var soCoun = tTonKhoes[i].SoLuong;
                var row = string.Format("{0}\t{1}\t{2}", tenMH, soCoun, soKg);
                tongSoCoun += soCoun;
                tongSoKg += soKg;
                sortedList.Add(tenMH, row);
            }

            foreach (var item in sortedList)
            {
                builder.AppendLine(item.Value);
            }

            builder.Insert(0, string.Format("{0:dd/MM/yyyy}\t{1:N0} cuộn\t{2:N0} kg{3}"
                , (System.DateTime)_NgayFilter.FilterValue, tongSoCoun, tongSoKg, System.Environment.NewLine));
            Clipboard.SetText(builder.ToString());
        }
    }
}
