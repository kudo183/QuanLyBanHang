using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class rNhaCungCapViewModel : BaseViewModel<rNhaCungCapDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(rNhaCungCapDto dto);
        partial void ProcessNewAddedDtoPartial(rNhaCungCapDto dto);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _TenNhaCungCapFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rNhaCungCapViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.rNhaCungCap_ID, nameof(rNhaCungCapDto.ID), typeof(int));
            _TenNhaCungCapFilter = new HeaderTextFilterModel(TextManager.rNhaCungCap_TenNhaCungCap, nameof(rNhaCungCapDto.TenNhaCungCap), typeof(string));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rNhaCungCap_TenantID, nameof(rNhaCungCapDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rNhaCungCap_CreateTime, nameof(rNhaCungCapDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rNhaCungCap_LastUpdateTime, nameof(rNhaCungCapDto.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_TenNhaCungCapFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(rNhaCungCapDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(rNhaCungCapDto dto)
        {
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
            }
            if (_TenNhaCungCapFilter.FilterValue != null)
            {
                dto.TenNhaCungCap = (string)_TenNhaCungCapFilter.FilterValue;
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
