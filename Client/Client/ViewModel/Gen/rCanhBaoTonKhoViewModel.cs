using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class rCanhBaoTonKhoViewModel : BaseViewModel<rCanhBaoTonKhoDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(rCanhBaoTonKhoDto dto);
        partial void ProcessNewAddedDtoPartial(rCanhBaoTonKhoDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaMatHangFilter;
        HeaderFilterBaseModel _MaKhoHangFilter;
        HeaderFilterBaseModel _TonCaoNhatFilter;
        HeaderFilterBaseModel _TonThapNhatFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rCanhBaoTonKhoViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.rCanhBaoTonKho_Ma, nameof(rCanhBaoTonKhoDto.Ma), typeof(int));
            _MaMatHangFilter = new HeaderComboBoxFilterModel(
                TextManager.rCanhBaoTonKho_MaMatHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(rCanhBaoTonKhoDto.MaMatHang),
                typeof(int),
                nameof(tMatHangDto.DisplayText),
                nameof(tMatHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaMatHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.tMatHangView(), "tMatHang", ReferenceDataManager<tMatHangDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<tMatHangDto>.Instance.Get()
            };
            _MaKhoHangFilter = new HeaderComboBoxFilterModel(
                TextManager.rCanhBaoTonKho_MaKhoHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(rCanhBaoTonKhoDto.MaKhoHang),
                typeof(int),
                nameof(rKhoHangDto.DisplayText),
                nameof(rKhoHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaKhoHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rKhoHangView(), "rKhoHang", ReferenceDataManager<rKhoHangDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rKhoHangDto>.Instance.Get()
            };
            _TonCaoNhatFilter = new HeaderTextFilterModel(TextManager.rCanhBaoTonKho_TonCaoNhat, nameof(rCanhBaoTonKhoDto.TonCaoNhat), typeof(int));
            _TonThapNhatFilter = new HeaderTextFilterModel(TextManager.rCanhBaoTonKho_TonThapNhat, nameof(rCanhBaoTonKhoDto.TonThapNhat), typeof(int));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rCanhBaoTonKho_TenantID, nameof(rCanhBaoTonKhoDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rCanhBaoTonKho_CreateTime, nameof(rCanhBaoTonKhoDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rCanhBaoTonKho_LastUpdateTime, nameof(rCanhBaoTonKhoDto.LastUpdateTime), typeof(long));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaMatHangFilter);
            AddHeaderFilter(_MaKhoHangFilter);
            AddHeaderFilter(_TonCaoNhatFilter);
            AddHeaderFilter(_TonThapNhatFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<tMatHangDto>.Instance.LoadOrUpdate();
            ReferenceDataManager<rKhoHangDto>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(rCanhBaoTonKhoDto dto)
        {
            dto.MaMatHangDataSource = ReferenceDataManager<tMatHangDto>.Instance.Get();
            dto.MaKhoHangDataSource = ReferenceDataManager<rKhoHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(rCanhBaoTonKhoDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaMatHangFilter.FilterValue != null)
            {
                dto.MaMatHang = (int)_MaMatHangFilter.FilterValue;
            }
            if (_MaKhoHangFilter.FilterValue != null)
            {
                dto.MaKhoHang = (int)_MaKhoHangFilter.FilterValue;
            }
            if (_TonCaoNhatFilter.FilterValue != null)
            {
                dto.TonCaoNhat = (int)_TonCaoNhatFilter.FilterValue;
            }
            if (_TonThapNhatFilter.FilterValue != null)
            {
                dto.TonThapNhat = (int)_TonThapNhatFilter.FilterValue;
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
