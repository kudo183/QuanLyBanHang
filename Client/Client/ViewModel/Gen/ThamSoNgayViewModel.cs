using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class ThamSoNgayViewModel : BaseViewModel<ThamSoNgayDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(ThamSoNgayDto dto);
        partial void ProcessNewAddedDtoPartial(ThamSoNgayDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _TenFilter;
        HeaderFilterBaseModel _GiaTriFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public ThamSoNgayViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.ThamSoNgay_Ma, nameof(ThamSoNgayDto.Ma), typeof(int));
            _TenFilter = new HeaderTextFilterModel(TextManager.ThamSoNgay_Ten, nameof(ThamSoNgayDto.Ten), typeof(string));
            _GiaTriFilter = new HeaderDateFilterModel(TextManager.ThamSoNgay_GiaTri, nameof(ThamSoNgayDto.GiaTri), typeof(System.DateTime));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.ThamSoNgay_TenantID, nameof(ThamSoNgayDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.ThamSoNgay_CreateTime, nameof(ThamSoNgayDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.ThamSoNgay_LastUpdateTime, nameof(ThamSoNgayDto.LastUpdateTime), typeof(long));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_TenFilter);
            AddHeaderFilter(_GiaTriFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(ThamSoNgayDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(ThamSoNgayDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_TenFilter.FilterValue != null)
            {
                dto.Ten = (string)_TenFilter.FilterValue;
            }
            if (_GiaTriFilter.FilterValue != null)
            {
                dto.GiaTri = (System.DateTime)_GiaTriFilter.FilterValue;
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
