window.app.view.tonKhoView = (function () {
    return function (id) {
        var view = window.huypq.control.dataGrid.createView(id, {
            hasCustomFilter: true,
            hasColumnHeader: false,
            hasColumnFilter: false,
            hasBottomToolbar: false
        }, "row");
        return view;
    };
})();