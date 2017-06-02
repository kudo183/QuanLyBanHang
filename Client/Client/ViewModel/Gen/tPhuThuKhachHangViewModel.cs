using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class tPhuThuKhachHangViewModel : BaseViewModel<tPhuThuKhachHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(tPhuThuKhachHangDto dto);
        partial void ProcessNewAddedDtoPartial(tPhuThuKhachHangDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaKhachHangFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _SoTienFilter;
        HeaderFilterBaseModel _GhiChuFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tPhuThuKhachHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.tPhuThuKhachHang_Ma, nameof(tPhuThuKhachHangDto.Ma), typeof(int));
            _MaKhachHangFilter = new HeaderComboBoxFilterModel(
                TextManager.tPhuThuKhachHang_MaKhachHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tPhuThuKhachHangDto.MaKhachHang),
                typeof(int),
                nameof(rKhachHangDto.DisplayText),
                nameof(rKhachHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaKhachHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rKhachHangView(), "rKhachHang", ReferenceDataManager<rKhachHangDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rKhachHangDto>.Instance.Get()
            };
            _NgayFilter = new HeaderDateFilterModel(TextManager.tPhuThuKhachHang_Ngay, nameof(tPhuThuKhachHangDto.Ngay), typeof(System.DateTime));
            _SoTienFilter = new HeaderTextFilterModel(TextManager.tPhuThuKhachHang_SoTien, nameof(tPhuThuKhachHangDto.SoTien), typeof(int));
            _GhiChuFilter = new HeaderTextFilterModel(TextManager.tPhuThuKhachHang_GhiChu, nameof(tPhuThuKhachHangDto.GhiChu), typeof(string));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tPhuThuKhachHang_TenantID, nameof(tPhuThuKhachHangDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tPhuThuKhachHang_CreateTime, nameof(tPhuThuKhachHangDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tPhuThuKhachHang_LastUpdateTime, nameof(tPhuThuKhachHangDto.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaKhachHangFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_SoTienFilter);
            AddHeaderFilter(_GhiChuFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<rKhachHangDto>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(tPhuThuKhachHangDto dto)
        {
            dto.MaKhachHangDataSource = ReferenceDataManager<rKhachHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(tPhuThuKhachHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaKhachHangFilter.FilterValue != null)
            {
                dto.MaKhachHang = (int)_MaKhachHangFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dto.Ngay = (System.DateTime)_NgayFilter.FilterValue;
            }
            if (_SoTienFilter.FilterValue != null)
            {
                dto.SoTien = (int)_SoTienFilter.FilterValue;
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
