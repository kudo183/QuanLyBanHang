using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class tChuyenKhoViewModel : BaseViewModel<tChuyenKhoDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(tChuyenKhoDto dto);
        partial void ProcessNewAddedDtoPartial(tChuyenKhoDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaNhanVienFilter;
        HeaderFilterBaseModel _MaKhoHangXuatFilter;
        HeaderFilterBaseModel _MaKhoHangNhapFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tChuyenKhoViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.tChuyenKho_Ma, nameof(tChuyenKhoDto.Ma), typeof(int));
            _MaNhanVienFilter = new HeaderComboBoxFilterModel(
                TextManager.tChuyenKho_MaNhanVien, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tChuyenKhoDto.MaNhanVien),
                typeof(int),
                nameof(rNhanVienDto.DisplayText),
                nameof(rNhanVienDto.ID))
            {
                AddCommand = new SimpleCommand("MaNhanVienAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rNhanVienView(), "rNhanVien", ReferenceDataManager<rNhanVienDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rNhanVienDto>.Instance.Get()
            };
            _MaKhoHangXuatFilter = new HeaderComboBoxFilterModel(
                TextManager.tChuyenKho_MaKhoHangXuat, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tChuyenKhoDto.MaKhoHangXuat),
                typeof(int),
                nameof(rKhoHangDto.DisplayText),
                nameof(rKhoHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaKhoHangXuatAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rKhoHangView(), "rKhoHang", ReferenceDataManager<rKhoHangDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rKhoHangDto>.Instance.Get()
            };
            _MaKhoHangNhapFilter = new HeaderComboBoxFilterModel(
                TextManager.tChuyenKho_MaKhoHangNhap, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tChuyenKhoDto.MaKhoHangNhap),
                typeof(int),
                nameof(rKhoHangDto.DisplayText),
                nameof(rKhoHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaKhoHangNhapAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rKhoHangView(), "rKhoHang", ReferenceDataManager<rKhoHangDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rKhoHangDto>.Instance.Get()
            };
            _NgayFilter = new HeaderDateFilterModel(TextManager.tChuyenKho_Ngay, nameof(tChuyenKhoDto.Ngay), typeof(System.DateTime));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tChuyenKho_TenantID, nameof(tChuyenKhoDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tChuyenKho_CreateTime, nameof(tChuyenKhoDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tChuyenKho_LastUpdateTime, nameof(tChuyenKhoDto.LastUpdateTime), typeof(long));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaNhanVienFilter);
            AddHeaderFilter(_MaKhoHangXuatFilter);
            AddHeaderFilter(_MaKhoHangNhapFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<rNhanVienDto>.Instance.LoadOrUpdate();
            ReferenceDataManager<rKhoHangDto>.Instance.LoadOrUpdate();
            ReferenceDataManager<rKhoHangDto>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(tChuyenKhoDto dto)
        {
            dto.MaNhanVienDataSource = ReferenceDataManager<rNhanVienDto>.Instance.Get();
            dto.MaKhoHangXuatDataSource = ReferenceDataManager<rKhoHangDto>.Instance.Get();
            dto.MaKhoHangNhapDataSource = ReferenceDataManager<rKhoHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(tChuyenKhoDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaNhanVienFilter.FilterValue != null)
            {
                dto.MaNhanVien = (int)_MaNhanVienFilter.FilterValue;
            }
            if (_MaKhoHangXuatFilter.FilterValue != null)
            {
                dto.MaKhoHangXuat = (int)_MaKhoHangXuatFilter.FilterValue;
            }
            if (_MaKhoHangNhapFilter.FilterValue != null)
            {
                dto.MaKhoHangNhap = (int)_MaKhoHangNhapFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dto.Ngay = (System.DateTime)_NgayFilter.FilterValue;
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
