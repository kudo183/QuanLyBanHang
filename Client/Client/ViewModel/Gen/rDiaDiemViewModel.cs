using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class rDiaDiemViewModel : BaseViewModel<rDiaDiemDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(rDiaDiemDto dto);
        partial void ProcessNewAddedDtoPartial(rDiaDiemDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaNuocFilter;
        HeaderFilterBaseModel _TinhFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rDiaDiemViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.rDiaDiem_Ma, nameof(rDiaDiemDto.Ma), typeof(int));
            _MaNuocFilter = new HeaderComboBoxFilterModel(
                TextManager.rDiaDiem_MaNuoc, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(rDiaDiemDto.MaNuoc),
                typeof(int),
                nameof(rNuocDto.DisplayText),
                nameof(rNuocDto.ID))
            {
                AddCommand = new SimpleCommand("MaNuocAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rNuocView(), "rNuoc", ReferenceDataManager<rNuocDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rNuocDto>.Instance.Get()
            };
            _TinhFilter = new HeaderTextFilterModel(TextManager.rDiaDiem_Tinh, nameof(rDiaDiemDto.Tinh), typeof(string));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rDiaDiem_TenantID, nameof(rDiaDiemDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rDiaDiem_CreateTime, nameof(rDiaDiemDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rDiaDiem_LastUpdateTime, nameof(rDiaDiemDto.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaNuocFilter);
            AddHeaderFilter(_TinhFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<rNuocDto>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(rDiaDiemDto dto)
        {
            dto.MaNuocDataSource = ReferenceDataManager<rNuocDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(rDiaDiemDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaNuocFilter.FilterValue != null)
            {
                dto.MaNuoc = (int)_MaNuocFilter.FilterValue;
            }
            if (_TinhFilter.FilterValue != null)
            {
                dto.Tinh = (string)_TinhFilter.FilterValue;
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
