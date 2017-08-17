using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class rNuocViewModel : BaseViewModel<rNuocDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(rNuocDto dto);
        partial void ProcessNewAddedDtoPartial(rNuocDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _TenNuocFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rNuocViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.rNuoc_Ma, nameof(rNuocDto.Ma), typeof(int));
            _TenNuocFilter = new HeaderTextFilterModel(TextManager.rNuoc_TenNuoc, nameof(rNuocDto.TenNuoc), typeof(string));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rNuoc_TenantID, nameof(rNuocDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rNuoc_CreateTime, nameof(rNuocDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rNuoc_LastUpdateTime, nameof(rNuocDto.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_TenNuocFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(rNuocDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(rNuocDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_TenNuocFilter.FilterValue != null)
            {
                dto.TenNuoc = (string)_TenNuocFilter.FilterValue;
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
