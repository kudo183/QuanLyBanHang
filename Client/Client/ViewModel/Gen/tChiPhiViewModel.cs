using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class tChiPhiViewModel : BaseViewModel<tChiPhiDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(tChiPhiDto dto);
        partial void ProcessNewAddedDtoPartial(tChiPhiDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaNhanVienGiaoHangFilter;
        HeaderFilterBaseModel _MaLoaiChiPhiFilter;
        HeaderFilterBaseModel _SoTienFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _GhiChuFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tChiPhiViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.tChiPhi_Ma, nameof(tChiPhiDto.Ma), typeof(int));
            _MaNhanVienGiaoHangFilter = new HeaderComboBoxFilterModel(
                TextManager.tChiPhi_MaNhanVienGiaoHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tChiPhiDto.MaNhanVienGiaoHang),
                typeof(int),
                nameof(rNhanVienDto.DisplayText),
                nameof(rNhanVienDto.ID))
            {
                AddCommand = new SimpleCommand("MaNhanVienGiaoHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rNhanVienView(), "rNhanVien", ReferenceDataManager<rNhanVienDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rNhanVienDto>.Instance.Get()
            };
            _MaLoaiChiPhiFilter = new HeaderComboBoxFilterModel(
                TextManager.tChiPhi_MaLoaiChiPhi, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tChiPhiDto.MaLoaiChiPhi),
                typeof(int),
                nameof(rLoaiChiPhiDto.DisplayText),
                nameof(rLoaiChiPhiDto.ID))
            {
                AddCommand = new SimpleCommand("MaLoaiChiPhiAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rLoaiChiPhiView(), "rLoaiChiPhi", ReferenceDataManager<rLoaiChiPhiDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rLoaiChiPhiDto>.Instance.Get()
            };
            _SoTienFilter = new HeaderTextFilterModel(TextManager.tChiPhi_SoTien, nameof(tChiPhiDto.SoTien), typeof(int));
            _NgayFilter = new HeaderDateFilterModel(TextManager.tChiPhi_Ngay, nameof(tChiPhiDto.Ngay), typeof(System.DateTime));
            _GhiChuFilter = new HeaderTextFilterModel(TextManager.tChiPhi_GhiChu, nameof(tChiPhiDto.GhiChu), typeof(string));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tChiPhi_TenantID, nameof(tChiPhiDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tChiPhi_CreateTime, nameof(tChiPhiDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tChiPhi_LastUpdateTime, nameof(tChiPhiDto.LastUpdateTime), typeof(long));

            _NgayFilter.IsSorted = HeaderFilterBaseModel.SortDirection.Descending;

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaNhanVienGiaoHangFilter);
            AddHeaderFilter(_MaLoaiChiPhiFilter);
            AddHeaderFilter(_SoTienFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_GhiChuFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<rNhanVienDto>.Instance.LoadOrUpdate();
            ReferenceDataManager<rLoaiChiPhiDto>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(tChiPhiDto dto)
        {
            dto.MaNhanVienGiaoHangDataSource = ReferenceDataManager<rNhanVienDto>.Instance.Get();
            dto.MaLoaiChiPhiDataSource = ReferenceDataManager<rLoaiChiPhiDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(tChiPhiDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaNhanVienGiaoHangFilter.FilterValue != null)
            {
                dto.MaNhanVienGiaoHang = (int)_MaNhanVienGiaoHangFilter.FilterValue;
            }
            if (_MaLoaiChiPhiFilter.FilterValue != null)
            {
                dto.MaLoaiChiPhi = (int)_MaLoaiChiPhiFilter.FilterValue;
            }
            if (_SoTienFilter.FilterValue != null)
            {
                dto.SoTien = (int)_SoTienFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dto.Ngay = (System.DateTime)_NgayFilter.FilterValue;
            }
            if (_GhiChuFilter.FilterValue != null)
            {
                dto.GhiChu = (string)_GhiChuFilter.FilterValue;
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
