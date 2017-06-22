using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class tChiTietChuyenHangDonHangViewModel : BaseViewModel<tChiTietChuyenHangDonHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(tChiTietChuyenHangDonHangDto dto);
        partial void ProcessNewAddedDtoPartial(tChiTietChuyenHangDonHangDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaChuyenHangDonHangFilter;
        HeaderFilterBaseModel _MaChiTietDonHangFilter;
        HeaderFilterBaseModel _SoLuongFilter;
        HeaderFilterBaseModel _SoLuongTheoDonHangFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tChiTietChuyenHangDonHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenHangDonHang_Ma, nameof(tChiTietChuyenHangDonHangDto.Ma), typeof(int));
            _MaChuyenHangDonHangFilter = new HeaderForeignKeyFilterModel(TextManager.tChiTietChuyenHangDonHang_MaChuyenHangDonHang, nameof(tChiTietChuyenHangDonHangDto.MaChuyenHangDonHang), typeof(int), new View.tChuyenHangDonHangView() { KeepSelectionType = DataGridExt.KeepSelection.KeepSelectedValue });
            _MaChiTietDonHangFilter = new HeaderForeignKeyFilterModel(TextManager.tChiTietChuyenHangDonHang_MaChiTietDonHang, nameof(tChiTietChuyenHangDonHangDto.MaChiTietDonHang), typeof(int), new View.tChiTietDonHangView() { KeepSelectionType = DataGridExt.KeepSelection.KeepSelectedValue });
            _SoLuongFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenHangDonHang_SoLuong, nameof(tChiTietChuyenHangDonHangDto.SoLuong), typeof(int));
            _SoLuongTheoDonHangFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenHangDonHang_SoLuongTheoDonHang, nameof(tChiTietChuyenHangDonHangDto.SoLuongTheoDonHang), typeof(int));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenHangDonHang_TenantID, nameof(tChiTietChuyenHangDonHangDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenHangDonHang_CreateTime, nameof(tChiTietChuyenHangDonHangDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenHangDonHang_LastUpdateTime, nameof(tChiTietChuyenHangDonHangDto.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaChuyenHangDonHangFilter);
            AddHeaderFilter(_MaChiTietDonHangFilter);
            AddHeaderFilter(_SoLuongFilter);
            AddHeaderFilter(_SoLuongTheoDonHangFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(tChiTietChuyenHangDonHangDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(tChiTietChuyenHangDonHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaChuyenHangDonHangFilter.FilterValue != null)
            {
                dto.MaChuyenHangDonHang = (int)_MaChuyenHangDonHangFilter.FilterValue;
            }
            if (_MaChiTietDonHangFilter.FilterValue != null)
            {
                dto.MaChiTietDonHang = (int)_MaChiTietDonHangFilter.FilterValue;
            }
            if (_SoLuongFilter.FilterValue != null)
            {
                dto.SoLuong = (int)_SoLuongFilter.FilterValue;
            }
            if (_SoLuongTheoDonHangFilter.FilterValue != null)
            {
                dto.SoLuongTheoDonHang = (int)_SoLuongTheoDonHangFilter.FilterValue;
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
