using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class rNguyenLieuViewModel : BaseViewModel<rNguyenLieuDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(rNguyenLieuDto dto);
        partial void ProcessNewAddedDtoPartial(rNguyenLieuDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaLoaiNguyenLieuFilter;
        HeaderFilterBaseModel _DuongKinhFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rNguyenLieuViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.rNguyenLieu_Ma, nameof(rNguyenLieuDto.Ma), typeof(int));
            _MaLoaiNguyenLieuFilter = new HeaderComboBoxFilterModel(
                TextManager.rNguyenLieu_MaLoaiNguyenLieu, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(rNguyenLieuDto.MaLoaiNguyenLieu),
                typeof(int),
                nameof(rLoaiNguyenLieuDto.DisplayText),
                nameof(rLoaiNguyenLieuDto.ID))
            {
                AddCommand = new SimpleCommand("MaLoaiNguyenLieuAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rLoaiNguyenLieuView(), "rLoaiNguyenLieu", ReferenceDataManager<rLoaiNguyenLieuDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rLoaiNguyenLieuDto>.Instance.Get()
            };
            _DuongKinhFilter = new HeaderTextFilterModel(TextManager.rNguyenLieu_DuongKinh, nameof(rNguyenLieuDto.DuongKinh), typeof(int));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rNguyenLieu_TenantID, nameof(rNguyenLieuDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rNguyenLieu_CreateTime, nameof(rNguyenLieuDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rNguyenLieu_LastUpdateTime, nameof(rNguyenLieuDto.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaLoaiNguyenLieuFilter);
            AddHeaderFilter(_DuongKinhFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<rLoaiNguyenLieuDto>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(rNguyenLieuDto dto)
        {
            dto.MaLoaiNguyenLieuDataSource = ReferenceDataManager<rLoaiNguyenLieuDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(rNguyenLieuDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaLoaiNguyenLieuFilter.FilterValue != null)
            {
                dto.MaLoaiNguyenLieu = (int)_MaLoaiNguyenLieuFilter.FilterValue;
            }
            if (_DuongKinhFilter.FilterValue != null)
            {
                dto.DuongKinh = (int)_DuongKinhFilter.FilterValue;
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
