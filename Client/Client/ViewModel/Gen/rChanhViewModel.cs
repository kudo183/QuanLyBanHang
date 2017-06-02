using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class rChanhViewModel : BaseViewModel<rChanhDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(rChanhDto dto);
        partial void ProcessNewAddedDtoPartial(rChanhDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaBaiXeFilter;
        HeaderFilterBaseModel _TenChanhFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rChanhViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.rChanh_Ma, nameof(rChanhDto.Ma), typeof(int));
            _MaBaiXeFilter = new HeaderComboBoxFilterModel(
                TextManager.rChanh_MaBaiXe, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(rChanhDto.MaBaiXe),
                typeof(int),
                nameof(rBaiXeDto.DisplayText),
                nameof(rBaiXeDto.ID))
            {
                AddCommand = new SimpleCommand("MaBaiXeAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rBaiXeView(), "rBaiXe", ReferenceDataManager<rBaiXeDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rBaiXeDto>.Instance.Get()
            };
            _TenChanhFilter = new HeaderTextFilterModel(TextManager.rChanh_TenChanh, nameof(rChanhDto.TenChanh), typeof(string));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rChanh_TenantID, nameof(rChanhDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rChanh_CreateTime, nameof(rChanhDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rChanh_LastUpdateTime, nameof(rChanhDto.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaBaiXeFilter);
            AddHeaderFilter(_TenChanhFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<rBaiXeDto>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(rChanhDto dto)
        {
            dto.MaBaiXeDataSource = ReferenceDataManager<rBaiXeDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(rChanhDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaBaiXeFilter.FilterValue != null)
            {
                dto.MaBaiXe = (int)_MaBaiXeFilter.FilterValue;
            }
            if (_TenChanhFilter.FilterValue != null)
            {
                dto.TenChanh = (string)_TenChanhFilter.FilterValue;
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
