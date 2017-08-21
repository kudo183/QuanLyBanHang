﻿using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class tToaHangViewModel : BaseViewModel<tToaHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(tToaHangDto dto);
        partial void ProcessNewAddedDtoPartial(tToaHangDto dto);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _MaKhachHangFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public tToaHangViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.tToaHang_ID, nameof(tToaHangDto.ID), typeof(int));
            _NgayFilter = new HeaderDateFilterModel(TextManager.tToaHang_Ngay, nameof(tToaHangDto.Ngay), typeof(System.DateTime));
            _MaKhachHangFilter = new HeaderComboBoxFilterModel(
                TextManager.tToaHang_MaKhachHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(tToaHangDto.MaKhachHang),
                typeof(int),
                nameof(rKhachHangDto.DisplayText),
                nameof(rKhachHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaKhachHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.rKhachHangView(), "rKhachHang", ReferenceDataManager<rKhachHangDto>.Instance.LoadOrUpdate)),
                ItemSource = ReferenceDataManager<rKhachHangDto>.Instance.Get()
            };
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tToaHang_TenantID, nameof(tToaHangDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tToaHang_CreateTime, nameof(tToaHangDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tToaHang_LastUpdateTime, nameof(tToaHangDto.LastUpdateTime), typeof(long));

            _NgayFilter.IsSorted = HeaderFilterBaseModel.SortDirection.Descending;

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_MaKhachHangFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<rKhachHangDto>.Instance.LoadOrUpdate();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(tToaHangDto dto)
        {
            dto.MaKhachHangDataSource = ReferenceDataManager<rKhachHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(tToaHangDto dto)
        {
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dto.Ngay = (System.DateTime)_NgayFilter.FilterValue;
            }
            if (_MaKhachHangFilter.FilterValue != null)
            {
                dto.MaKhachHang = (int)_MaKhachHangFilter.FilterValue;
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
