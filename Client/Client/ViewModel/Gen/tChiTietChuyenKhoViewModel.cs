using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class tChiTietChuyenKhoViewModel : BaseViewModel<tChiTietChuyenKhoDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(tChiTietChuyenKhoDto dto);
        partial void ProcessNewAddedDtoPartial(tChiTietChuyenKhoDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaChuyenKhoFilter;
        HeaderFilterBaseModel _MaMatHangFilter;
        HeaderFilterBaseModel _SoLuongFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tChiTietChuyenKhoViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenKho_Ma, nameof(tChiTietChuyenKhoDto.Ma), typeof(int));
            _MaChuyenKhoFilter = new HeaderForeignKeyFilterModel(TextManager.tChiTietChuyenKho_MaChuyenKho, nameof(tChiTietChuyenKhoDto.MaChuyenKho), typeof(int), new View.tChuyenKhoView() { KeepSelectionType = DataGridExt.KeepSelection.KeepSelectedValue });
            _MaMatHangFilter = new HeaderComboBoxFilterModel(
                TextManager.tChiTietChuyenKho_MaMatHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tChiTietChuyenKhoDto.MaMatHang),
                typeof(int),
                nameof(tMatHangDto.DisplayText),
                nameof(tMatHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaMatHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.tMatHangView(), "tMatHang", ReferenceDataManager<tMatHangDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<tMatHangDto>.Instance.Get()
            };
            _SoLuongFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenKho_SoLuong, nameof(tChiTietChuyenKhoDto.SoLuong), typeof(int));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenKho_TenantID, nameof(tChiTietChuyenKhoDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenKho_CreateTime, nameof(tChiTietChuyenKhoDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenKho_LastUpdateTime, nameof(tChiTietChuyenKhoDto.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaChuyenKhoFilter);
            AddHeaderFilter(_MaMatHangFilter);
            AddHeaderFilter(_SoLuongFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<tMatHangDto>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(tChiTietChuyenKhoDto dto)
        {
            dto.MaMatHangDataSource = ReferenceDataManager<tMatHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(tChiTietChuyenKhoDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaChuyenKhoFilter.FilterValue != null)
            {
                dto.MaChuyenKho = (int)_MaChuyenKhoFilter.FilterValue;
            }
            if (_MaMatHangFilter.FilterValue != null)
            {
                dto.MaMatHang = (int)_MaMatHangFilter.FilterValue;
            }
            if (_SoLuongFilter.FilterValue != null)
            {
                dto.SoLuong = (int)_SoLuongFilter.FilterValue;
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
