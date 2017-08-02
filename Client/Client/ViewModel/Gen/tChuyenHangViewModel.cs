using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class tChuyenHangViewModel : BaseViewModel<tChuyenHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(tChuyenHangDto dto);
        partial void ProcessNewAddedDtoPartial(tChuyenHangDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaNhanVienGiaoHangFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _GioFilter;
        HeaderFilterBaseModel _TongDonHangFilter;
        HeaderFilterBaseModel _TongSoLuongTheoDonHangFilter;
        HeaderFilterBaseModel _TongSoLuongThucTeFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tChuyenHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.tChuyenHang_Ma, nameof(tChuyenHangDto.Ma), typeof(int));
            _MaNhanVienGiaoHangFilter = new HeaderComboBoxFilterModel(
                TextManager.tChuyenHang_MaNhanVienGiaoHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tChuyenHangDto.MaNhanVienGiaoHang),
                typeof(int),
                nameof(rNhanVienDto.DisplayText),
                nameof(rNhanVienDto.ID))
            {
                AddCommand = new SimpleCommand("MaNhanVienGiaoHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rNhanVienView(), "rNhanVien", ReferenceDataManager<rNhanVienDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rNhanVienDto>.Instance.Get()
            };
            _NgayFilter = new HeaderDateFilterModel(TextManager.tChuyenHang_Ngay, nameof(tChuyenHangDto.Ngay), typeof(System.DateTime));
            _GioFilter = new HeaderTextFilterModel(TextManager.tChuyenHang_Gio, nameof(tChuyenHangDto.Gio), typeof(System.TimeSpan?));
            _TongDonHangFilter = new HeaderTextFilterModel(TextManager.tChuyenHang_TongDonHang, nameof(tChuyenHangDto.TongDonHang), typeof(int));
            _TongSoLuongTheoDonHangFilter = new HeaderTextFilterModel(TextManager.tChuyenHang_TongSoLuongTheoDonHang, nameof(tChuyenHangDto.TongSoLuongTheoDonHang), typeof(int));
            _TongSoLuongThucTeFilter = new HeaderTextFilterModel(TextManager.tChuyenHang_TongSoLuongThucTe, nameof(tChuyenHangDto.TongSoLuongThucTe), typeof(int));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tChuyenHang_TenantID, nameof(tChuyenHangDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tChuyenHang_CreateTime, nameof(tChuyenHangDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tChuyenHang_LastUpdateTime, nameof(tChuyenHangDto.LastUpdateTime), typeof(long));

            _NgayFilter.IsSorted = HeaderFilterBaseModel.SortDirection.Descending;

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaNhanVienGiaoHangFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_GioFilter);
            AddHeaderFilter(_TongDonHangFilter);
            AddHeaderFilter(_TongSoLuongTheoDonHangFilter);
            AddHeaderFilter(_TongSoLuongThucTeFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<rNhanVienDto>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(tChuyenHangDto dto)
        {
            dto.MaNhanVienGiaoHangDataSource = ReferenceDataManager<rNhanVienDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(tChuyenHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaNhanVienGiaoHangFilter.FilterValue != null)
            {
                dto.MaNhanVienGiaoHang = (int)_MaNhanVienGiaoHangFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dto.Ngay = (System.DateTime)_NgayFilter.FilterValue;
            }
            if (_GioFilter.FilterValue != null)
            {
                dto.Gio = (System.TimeSpan?)_GioFilter.FilterValue;
            }
            if (_TongDonHangFilter.FilterValue != null)
            {
                dto.TongDonHang = (int)_TongDonHangFilter.FilterValue;
            }
            if (_TongSoLuongTheoDonHangFilter.FilterValue != null)
            {
                dto.TongSoLuongTheoDonHang = (int)_TongSoLuongTheoDonHangFilter.FilterValue;
            }
            if (_TongSoLuongThucTeFilter.FilterValue != null)
            {
                dto.TongSoLuongThucTe = (int)_TongSoLuongThucTeFilter.FilterValue;
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
