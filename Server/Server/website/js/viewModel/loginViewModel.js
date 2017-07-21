window.app.viewModel.loginViewModel = (function (webApi) {

    var loginViewModel = {
        create: create
    };
    return loginViewModel;

    function create() {
        var viewModel = {
            email: ko.observable("huy"),
            password: ko.observable(),
            tenant: ko.observable(""),
            loginAction: function (model) {
                if (model.tenant() === "") {
                    webApi.login.tenant({ user: model.email(), pass: model.password() })
                        .done(function (token) {
                            window.localStorage.setItem(window.tokenKey, token);
                            window.app.view.mainView.show();
                        })
                        .fail(function (msg) {
                            console.log("fail: " + JSON.stringify(msg));
                        });
                } else {
                    webApi.login.user({ tenant: model.tenant(), user: model.email(), pass: model.password() })
                        .done(function (token) {
                            window.localStorage.setItem(window.tokenKey, token);
                            window.app.view.mainView.show();
                        })
                        .fail(function (msg) {
                            console.log("fail: " + JSON.stringify(msg));
                        });
                }
            }
        };
        return viewModel;
    }
})(window.app.webApi);