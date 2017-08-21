using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class rKhoHangViewModel : BaseViewModel<rKhoHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(rKhoHangDto dto);
        partial void ProcessNewAddedDtoPartial(rKhoHangDto dto);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _TenKhoFilter;
        HeaderFilterBaseModel _TrangThaiFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rKhoHangViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.rKhoHang_ID, nameof(rKhoHangDto.ID), typeof(int));
            _TenKhoFilter = new HeaderTextFilterModel(TextManager.rKhoHang_TenKho, nameof(rKhoHangDto.TenKho), typeof(string));
            _TrangThaiFilter = new HeaderCheckFilterModel(TextManager.rKhoHang_TrangThai, nameof(rKhoHangDto.TrangThai), typeof(bool));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rKhoHang_TenantID, nameof(rKhoHangDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rKhoHang_CreateTime, nameof(rKhoHangDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rKhoHang_LastUpdateTime, nameof(rKhoHangDto.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_TenKhoFilter);
            AddHeaderFilter(_TrangThaiFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(rKhoHangDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(rKhoHangDto dto)
        {
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
            }
            if (_TenKhoFilter.FilterValue != null)
            {
                dto.TenKho = (string)_TenKhoFilter.FilterValue;
            }
            if (_TrangThaiFilter.FilterValue != null)
            {
                dto.TrangThai = (bool)_TrangThaiFilter.FilterValue;
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
