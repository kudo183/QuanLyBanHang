using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class tChiTietDonHangViewModel : BaseViewModel<tChiTietDonHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(tChiTietDonHangDto dto);
        partial void ProcessNewAddedDtoPartial(tChiTietDonHangDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaDonHangFilter;
        HeaderFilterBaseModel _MaMatHangFilter;
        HeaderFilterBaseModel _SoLuongFilter;
        HeaderFilterBaseModel _XongFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tChiTietDonHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.tChiTietDonHang_Ma, nameof(tChiTietDonHangDto.Ma), typeof(int));
            _MaDonHangFilter = new HeaderTextFilterModel(TextManager.tChiTietDonHang_MaDonHang, nameof(tChiTietDonHangDto.MaDonHang), typeof(int));
            _MaMatHangFilter = new HeaderComboBoxFilterModel(
                TextManager.tChiTietDonHang_MaMatHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tChiTietDonHangDto.MaMatHang),
                typeof(int),
                nameof(tMatHangDto.DisplayText),
                nameof(tMatHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaMatHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.tMatHangView(), "tMatHang", ReferenceDataManager<tMatHangDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<tMatHangDto>.Instance.Get()
            };
            _SoLuongFilter = new HeaderTextFilterModel(TextManager.tChiTietDonHang_SoLuong, nameof(tChiTietDonHangDto.SoLuong), typeof(int));
            _XongFilter = new HeaderCheckFilterModel(TextManager.tChiTietDonHang_Xong, nameof(tChiTietDonHangDto.Xong), typeof(bool));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tChiTietDonHang_TenantID, nameof(tChiTietDonHangDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tChiTietDonHang_CreateTime, nameof(tChiTietDonHangDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tChiTietDonHang_LastUpdateTime, nameof(tChiTietDonHangDto.LastUpdateTime), typeof(long));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaDonHangFilter);
            AddHeaderFilter(_MaMatHangFilter);
            AddHeaderFilter(_SoLuongFilter);
            AddHeaderFilter(_XongFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<tMatHangDto>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(tChiTietDonHangDto dto)
        {
            dto.MaMatHangDataSource = ReferenceDataManager<tMatHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(tChiTietDonHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaDonHangFilter.FilterValue != null)
            {
                dto.MaDonHang = (int)_MaDonHangFilter.FilterValue;
            }
            if (_MaMatHangFilter.FilterValue != null)
            {
                dto.MaMatHang = (int)_MaMatHangFilter.FilterValue;
            }
            if (_SoLuongFilter.FilterValue != null)
            {
                dto.SoLuong = (int)_SoLuongFilter.FilterValue;
            }
            if (_XongFilter.FilterValue != null)
            {
                dto.Xong = (bool)_XongFilter.FilterValue;
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
