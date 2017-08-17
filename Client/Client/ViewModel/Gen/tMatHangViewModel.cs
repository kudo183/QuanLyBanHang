using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class tMatHangViewModel : BaseViewModel<tMatHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(tMatHangDto dto);
        partial void ProcessNewAddedDtoPartial(tMatHangDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaLoaiFilter;
        HeaderFilterBaseModel _TenMatHangFilter;
        HeaderFilterBaseModel _SoKyFilter;
        HeaderFilterBaseModel _SoMetFilter;
        HeaderFilterBaseModel _TenMatHangDayDuFilter;
        HeaderFilterBaseModel _TenMatHangInFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tMatHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.tMatHang_Ma, nameof(tMatHangDto.Ma), typeof(int));
            _MaLoaiFilter = new HeaderComboBoxFilterModel(
                TextManager.tMatHang_MaLoai, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tMatHangDto.MaLoai),
                typeof(int),
                nameof(rLoaiHangDto.DisplayText),
                nameof(rLoaiHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaLoaiAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rLoaiHangView(), "rLoaiHang", ReferenceDataManager<rLoaiHangDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rLoaiHangDto>.Instance.Get()
            };
            _TenMatHangFilter = new HeaderTextFilterModel(TextManager.tMatHang_TenMatHang, nameof(tMatHangDto.TenMatHang), typeof(string));
            _SoKyFilter = new HeaderTextFilterModel(TextManager.tMatHang_SoKy, nameof(tMatHangDto.SoKy), typeof(int));
            _SoMetFilter = new HeaderTextFilterModel(TextManager.tMatHang_SoMet, nameof(tMatHangDto.SoMet), typeof(int));
            _TenMatHangDayDuFilter = new HeaderTextFilterModel(TextManager.tMatHang_TenMatHangDayDu, nameof(tMatHangDto.TenMatHangDayDu), typeof(string));
            _TenMatHangInFilter = new HeaderTextFilterModel(TextManager.tMatHang_TenMatHangIn, nameof(tMatHangDto.TenMatHangIn), typeof(string));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tMatHang_TenantID, nameof(tMatHangDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tMatHang_CreateTime, nameof(tMatHangDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tMatHang_LastUpdateTime, nameof(tMatHangDto.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaLoaiFilter);
            AddHeaderFilter(_TenMatHangFilter);
            AddHeaderFilter(_SoKyFilter);
            AddHeaderFilter(_SoMetFilter);
            AddHeaderFilter(_TenMatHangDayDuFilter);
            AddHeaderFilter(_TenMatHangInFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<rLoaiHangDto>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(tMatHangDto dto)
        {
            dto.MaLoaiDataSource = ReferenceDataManager<rLoaiHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(tMatHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaLoaiFilter.FilterValue != null)
            {
                dto.MaLoai = (int)_MaLoaiFilter.FilterValue;
            }
            if (_TenMatHangFilter.FilterValue != null)
            {
                dto.TenMatHang = (string)_TenMatHangFilter.FilterValue;
            }
            if (_SoKyFilter.FilterValue != null)
            {
                dto.SoKy = (int)_SoKyFilter.FilterValue;
            }
            if (_SoMetFilter.FilterValue != null)
            {
                dto.SoMet = (int)_SoMetFilter.FilterValue;
            }
            if (_TenMatHangDayDuFilter.FilterValue != null)
            {
                dto.TenMatHangDayDu = (string)_TenMatHangDayDuFilter.FilterValue;
            }
            if (_TenMatHangInFilter.FilterValue != null)
            {
                dto.TenMatHangIn = (string)_TenMatHangInFilter.FilterValue;
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
