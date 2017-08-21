using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class rLoaiHangViewModel : BaseViewModel<rLoaiHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(rLoaiHangDto dto);
        partial void ProcessNewAddedDtoPartial(rLoaiHangDto dto);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _TenLoaiFilter;
        HeaderFilterBaseModel _HangNhaLamFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rLoaiHangViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.rLoaiHang_ID, nameof(rLoaiHangDto.ID), typeof(int));
            _TenLoaiFilter = new HeaderTextFilterModel(TextManager.rLoaiHang_TenLoai, nameof(rLoaiHangDto.TenLoai), typeof(string));
            _HangNhaLamFilter = new HeaderCheckFilterModel(TextManager.rLoaiHang_HangNhaLam, nameof(rLoaiHangDto.HangNhaLam), typeof(bool));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rLoaiHang_TenantID, nameof(rLoaiHangDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rLoaiHang_CreateTime, nameof(rLoaiHangDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rLoaiHang_LastUpdateTime, nameof(rLoaiHangDto.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_TenLoaiFilter);
            AddHeaderFilter(_HangNhaLamFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(rLoaiHangDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(rLoaiHangDto dto)
        {
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
            }
            if (_TenLoaiFilter.FilterValue != null)
            {
                dto.TenLoai = (string)_TenLoaiFilter.FilterValue;
            }
            if (_HangNhaLamFilter.FilterValue != null)
            {
                dto.HangNhaLam = (bool)_HangNhaLamFilter.FilterValue;
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
