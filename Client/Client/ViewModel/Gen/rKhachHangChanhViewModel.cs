using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class rKhachHangChanhViewModel : BaseViewModel<rKhachHangChanhDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(rKhachHangChanhDto dto);
        partial void ProcessNewAddedDtoPartial(rKhachHangChanhDto dto);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaChanhFilter;
        HeaderFilterBaseModel _MaKhachHangFilter;
        HeaderFilterBaseModel _LaMacDinhFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rKhachHangChanhViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.rKhachHangChanh_ID, nameof(rKhachHangChanhDto.ID), typeof(int));
            _MaChanhFilter = new HeaderComboBoxFilterModel(
                TextManager.rKhachHangChanh_MaChanh, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(rKhachHangChanhDto.MaChanh),
                typeof(int),
                nameof(rChanhDto.DisplayText),
                nameof(rChanhDto.ID))
            {
                AddCommand = new SimpleCommand("MaChanhAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rChanhView(), "rChanh", ReferenceDataManager<rChanhDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rChanhDto>.Instance.Get()
            };
            _MaKhachHangFilter = new HeaderComboBoxFilterModel(
                TextManager.rKhachHangChanh_MaKhachHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(rKhachHangChanhDto.MaKhachHang),
                typeof(int),
                nameof(rKhachHangDto.DisplayText),
                nameof(rKhachHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaKhachHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rKhachHangView(), "rKhachHang", ReferenceDataManager<rKhachHangDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rKhachHangDto>.Instance.Get()
            };
            _LaMacDinhFilter = new HeaderCheckFilterModel(TextManager.rKhachHangChanh_LaMacDinh, nameof(rKhachHangChanhDto.LaMacDinh), typeof(bool));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rKhachHangChanh_TenantID, nameof(rKhachHangChanhDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rKhachHangChanh_CreateTime, nameof(rKhachHangChanhDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rKhachHangChanh_LastUpdateTime, nameof(rKhachHangChanhDto.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaChanhFilter);
            AddHeaderFilter(_MaKhachHangFilter);
            AddHeaderFilter(_LaMacDinhFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<rChanhDto>.Instance.LoadOrUpdate();
            ReferenceDataManager<rKhachHangDto>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(rKhachHangChanhDto dto)
        {
            dto.MaChanhDataSource = ReferenceDataManager<rChanhDto>.Instance.Get();
            dto.MaKhachHangDataSource = ReferenceDataManager<rKhachHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(rKhachHangChanhDto dto)
        {
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaChanhFilter.FilterValue != null)
            {
                dto.MaChanh = (int)_MaChanhFilter.FilterValue;
            }
            if (_MaKhachHangFilter.FilterValue != null)
            {
                dto.MaKhachHang = (int)_MaKhachHangFilter.FilterValue;
            }
            if (_LaMacDinhFilter.FilterValue != null)
            {
                dto.LaMacDinh = (bool)_LaMacDinhFilter.FilterValue;
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
