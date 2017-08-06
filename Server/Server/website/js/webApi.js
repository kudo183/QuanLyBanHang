window.app.webApiLog = window.app.webApiLog || function (logLevel, msg) {
    if (logLevel === "INFO") {
        console.log(msg);
    } else if (typeof(window.huypq.log) !== "undefined") {
        window.huypq.log(msg);
    }
};

window.app.webApi = (function (logger) {
    var webApi = {
        login: {
            tenant: function (params) {
                return postParams(apiUrl("smt", "tenantlogin"), params);
            },
            user: function (params) {
                return postParams(apiUrl("smt", "userlogin"), params);
            }
        },
        get: get,
        getAll: getAll,
        getUpdate: getUpdate
    };
    return webApi;

    //function apiUrl(controller, action) { return "/" + controller + "/" + action; }
    function apiUrl(controller, action) { return window.rootUri + controller + "/" + action; }
    
    function get(controller, json) {
        var url = apiUrl(controller, "get");
        json = json || {};
        var jsonString = JSON.stringify(json);
        return postJson(url, jsonString);
    }

    function getAll(controller, json) {
        var url = apiUrl(controller, "getAll");
        json = json || {};
        var jsonString = JSON.stringify(json);
        return postJson(url, jsonString);
    }

    function getUpdate(controller, json) {
        var url = apiUrl(controller, "getUpdate");
        json = json || {};
        var jsonString = JSON.stringify(json);
        return postJson(url, jsonString);
    }

    function postJson(url, jsonString) {
        logger("INFO", "webApi postJson: " + url + " " + jsonString);
        var options = {
            dataType: "json",
            contentType: "application/json",
            cache: false,
            type: "post",
            data: jsonString
        };

        var token = window.localStorage.getItem(window.tokenKey);

        if (token) {
            options.headers = {
                'token': token
            };
        }
        return $.ajax(url, options);
    }

    function postParams(url, params) {
        logger("INFO", "webApi postParams: " + url + " " + JSON.stringify(params));
        var options = {
            dataType: "json",
            contentType: "application/x-www-form-urlencoded",
            cache: false,
            type: "post",
            data: params
        };

        var token = window.localStorage.getItem(window.tokenKey);

        if (token) {
            options.headers = {
                'token': token
            };
        }
        return $.ajax(url, options);
    }
})(window.app.webApiLog);