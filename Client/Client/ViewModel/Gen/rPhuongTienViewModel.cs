using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class rPhuongTienViewModel : BaseViewModel<rPhuongTienDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(rPhuongTienDto dto);
        partial void ProcessNewAddedDtoPartial(rPhuongTienDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _TenPhuongTienFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rPhuongTienViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.rPhuongTien_Ma, nameof(rPhuongTienDto.Ma), typeof(int));
            _TenPhuongTienFilter = new HeaderTextFilterModel(TextManager.rPhuongTien_TenPhuongTien, nameof(rPhuongTienDto.TenPhuongTien), typeof(string));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rPhuongTien_TenantID, nameof(rPhuongTienDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rPhuongTien_CreateTime, nameof(rPhuongTienDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rPhuongTien_LastUpdateTime, nameof(rPhuongTienDto.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_TenPhuongTienFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(rPhuongTienDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(rPhuongTienDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_TenPhuongTienFilter.FilterValue != null)
            {
                dto.TenPhuongTien = (string)_TenPhuongTienFilter.FilterValue;
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
