using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class tChiTietToaHangViewModel : BaseViewModel<tChiTietToaHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(tChiTietToaHangDto dto);
        partial void ProcessNewAddedDtoPartial(tChiTietToaHangDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaToaHangFilter;
        HeaderFilterBaseModel _MaChiTietDonHangFilter;
        HeaderFilterBaseModel _GiaTienFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tChiTietToaHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.tChiTietToaHang_Ma, nameof(tChiTietToaHangDto.Ma), typeof(int));
            _MaToaHangFilter = new HeaderForeignKeyFilterModel(TextManager.tChiTietToaHang_MaToaHang, nameof(tChiTietToaHangDto.MaToaHang), typeof(int), new View.tToaHangView() { KeepSelectionType = DataGridExt.KeepSelection.KeepSelectedValue });
            _MaChiTietDonHangFilter = new HeaderForeignKeyFilterModel(TextManager.tChiTietToaHang_MaChiTietDonHang, nameof(tChiTietToaHangDto.MaChiTietDonHang), typeof(int), new View.tChiTietDonHangView() { KeepSelectionType = DataGridExt.KeepSelection.KeepSelectedValue });
            _GiaTienFilter = new HeaderTextFilterModel(TextManager.tChiTietToaHang_GiaTien, nameof(tChiTietToaHangDto.GiaTien), typeof(int));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tChiTietToaHang_TenantID, nameof(tChiTietToaHangDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tChiTietToaHang_CreateTime, nameof(tChiTietToaHangDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tChiTietToaHang_LastUpdateTime, nameof(tChiTietToaHangDto.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaToaHangFilter);
            AddHeaderFilter(_MaChiTietDonHangFilter);
            AddHeaderFilter(_GiaTienFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(tChiTietToaHangDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(tChiTietToaHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaToaHangFilter.FilterValue != null)
            {
                dto.MaToaHang = (int)_MaToaHangFilter.FilterValue;
            }
            if (_MaChiTietDonHangFilter.FilterValue != null)
            {
                dto.MaChiTietDonHang = (int)_MaChiTietDonHangFilter.FilterValue;
            }
            if (_GiaTienFilter.FilterValue != null)
            {
                dto.GiaTien = (int)_GiaTienFilter.FilterValue;
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
