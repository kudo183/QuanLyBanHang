window.app.view.viewManagerLog = window.app.view.viewManagerLog || function (logLevel, msg) {
    if (logLevel === "INFO") {
        console.log(msg);
    } else if (typeof (window.huypq.log) !== "undefined") {
        window.huypq.log(msg);
    }
};

window.app.view.viewManager = (function (logger) {
    
    var viewManager = {
        _headerMenuViewModel: {},
        _currentViewName: "",
        _currentViewModel: {},
        _mainContentId: "",
        _isSkipPushState: false
    };

    viewManager.init = function (headerContentId, mainContentId, headerMenuViewModel) {

        this._headerMenuViewModel = headerMenuViewModel;
        this._mainContentId = mainContentId;

        $(headerContentId).append(window.huypq.control.headerMenu.createView("headerMenuView", headerMenuViewModel));

        headerMenuViewModel.selectedItemValue.subscribe(handleMenuSelectedItemChanged);

        window.onpopstate = function (event) {
            viewManager.setCurrentView(event.state.selectedView);
            logger("onpopstate: " + JSON.stringify(event.state));
        };
    }

    viewManager.setCurrentView = function (selectedView) {
        var selectedIndex = findSelectedItemValueIndex(selectedView, this._headerMenuViewModel.items);
        if (selectedIndex < 0) {
            return;
        }

        this._isSkipPushState = true;
        this._headerMenuViewModel.selectedItemText(this._headerMenuViewModel.items[selectedIndex].text);
        this._headerMenuViewModel.selectedItemValue(this._headerMenuViewModel.items[selectedIndex].value);
        this._isSkipPushState = false;
    }

    viewManager.loadCurrentView = function () {
        viewManager._currentViewModel.load(viewManager._currentViewModel);
    }

    return viewManager;

    function appendCurrentViewToMainContent() {
        var view = window.app.view[viewManager._currentViewName](viewManager._currentViewName);
        $(viewManager._mainContentId).append(view);
        ko.applyBindings(viewManager._currentViewModel, view);
    }

    function handleMenuSelectedItemChanged(selectedItemValue) {
        if (window.app.view[viewManager._currentViewName] !== undefined) {
            $("#" + viewManager._currentViewName).hide();
        }

        viewManager._currentViewName = selectedItemValue;
        logger("INFO", "viewManager currentViewName: " + viewManager._currentViewName)

        if (window.app.view[viewManager._currentViewName] === undefined) {
            throw new Error("View not exist: " + viewManager._currentViewName);
        }

        viewManager._currentViewModel = window.app.viewModel[viewManager._currentViewName + "Model"];
        if (viewManager._currentViewModel.initialized === undefined
            || viewManager._currentViewModel.initialized === false) {
            appendCurrentViewToMainContent();
            viewManager._currentViewModel.init();
        }

        $("#" + viewManager._currentViewName).show();

        if (viewManager._isSkipPushState === false) {
            window.history.pushState({ selectedView: selectedItemValue }, "", "?v=" + selectedItemValue);
            logger("pushState: " + JSON.stringify(selectedItemValue));
        }
    }

    function findSelectedItemValueIndex(selectedItemValue, items) {
        var selectedIndex = -1;
        for (var i = 0; i < items.length; i++) {
            var item = items[i];
            if (item.value === selectedItemValue) {
                selectedIndex = i;
                break;
            }
        }
        return selectedIndex;
    }
})(window.app.view.viewManagerLog);