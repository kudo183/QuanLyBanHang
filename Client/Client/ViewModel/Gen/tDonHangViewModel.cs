using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class tDonHangViewModel : BaseViewModel<tDonHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(tDonHangDto dto);
        partial void ProcessNewAddedDtoPartial(tDonHangDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaKhachHangFilter;
        HeaderFilterBaseModel _MaChanhFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _XongFilter;
        HeaderFilterBaseModel _MaKhoHangFilter;
        HeaderFilterBaseModel _TongSoLuongFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tDonHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.tDonHang_Ma, nameof(tDonHangDto.Ma), typeof(int));
            _MaKhachHangFilter = new HeaderComboBoxFilterModel(
                TextManager.tDonHang_MaKhachHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tDonHangDto.MaKhachHang),
                typeof(int),
                nameof(rKhachHangDto.DisplayText),
                nameof(rKhachHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaKhachHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rKhachHangView(), "rKhachHang", ReferenceDataManager<rKhachHangDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rKhachHangDto>.Instance.Get()
            };
            _MaChanhFilter = new HeaderComboBoxFilterModel(
                TextManager.tDonHang_MaChanh, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tDonHangDto.MaChanh),
                typeof(int?),
                nameof(rChanhDto.DisplayText),
                nameof(rChanhDto.ID))
            {
                AddCommand = new SimpleCommand("MaChanhAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rChanhView(), "rChanh", ReferenceDataManager<rChanhDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rChanhDto>.Instance.Get()
            };
            _NgayFilter = new HeaderDateFilterModel(TextManager.tDonHang_Ngay, nameof(tDonHangDto.Ngay), typeof(System.DateTime));
            _XongFilter = new HeaderCheckFilterModel(TextManager.tDonHang_Xong, nameof(tDonHangDto.Xong), typeof(bool));
            _MaKhoHangFilter = new HeaderComboBoxFilterModel(
                TextManager.tDonHang_MaKhoHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tDonHangDto.MaKhoHang),
                typeof(int),
                nameof(rKhoHangDto.DisplayText),
                nameof(rKhoHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaKhoHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rKhoHangView(), "rKhoHang", ReferenceDataManager<rKhoHangDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rKhoHangDto>.Instance.Get()
            };
            _TongSoLuongFilter = new HeaderTextFilterModel(TextManager.tDonHang_TongSoLuong, nameof(tDonHangDto.TongSoLuong), typeof(int));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tDonHang_TenantID, nameof(tDonHangDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tDonHang_CreateTime, nameof(tDonHangDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tDonHang_LastUpdateTime, nameof(tDonHangDto.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaKhachHangFilter);
            AddHeaderFilter(_MaChanhFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_XongFilter);
            AddHeaderFilter(_MaKhoHangFilter);
            AddHeaderFilter(_TongSoLuongFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<rKhachHangDto>.Instance.LoadOrUpdate();
            ReferenceDataManager<rChanhDto>.Instance.LoadOrUpdate();
            ReferenceDataManager<rKhoHangDto>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(tDonHangDto dto)
        {
            dto.MaKhachHangDataSource = ReferenceDataManager<rKhachHangDto>.Instance.Get();
            dto.MaChanhDataSource = ReferenceDataManager<rChanhDto>.Instance.Get();
            dto.MaKhoHangDataSource = ReferenceDataManager<rKhoHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(tDonHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaKhachHangFilter.FilterValue != null)
            {
                dto.MaKhachHang = (int)_MaKhachHangFilter.FilterValue;
            }
            if (_MaChanhFilter.FilterValue != null)
            {
                dto.MaChanh = (int?)_MaChanhFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dto.Ngay = (System.DateTime)_NgayFilter.FilterValue;
            }
            if (_XongFilter.FilterValue != null)
            {
                dto.Xong = (bool)_XongFilter.FilterValue;
            }
            if (_MaKhoHangFilter.FilterValue != null)
            {
                dto.MaKhoHang = (int)_MaKhoHangFilter.FilterValue;
            }
            if (_TongSoLuongFilter.FilterValue != null)
            {
                dto.TongSoLuong = (int)_TongSoLuongFilter.FilterValue;
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
