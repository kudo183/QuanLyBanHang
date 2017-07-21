window.app.view.mainView = (function (viewManager) {

    var mainView = {
        show: show,
        init: init
    };
    return mainView;

    function show() {
        $("#mainView").show();
        $("#loginView").hide();

        var view = window.params.v || "tonKhoView";
        viewManager.setCurrentView(view);
    }

    function init() {
        var headerMenuViewModel = {
            items: [
                { text: "Ton kho", value: "tonKhoView", id: "" },
            ],
            selectedItemText: ko.observable(),
            selectedItemValue: ko.observable(),
            buttons: [
                {
                    text: "",
                    id: "refreshButton",
                    action: function () {
                        viewManager.loadCurrentView();
                    }
                },
                {
                    text: "&#x2716;",
                    id: "exitButton",
                    action: function () {
                        window.localStorage.removeItem(window.tokenKey);
                        window.app.view.loginView.show();
                    }
                }
            ]
        };

        viewManager.init("#headerContent", "#mainContent", headerMenuViewModel);
    }
})(window.app.view.viewManager);