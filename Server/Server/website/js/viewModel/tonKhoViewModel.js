window.app.viewModel.tonKhoViewModel = (function (referenceDataManager) {
    var viewModel = huypq.control.dataGrid.createViewModel(
        window.app.dataProvider.tonKhoDataProvider,
        {
            hasDeleteButton: false
        }
    );

    viewModel.addColumn({
        headerText: "",
        type: "span",
        cellValueProperty: "tenMatHang",
        readOnly: false,
        order: 0,
        filterValue: ko.observable()
    });

    viewModel.addColumn({
        headerText: "",
        type: "span",
        cellValueProperty: "soLuong",
        readOnly: false,
        order: 0,
        filterValue: ko.observable()
    });

    var f = {
        tk: 1,
        d: huypq.dateTimeUtils.getCurrentDate(),
        ml: 1
    }

    var filterKhoHang = {
        type: "comboBox",
        propertyPath: "MaKhoHang",
        itemsSourceName: "khoHangs",
        itemText: "tenKho",
        itemValue: "ma",
        itemsSource: referenceDataManager.get("rkhoHang"),
        filterValue: ko.observable(f.tk),
        whereType: "huypq.QueryBuilder.WhereExpression+WhereOptionInt, huypq.QueryBuilder"
    };

    var filterNgay = {
        type: "date",
        propertyPath: "Ngay",
        filterValue: ko.observable(f.d),
        whereType: "huypq.QueryBuilder.WhereExpression+WhereOptionDate, huypq.QueryBuilder"
    };

    var filterLoaiHang = {
        type: "comboBox",
        propertyPath: "MaMatHangNavigation.MaLoai",
        itemsSourceName: "loaiHangs",
        itemText: "tenLoai",
        itemValue: "ma",
        itemsSource: referenceDataManager.get("rloaiHang"),
        filterValue: ko.observable(f.ml),
        whereType: "huypq.QueryBuilder.WhereExpression+WhereOptionInt, huypq.QueryBuilder"
    };

    viewModel.addCustomFilters([filterKhoHang, filterNgay, filterLoaiHang]);

    viewModel.init = function () {
        if (viewModel.initialized === true)
            return;

        viewModel.initialized = true;

        viewModel.load(viewModel);
    };

    return viewModel;
})(window.app.referenceDataManager);