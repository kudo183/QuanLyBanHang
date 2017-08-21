using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class rMatHangNguyenLieuViewModel : BaseViewModel<rMatHangNguyenLieuDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(rMatHangNguyenLieuDto dto);
        partial void ProcessNewAddedDtoPartial(rMatHangNguyenLieuDto dto);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaMatHangFilter;
        HeaderFilterBaseModel _MaNguyenLieuFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rMatHangNguyenLieuViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.rMatHangNguyenLieu_ID, nameof(rMatHangNguyenLieuDto.ID), typeof(int));
            _MaMatHangFilter = new HeaderComboBoxFilterModel(
                TextManager.rMatHangNguyenLieu_MaMatHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(rMatHangNguyenLieuDto.MaMatHang),
                typeof(int),
                nameof(tMatHangDto.DisplayText),
                nameof(tMatHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaMatHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.tMatHangView(), "tMatHang", ReferenceDataManager<tMatHangDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<tMatHangDto>.Instance.Get()
            };
            _MaNguyenLieuFilter = new HeaderComboBoxFilterModel(
                TextManager.rMatHangNguyenLieu_MaNguyenLieu, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(rMatHangNguyenLieuDto.MaNguyenLieu),
                typeof(int),
                nameof(rNguyenLieuDto.DisplayText),
                nameof(rNguyenLieuDto.ID))
            {
                AddCommand = new SimpleCommand("MaNguyenLieuAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rNguyenLieuView(), "rNguyenLieu", ReferenceDataManager<rNguyenLieuDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rNguyenLieuDto>.Instance.Get()
            };
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rMatHangNguyenLieu_TenantID, nameof(rMatHangNguyenLieuDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rMatHangNguyenLieu_CreateTime, nameof(rMatHangNguyenLieuDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rMatHangNguyenLieu_LastUpdateTime, nameof(rMatHangNguyenLieuDto.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaMatHangFilter);
            AddHeaderFilter(_MaNguyenLieuFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<tMatHangDto>.Instance.LoadOrUpdate();
            ReferenceDataManager<rNguyenLieuDto>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(rMatHangNguyenLieuDto dto)
        {
            dto.MaMatHangDataSource = ReferenceDataManager<tMatHangDto>.Instance.Get();
            dto.MaNguyenLieuDataSource = ReferenceDataManager<rNguyenLieuDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(rMatHangNguyenLieuDto dto)
        {
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaMatHangFilter.FilterValue != null)
            {
                dto.MaMatHang = (int)_MaMatHangFilter.FilterValue;
            }
            if (_MaNguyenLieuFilter.FilterValue != null)
            {
                dto.MaNguyenLieu = (int)_MaNguyenLieuFilter.FilterValue;
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
