window.app.viewModel.tonKhoViewModel = (function () {
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
        filterValue: ko.observable(f.tk),
        whereType: "QueryBuilder.WhereExpression+WhereOptionInt, QueryBuilder"
    };

    var filterNgay = {
        type: "date",
        propertyPath: "Ngay",
        filterValue: ko.observable(f.d),
        whereType: "QueryBuilder.WhereExpression+WhereOptionDate, QueryBuilder"
    };

    var filterLoaiHang = {
        type: "comboBox",
        propertyPath: "MaMatHangNavigation.MaLoai",
        itemsSourceName: "loaiHangs",
        itemText: "tenLoai",
        itemValue: "ma",
        filterValue: ko.observable(f.ml),
        whereType: "QueryBuilder.WhereExpression+WhereOptionInt, QueryBuilder"
    };

    viewModel.addCustomFilters([filterKhoHang, filterNgay, filterLoaiHang]);

    viewModel.init = function () {
        if (viewModel.initialized === true)
            return;

        viewModel.initialized = true;

        viewModel.load(viewModel);
    };

    return viewModel;
})();