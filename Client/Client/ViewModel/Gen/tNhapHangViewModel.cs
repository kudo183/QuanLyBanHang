using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class tNhapHangViewModel : BaseViewModel<tNhapHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(tNhapHangDto dto);
        partial void ProcessNewAddedDtoPartial(tNhapHangDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaNhanVienFilter;
        HeaderFilterBaseModel _MaKhoHangFilter;
        HeaderFilterBaseModel _MaNhaCungCapFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tNhapHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.tNhapHang_Ma, nameof(tNhapHangDto.Ma), typeof(int));
            _MaNhanVienFilter = new HeaderComboBoxFilterModel(
                TextManager.tNhapHang_MaNhanVien, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tNhapHangDto.MaNhanVien),
                typeof(int),
                nameof(rNhanVienDto.DisplayText),
                nameof(rNhanVienDto.ID))
            {
                AddCommand = new SimpleCommand("MaNhanVienAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rNhanVienView(), "rNhanVien", ReferenceDataManager<rNhanVienDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rNhanVienDto>.Instance.Get()
            };
            _MaKhoHangFilter = new HeaderComboBoxFilterModel(
                TextManager.tNhapHang_MaKhoHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tNhapHangDto.MaKhoHang),
                typeof(int),
                nameof(rKhoHangDto.DisplayText),
                nameof(rKhoHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaKhoHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rKhoHangView(), "rKhoHang", ReferenceDataManager<rKhoHangDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rKhoHangDto>.Instance.Get()
            };
            _MaNhaCungCapFilter = new HeaderComboBoxFilterModel(
                TextManager.tNhapHang_MaNhaCungCap, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tNhapHangDto.MaNhaCungCap),
                typeof(int),
                nameof(rNhaCungCapDto.DisplayText),
                nameof(rNhaCungCapDto.ID))
            {
                AddCommand = new SimpleCommand("MaNhaCungCapAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rNhaCungCapView(), "rNhaCungCap", ReferenceDataManager<rNhaCungCapDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rNhaCungCapDto>.Instance.Get()
            };
            _NgayFilter = new HeaderDateFilterModel(TextManager.tNhapHang_Ngay, nameof(tNhapHangDto.Ngay), typeof(System.DateTime));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tNhapHang_TenantID, nameof(tNhapHangDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tNhapHang_CreateTime, nameof(tNhapHangDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tNhapHang_LastUpdateTime, nameof(tNhapHangDto.LastUpdateTime), typeof(long));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaNhanVienFilter);
            AddHeaderFilter(_MaKhoHangFilter);
            AddHeaderFilter(_MaNhaCungCapFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<rNhanVienDto>.Instance.LoadOrUpdate();
            ReferenceDataManager<rKhoHangDto>.Instance.LoadOrUpdate();
            ReferenceDataManager<rNhaCungCapDto>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(tNhapHangDto dto)
        {
            dto.MaNhanVienDataSource = ReferenceDataManager<rNhanVienDto>.Instance.Get();
            dto.MaKhoHangDataSource = ReferenceDataManager<rKhoHangDto>.Instance.Get();
            dto.MaNhaCungCapDataSource = ReferenceDataManager<rNhaCungCapDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(tNhapHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaNhanVienFilter.FilterValue != null)
            {
                dto.MaNhanVien = (int)_MaNhanVienFilter.FilterValue;
            }
            if (_MaKhoHangFilter.FilterValue != null)
            {
                dto.MaKhoHang = (int)_MaKhoHangFilter.FilterValue;
            }
            if (_MaNhaCungCapFilter.FilterValue != null)
            {
                dto.MaNhaCungCap = (int)_MaNhaCungCapFilter.FilterValue;
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
