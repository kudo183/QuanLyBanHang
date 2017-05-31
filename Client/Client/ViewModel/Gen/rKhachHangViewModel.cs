using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class rKhachHangViewModel : BaseViewModel<rKhachHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(rKhachHangDto dto);
        partial void ProcessNewAddedDtoPartial(rKhachHangDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaDiaDiemFilter;
        HeaderFilterBaseModel _TenKhachHangFilter;
        HeaderFilterBaseModel _KhachRiengFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rKhachHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.rKhachHang_Ma, nameof(rKhachHangDto.Ma), typeof(int));
            _MaDiaDiemFilter = new HeaderComboBoxFilterModel(
                TextManager.rKhachHang_MaDiaDiem, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(rKhachHangDto.MaDiaDiem),
                typeof(int),
                nameof(rDiaDiemDto.DisplayText),
                nameof(rDiaDiemDto.ID))
            {
                AddCommand = new SimpleCommand("MaDiaDiemAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rDiaDiemView(), "rDiaDiem", ReferenceDataManager<rDiaDiemDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rDiaDiemDto>.Instance.Get()
            };
            _TenKhachHangFilter = new HeaderTextFilterModel(TextManager.rKhachHang_TenKhachHang, nameof(rKhachHangDto.TenKhachHang), typeof(string));
            _KhachRiengFilter = new HeaderCheckFilterModel(TextManager.rKhachHang_KhachRieng, nameof(rKhachHangDto.KhachRieng), typeof(bool));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rKhachHang_TenantID, nameof(rKhachHangDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rKhachHang_CreateTime, nameof(rKhachHangDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rKhachHang_LastUpdateTime, nameof(rKhachHangDto.LastUpdateTime), typeof(long));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaDiaDiemFilter);
            AddHeaderFilter(_TenKhachHangFilter);
            AddHeaderFilter(_KhachRiengFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<rDiaDiemDto>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(rKhachHangDto dto)
        {
            dto.MaDiaDiemDataSource = ReferenceDataManager<rDiaDiemDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(rKhachHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaDiaDiemFilter.FilterValue != null)
            {
                dto.MaDiaDiem = (int)_MaDiaDiemFilter.FilterValue;
            }
            if (_TenKhachHangFilter.FilterValue != null)
            {
                dto.TenKhachHang = (string)_TenKhachHangFilter.FilterValue;
            }
            if (_KhachRiengFilter.FilterValue != null)
            {
                dto.KhachRieng = (bool)_KhachRiengFilter.FilterValue;
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
