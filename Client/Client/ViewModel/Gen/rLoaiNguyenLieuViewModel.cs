﻿using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class rLoaiNguyenLieuViewModel : BaseViewModel<rLoaiNguyenLieuDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(rLoaiNguyenLieuDto dto);
        partial void ProcessNewAddedDtoPartial(rLoaiNguyenLieuDto dto);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _TenLoaiFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;

        public rLoaiNguyenLieuViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.rLoaiNguyenLieu_ID, nameof(rLoaiNguyenLieuDto.ID), typeof(int));
            _TenLoaiFilter = new HeaderTextFilterModel(TextManager.rLoaiNguyenLieu_TenLoai, nameof(rLoaiNguyenLieuDto.TenLoai), typeof(string));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.rLoaiNguyenLieu_TenantID, nameof(rLoaiNguyenLieuDto.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.rLoaiNguyenLieu_CreateTime, nameof(rLoaiNguyenLieuDto.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.rLoaiNguyenLieu_LastUpdateTime, nameof(rLoaiNguyenLieuDto.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_TenLoaiFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        public override void LoadReferenceData()
        {

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(rLoaiNguyenLieuDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(rLoaiNguyenLieuDto dto)
        {
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
            }
            if (_TenLoaiFilter.FilterValue != null)
            {
                dto.TenLoai = (string)_TenLoaiFilter.FilterValue;
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
