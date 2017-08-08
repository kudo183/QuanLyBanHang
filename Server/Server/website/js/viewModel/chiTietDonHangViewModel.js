window.app.viewModel.chiTietDonHangViewModel = (function (referenceDataManager) {

    //var viewModel = huypq.control.dataGrid.createViewModel(window.app.dataProvider.chiTietDonHangDataProvider);

    var viewModel = huypq.control.dataGrid.createViewModel(window.app.dataProvider.create({
        keyProperty: "ma",
        controller: "tchitietdonhang",
        itemProperties: [
            { name: "ma", type: "int" },
            { name: "maDonHang", type: "int" },
            { name: "maMatHang", type: "int" },
            { name: "soLuong", type: "int" },
            { name: "xong", type: "bool" },
            { name: "tenantID", type: "int" },
            { name: "state", type: "int" }
        ],
        itemsSources: [
            { name: "maMatHangItemsSource", controller: "tmathang" }
        ],
    }, window.app.webApi, referenceDataManager));

    viewModel.addColumn({
        headerText: "Mã",
        type: "span",
        cellValueProperty: "ma",
        readOnly: true,
        order: 0,
        filterValue: ko.observable(),
        whereType: "huypq.QueryBuilder.WhereExpression+WhereOptionInt, huypq.QueryBuilder"
    });

    viewModel.addColumn({
        headerText: "Mã đơn hàng",
        type: "textBox",
        cellValueProperty: "maDonHang",
        readOnly: false,
        order: 0,
        filterValue: ko.observable(),
        whereType: "huypq.QueryBuilder.WhereExpression+WhereOptionInt, huypq.QueryBuilder"
    });

    viewModel.addColumn({
        headerText: "Mặt hàng",
        type: "comboBox",
        cellValueProperty: "maMatHang",
        itemsSourceName: "maMatHangItemsSource",
        itemText: "tenMatHang",
        itemValue: "ma",
        readOnly: false,
        order: 0,
        filterValue: ko.observable(),
        filterItemsSource: referenceDataManager.get("tMatHang"),
        whereType: "huypq.QueryBuilder.WhereExpression+WhereOptionInt, huypq.QueryBuilder"
    });

    viewModel.addColumn({
        headerText: "Số lượng",
        type: "textBox",
        cellValueProperty: "soLuong",
        readOnly: false,
        order: 0,
        filterValue: ko.observable(),
        whereType: "huypq.QueryBuilder.WhereExpression+WhereOptionInt, huypq.QueryBuilder"
    });

    viewModel.addColumn({
        headerText: "Xong",
        type: "checkBox",
        cellValueProperty: "xong",
        readOnly: true,
        order: 0,
        filterValue: ko.observable(),
        whereType: "huypq.QueryBuilder.WhereExpression+WhereOptionBool, huypq.QueryBuilder"
    });

    viewModel.init = function () {
        if (viewModel.initialized === true)
            return;

        viewModel.initialized = true;

        viewModel.load(viewModel);
    };
    return viewModel;
})(window.app.referenceDataManager);