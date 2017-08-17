using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class rNhanVienViewModel : BaseViewModel<rNhanVienDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(rNhanVienDto dto);
        partial void ProcessNewAddedDtoPartial(rNhanVienDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaPhuongTienFilter;
        HeaderFilterBaseModel _TenNhanVienFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rNhanVienViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.rNhanVien_Ma, nameof(rNhanVienDto.Ma), typeof(int));
            _MaPhuongTienFilter = new HeaderComboBoxFilterModel(
                TextManager.rNhanVien_MaPhuongTien, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(rNhanVienDto.MaPhuongTien),
                typeof(int),
                nameof(rPhuongTienDto.DisplayText),
                nameof(rPhuongTienDto.ID))
            {
                AddCommand = new SimpleCommand("MaPhuongTienAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rPhuongTienView(), "rPhuongTien", ReferenceDataManager<rPhuongTienDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rPhuongTienDto>.Instance.Get()
            };
            _TenNhanVienFilter = new HeaderTextFilterModel(TextManager.rNhanVien_TenNhanVien, nameof(rNhanVienDto.TenNhanVien), typeof(string));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rNhanVien_TenantID, nameof(rNhanVienDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rNhanVien_CreateTime, nameof(rNhanVienDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rNhanVien_LastUpdateTime, nameof(rNhanVienDto.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaPhuongTienFilter);
            AddHeaderFilter(_TenNhanVienFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<rPhuongTienDto>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(rNhanVienDto dto)
        {
            dto.MaPhuongTienDataSource = ReferenceDataManager<rPhuongTienDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(rNhanVienDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaPhuongTienFilter.FilterValue != null)
            {
                dto.MaPhuongTien = (int)_MaPhuongTienFilter.FilterValue;
            }
            if (_TenNhanVienFilter.FilterValue != null)
            {
                dto.TenNhanVien = (string)_TenNhanVienFilter.FilterValue;
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
