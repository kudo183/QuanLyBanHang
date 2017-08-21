using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class tNhapNguyenLieuViewModel : BaseViewModel<tNhapNguyenLieuDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(tNhapNguyenLieuDto dto);
        partial void ProcessNewAddedDtoPartial(tNhapNguyenLieuDto dto);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _MaNguyenLieuFilter;
        HeaderFilterBaseModel _MaNhaCungCapFilter;
        HeaderFilterBaseModel _SoLuongFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tNhapNguyenLieuViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.tNhapNguyenLieu_ID, nameof(tNhapNguyenLieuDto.ID), typeof(int));
            _NgayFilter = new HeaderDateFilterModel(TextManager.tNhapNguyenLieu_Ngay, nameof(tNhapNguyenLieuDto.Ngay), typeof(System.DateTime));
            _MaNguyenLieuFilter = new HeaderComboBoxFilterModel(
                TextManager.tNhapNguyenLieu_MaNguyenLieu, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tNhapNguyenLieuDto.MaNguyenLieu),
                typeof(int),
                nameof(rNguyenLieuDto.DisplayText),
                nameof(rNguyenLieuDto.ID))
            {
                AddCommand = new SimpleCommand("MaNguyenLieuAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rNguyenLieuView(), "rNguyenLieu", ReferenceDataManager<rNguyenLieuDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rNguyenLieuDto>.Instance.Get()
            };
            _MaNhaCungCapFilter = new HeaderComboBoxFilterModel(
                TextManager.tNhapNguyenLieu_MaNhaCungCap, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tNhapNguyenLieuDto.MaNhaCungCap),
                typeof(int),
                nameof(rNhaCungCapDto.DisplayText),
                nameof(rNhaCungCapDto.ID))
            {
                AddCommand = new SimpleCommand("MaNhaCungCapAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rNhaCungCapView(), "rNhaCungCap", ReferenceDataManager<rNhaCungCapDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rNhaCungCapDto>.Instance.Get()
            };
            _SoLuongFilter = new HeaderTextFilterModel(TextManager.tNhapNguyenLieu_SoLuong, nameof(tNhapNguyenLieuDto.SoLuong), typeof(int));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tNhapNguyenLieu_TenantID, nameof(tNhapNguyenLieuDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tNhapNguyenLieu_CreateTime, nameof(tNhapNguyenLieuDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tNhapNguyenLieu_LastUpdateTime, nameof(tNhapNguyenLieuDto.LastUpdateTime), typeof(long));

            _NgayFilter.IsSorted = HeaderFilterBaseModel.SortDirection.Descending;

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_MaNguyenLieuFilter);
            AddHeaderFilter(_MaNhaCungCapFilter);
            AddHeaderFilter(_SoLuongFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<rNguyenLieuDto>.Instance.LoadOrUpdate();
            ReferenceDataManager<rNhaCungCapDto>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(tNhapNguyenLieuDto dto)
        {
            dto.MaNguyenLieuDataSource = ReferenceDataManager<rNguyenLieuDto>.Instance.Get();
            dto.MaNhaCungCapDataSource = ReferenceDataManager<rNhaCungCapDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(tNhapNguyenLieuDto dto)
        {
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dto.Ngay = (System.DateTime)_NgayFilter.FilterValue;
            }
            if (_MaNguyenLieuFilter.FilterValue != null)
            {
                dto.MaNguyenLieu = (int)_MaNguyenLieuFilter.FilterValue;
            }
            if (_MaNhaCungCapFilter.FilterValue != null)
            {
                dto.MaNhaCungCap = (int)_MaNhaCungCapFilter.FilterValue;
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
