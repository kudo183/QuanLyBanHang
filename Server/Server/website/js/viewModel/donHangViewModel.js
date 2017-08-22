window.app.viewModel.donHangViewModel = (function (referenceDataManager) {
    
    var viewModel = huypq.control.dataGrid.createViewModel(window.app.dataProvider.create({
        keyProperty: "id",
        controller: "tdonhang",
        itemProperties: [
            { name: "id", type: "int" },
            { name: "ngay", type: "date" },
            { name: "maKhachHang", type: "int" },
            { name: "maKhoHang", type: "int" },
            { name: "tenantID", type: "int" },
            { name: "state", type: "int" }
        ],
        itemsSources: [
            { name: "maKhachHangItemsSource", controller: "rkhachhang" },
            { name: "maKhoHangItemsSource", controller: "rkhohang" }
        ],
    }, window.app.webApi, referenceDataManager));

    viewModel.addColumn({
        headerText: "Mã",
        type: "span",
        cellValueProperty: "id",
        readOnly: true,
        order: 0,
        filterValue: ko.observable(),
        whereType: "huypq.QueryBuilder.WhereExpression+WhereOptionInt, huypq.QueryBuilder"
    });

    viewModel.addColumn({
        headerText: "Ngày",
        type: "date",
        cellValueProperty: "ngay",
        readOnly: false,
        order: -1,
        filterValue: ko.observable(huypq.dateTimeUtils.getCurrentDate()),
        whereType: "huypq.QueryBuilder.WhereExpression+WhereOptionDate, huypq.QueryBuilder"
    });

    viewModel.addColumn({
        headerText: "Khách hàng",
        type: "comboBox",
        cellValueProperty: "maKhachHang",
        itemsSourceName: "maKhachHangItemsSource",
        itemText: "tenKhachHang",
        itemValue: "id",
        readOnly: false,
        order: 0,
        filterValue: ko.observable(),
        filterItemsSource: referenceDataManager.get("rkhachHang"),
        whereType: "huypq.QueryBuilder.WhereExpression+WhereOptionInt, huypq.QueryBuilder"
    });

    viewModel.addColumn({
        headerText: "Kho hàng",
        type: "comboBox",
        cellValueProperty: "maKhoHang",
        itemsSourceName: "maKhoHangItemsSource",
        itemText: "tenKho",
        itemValue: "id",
        readOnly: false,
        order: 0,
        filterValue: ko.observable(),
        filterItemsSource: referenceDataManager.get("rkhoHang"),
        whereType: "huypq.QueryBuilder.WhereExpression+WhereOptionInt, huypq.QueryBuilder"
    });
    
    viewModel.init = function() {
        if (viewModel.initialized === true)
            return;

        viewModel.initialized = true;
        
        viewModel.load(viewModel);
    };
    return viewModel;
})(window.app.referenceDataManager);