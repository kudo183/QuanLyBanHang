using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class rBaiXeViewModel : BaseViewModel<rBaiXeDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(rBaiXeDto dto);
        partial void ProcessNewAddedDtoPartial(rBaiXeDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _DiaDiemBaiXeFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rBaiXeViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.rBaiXe_Ma, nameof(rBaiXeDto.Ma), typeof(int));
            _DiaDiemBaiXeFilter = new HeaderTextFilterModel(TextManager.rBaiXe_DiaDiemBaiXe, nameof(rBaiXeDto.DiaDiemBaiXe), typeof(string));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rBaiXe_TenantID, nameof(rBaiXeDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rBaiXe_CreateTime, nameof(rBaiXeDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rBaiXe_LastUpdateTime, nameof(rBaiXeDto.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_DiaDiemBaiXeFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(rBaiXeDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(rBaiXeDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_DiaDiemBaiXeFilter.FilterValue != null)
            {
                dto.DiaDiemBaiXe = (string)_DiaDiemBaiXeFilter.FilterValue;
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
