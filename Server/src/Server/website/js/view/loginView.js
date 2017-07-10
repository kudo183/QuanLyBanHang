window.app.view.loginView = (function (utilsDOM) {

    var loginView = {
        show: show,
        init: init,
        viewModel: {}
    };
    return loginView;

    function show() {
        $("#loginView").show();
        $("#mainView").hide();

        loginView.viewModel.password(undefined);
    }

    function init() {
        createViewContent("#loginView");
        loginView.viewModel = window.app.viewModel.loginViewModel.create();

        ko.applyBindings(loginView.viewModel, $("#loginView")[0]);
    }

    function createViewContent(viewId) {
        $(viewId).append(utilsDOM.createElement("input", { id: "tenant", type: "text", placeholder: "Tenant name" }, "textInput: tenant"));
        $(viewId).append(utilsDOM.createElement("input", { id:"email", type: "text", placeholder: "Email" }, "textInput: email"));
        $(viewId).append(utilsDOM.createElement("input", { id:"password", type: "password", placeholder: "Password" }, "textInput: password"));
        $(viewId).append(utilsDOM.createElement("button", {}, "click: loginAction", "Login"));
    }
})(window.huypq.control.utilsDOM);