using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class tChuyenHangDonHangViewModel : BaseViewModel<tChuyenHangDonHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(tChuyenHangDonHangDto dto);
        partial void ProcessNewAddedDtoPartial(tChuyenHangDonHangDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaChuyenHangFilter;
        HeaderFilterBaseModel _MaDonHangFilter;
        HeaderFilterBaseModel _TongSoLuongTheoDonHangFilter;
        HeaderFilterBaseModel _TongSoLuongThucTeFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tChuyenHangDonHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.tChuyenHangDonHang_Ma, nameof(tChuyenHangDonHangDto.Ma), typeof(int));
            _MaChuyenHangFilter = new HeaderForeignKeyFilterModel(TextManager.tChuyenHangDonHang_MaChuyenHang, nameof(tChuyenHangDonHangDto.MaChuyenHang), typeof(int), new View.tChuyenHangView() { KeepSelectionType = DataGridExt.KeepSelection.KeepSelectedValue });
            _MaDonHangFilter = new HeaderForeignKeyFilterModel(TextManager.tChuyenHangDonHang_MaDonHang, nameof(tChuyenHangDonHangDto.MaDonHang), typeof(int), new View.tDonHangView() { KeepSelectionType = DataGridExt.KeepSelection.KeepSelectedValue });
            _TongSoLuongTheoDonHangFilter = new HeaderTextFilterModel(TextManager.tChuyenHangDonHang_TongSoLuongTheoDonHang, nameof(tChuyenHangDonHangDto.TongSoLuongTheoDonHang), typeof(int));
            _TongSoLuongThucTeFilter = new HeaderTextFilterModel(TextManager.tChuyenHangDonHang_TongSoLuongThucTe, nameof(tChuyenHangDonHangDto.TongSoLuongThucTe), typeof(int));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tChuyenHangDonHang_TenantID, nameof(tChuyenHangDonHangDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tChuyenHangDonHang_CreateTime, nameof(tChuyenHangDonHangDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tChuyenHangDonHang_LastUpdateTime, nameof(tChuyenHangDonHangDto.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaChuyenHangFilter);
            AddHeaderFilter(_MaDonHangFilter);
            AddHeaderFilter(_TongSoLuongTheoDonHangFilter);
            AddHeaderFilter(_TongSoLuongThucTeFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(tChuyenHangDonHangDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(tChuyenHangDonHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaChuyenHangFilter.FilterValue != null)
            {
                dto.MaChuyenHang = (int)_MaChuyenHangFilter.FilterValue;
            }
            if (_MaDonHangFilter.FilterValue != null)
            {
                dto.MaDonHang = (int)_MaDonHangFilter.FilterValue;
            }
            if (_TongSoLuongTheoDonHangFilter.FilterValue != null)
            {
                dto.TongSoLuongTheoDonHang = (int)_TongSoLuongTheoDonHangFilter.FilterValue;
            }
            if (_TongSoLuongThucTeFilter.FilterValue != null)
            {
                dto.TongSoLuongThucTe = (int)_TongSoLuongThucTeFilter.FilterValue;
            }
            if (_TenantIDFilter.FilterValue != null)
            {
                dto.TenantID = (int)_TenantIDFilter.FilterValue;
            }
            if (_CreateTimeFilter.FilterValue != null)
            {
                dto.CreateTime = (long)_CreateTimeFilter.FilterValue;
            }
            if (_LastUpdateTimeFilter.FilterValue != null)
            {
                dto.LastUpdateTime = (long)_LastUpdateTimeFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
