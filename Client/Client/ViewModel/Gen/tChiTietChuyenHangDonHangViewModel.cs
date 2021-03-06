﻿using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using huypq.wpf.Utils;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using Client.DataModel;
using System.Collections.Generic;
using huypq.SmtShared;
using System.Linq;

namespace Client.ViewModel
{
    public partial class tChiTietChuyenHangDonHangViewModel : BaseViewModel<tChiTietChuyenHangDonHangDto, tChiTietChuyenHangDonHangDataModel>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDataModelBeforeAddToEntitiesPartial(tChiTietChuyenHangDonHangDataModel dataModel);
        partial void ProcessNewAddedDataModelPartial(tChiTietChuyenHangDonHangDataModel dataModel);
        partial void AfterLoadPartial();

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaChuyenHangDonHangFilter;
        HeaderFilterBaseModel _MaChiTietDonHangFilter;
        HeaderFilterBaseModel _SoLuongFilter;
        HeaderFilterBaseModel _SoLuongTheoDonHangFilter;
        HeaderFilterBaseModel _TenantIDFilter;
        HeaderFilterBaseModel _CreateTimeFilter;
        HeaderFilterBaseModel _LastUpdateTimeFilter;
        Dictionary<int, tChuyenHangDonHangDataModel> _MaChuyenHangDonHangs;
        Dictionary<int, tChiTietDonHangDataModel> _MaChiTietDonHangs;

        public tChiTietChuyenHangDonHangViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenHangDonHang_ID, nameof(tChiTietChuyenHangDonHangDataModel.ID), typeof(int));
            _MaChuyenHangDonHangFilter = new HeaderForeignKeyFilterModel(TextManager.tChiTietChuyenHangDonHang_MaChuyenHangDonHang, nameof(tChiTietChuyenHangDonHangDataModel.MaChuyenHangDonHang), typeof(int), new View.tChuyenHangDonHangView() { KeepSelectionType = DataGridExt.KeepSelection.KeepSelectedValue });
            _MaChiTietDonHangFilter = new HeaderForeignKeyFilterModel(TextManager.tChiTietChuyenHangDonHang_MaChiTietDonHang, nameof(tChiTietChuyenHangDonHangDataModel.MaChiTietDonHang), typeof(int), new View.tChiTietDonHangView() { KeepSelectionType = DataGridExt.KeepSelection.KeepSelectedValue });
            _SoLuongFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenHangDonHang_SoLuong, nameof(tChiTietChuyenHangDonHangDataModel.SoLuong), typeof(int));
            _SoLuongTheoDonHangFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenHangDonHang_SoLuongTheoDonHang, nameof(tChiTietChuyenHangDonHangDataModel.SoLuongTheoDonHang), typeof(int));
            _TenantIDFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenHangDonHang_TenantID, nameof(tChiTietChuyenHangDonHangDataModel.TenantID), typeof(int));
            _CreateTimeFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenHangDonHang_CreateTime, nameof(tChiTietChuyenHangDonHangDataModel.CreateTime), typeof(long));
            _LastUpdateTimeFilter = new HeaderTextFilterModel(TextManager.tChiTietChuyenHangDonHang_LastUpdateTime, nameof(tChiTietChuyenHangDonHangDataModel.LastUpdateTime), typeof(long));


            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaChuyenHangDonHangFilter);
            AddHeaderFilter(_MaChiTietDonHangFilter);
            AddHeaderFilter(_SoLuongFilter);
            AddHeaderFilter(_SoLuongTheoDonHangFilter);
            AddHeaderFilter(_TenantIDFilter);
            AddHeaderFilter(_CreateTimeFilter);
            AddHeaderFilter(_LastUpdateTimeFilter);
        }

        protected override void AfterLoad()
        {
            _MaChuyenHangDonHangs = DataService.GetByListInt<tChuyenHangDonHangDto, tChuyenHangDonHangDataModel>(nameof(IDto.ID), Entities.Select(p => p.MaChuyenHangDonHang).ToList()).ToDictionary(p => p.ID);
            _MaChiTietDonHangs = DataService.GetByListInt<tChiTietDonHangDto, tChiTietDonHangDataModel>(nameof(IDto.ID), Entities.Select(p => p.MaChiTietDonHang).ToList()).ToDictionary(p => p.ID);
            foreach (var dataModel in Entities)
            {
                dataModel.MaChuyenHangDonHangNavigation = _MaChuyenHangDonHangs[dataModel.MaChuyenHangDonHang];
                dataModel.MaChiTietDonHangNavigation = _MaChiTietDonHangs[dataModel.MaChiTietDonHang];
            }

            AfterLoadPartial();
        }

        public override void LoadReferenceData()
        {

            LoadReferenceDataPartial();
        }

        protected override void ProcessDataModelBeforeAddToEntities(tChiTietChuyenHangDonHangDataModel dataModel)
        {

            ProcessDataModelBeforeAddToEntitiesPartial(dataModel);
        }

        protected override void ProcessNewAddedDataModel(tChiTietChuyenHangDonHangDataModel dataModel)
        {
            if (_IDFilter.FilterValue != null)
            {
                dataModel.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaChuyenHangDonHangFilter.FilterValue != null)
            {
                dataModel.MaChuyenHangDonHang = (int)_MaChuyenHangDonHangFilter.FilterValue;
            }
            if (_MaChiTietDonHangFilter.FilterValue != null)
            {
                dataModel.MaChiTietDonHang = (int)_MaChiTietDonHangFilter.FilterValue;
            }
            if (_SoLuongFilter.FilterValue != null)
            {
                dataModel.SoLuong = (int)_SoLuongFilter.FilterValue;
            }
            if (_SoLuongTheoDonHangFilter.FilterValue != null)
            {
                dataModel.SoLuongTheoDonHang = (int)_SoLuongTheoDonHangFilter.FilterValue;
            }
            if (_TenantIDFilter.FilterValue != null)
            {
                dataModel.TenantID = (int)_TenantIDFilter.FilterValue;
            }
            if (_CreateTimeFilter.FilterValue != null)
            {
                dataModel.CreateTime = (long)_CreateTimeFilter.FilterValue;
            }
            if (_LastUpdateTimeFilter.FilterValue != null)
            {
                dataModel.LastUpdateTime = (long)_LastUpdateTimeFilter.FilterValue;
            }

            ProcessNewAddedDataModelPartial(dataModel);
            ProcessDataModelBeforeAddToEntities(dataModel);
        }
    }
}
