using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class rLoaiChiPhiViewModel : BaseViewModel<rLoaiChiPhiDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(rLoaiChiPhiDto dto);
        partial void ProcessNewAddedDtoPartial(rLoaiChiPhiDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _TenLoaiChiPhiFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rLoaiChiPhiViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.rLoaiChiPhi_Ma, nameof(rLoaiChiPhiDto.Ma), typeof(int));
            _TenLoaiChiPhiFilter = new HeaderTextFilterModel(TextManager.rLoaiChiPhi_TenLoaiChiPhi, nameof(rLoaiChiPhiDto.TenLoaiChiPhi), typeof(string));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rLoaiChiPhi_TenantID, nameof(rLoaiChiPhiDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rLoaiChiPhi_CreateTime, nameof(rLoaiChiPhiDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rLoaiChiPhi_LastUpdateTime, nameof(rLoaiChiPhiDto.LastUpdateTime), typeof(long));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_TenLoaiChiPhiFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(rLoaiChiPhiDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(rLoaiChiPhiDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_TenLoaiChiPhiFilter.FilterValue != null)
            {
                dto.TenLoaiChiPhi = (string)_TenLoaiChiPhiFilter.FilterValue;
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
