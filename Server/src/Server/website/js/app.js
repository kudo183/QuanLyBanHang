(function () {
    var log = window.huypq.log || function (text) { };
    //var log = console.log;
    var info = console.log;

    $("body").append('<div id="loginView"></div>', '<div id="mainView"></div>');
    $("#mainView").append('<div id="headerContent"></div>', '<div id="mainContent"></div>');

    window.tokenKey = "accessToken";
    var token = window.localStorage.getItem(window.tokenKey);

    log("app token: " + token);

    window.app.view.mainView.init();
    window.app.view.loginView.init();

    if (token) {
        window.app.view.mainView.show();
    } else {
        window.app.view.loginView.show();
    }
})();