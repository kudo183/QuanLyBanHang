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
        getData: getData,
        _cache: {}
    };
    return webApi;

    //function apiUrl(controller, action) { return "/" + controller + "/" + action; }
    function apiUrl(controller, action) { return "http://localhost:5000/" + controller + "/" + action; }

    function getApiUrl(controller) { return apiUrl(controller, "get"); }

    function getData(controller, json) {
        var url = getApiUrl(controller);
        json = json || {};
        var jsonString = JSON.stringify(json);

        var deferred = new $.Deferred();

        var cacheKey = controller + '_' + jsonString;
        logger("webApi cacheKey: " + cacheKey);

        var cacheData = webApi._cache[cacheKey];
        var versionNumber = 0;
        var serverStartTime = 0;
        if (cacheData !== undefined) {
            versionNumber = cacheData.versionNumber;
            serverStartTime = cacheData.serverStartTime;
            if (jsonString.length < 3) {
                jsonString = "{\"versionNumber\":" + versionNumber + ",\"serverStartTime\":" + serverStartTime + "}";
            } else {
                jsonString = "{\"versionNumber\":" + versionNumber + ",\"serverStartTime\":" + serverStartTime + "," + jsonString.substr(1);
            }
        }

        postJson(url, jsonString)
            .done(function (data, textStatus, jqXHR) {
                if (versionNumber === data.versionNumber && serverStartTime === data.serverStartTime) {
                    logger("INFO", "webApi cache hit " + controller + "   " + versionNumber);

                    deferred.resolve(JSON.parse(cacheData.jsonStringData), cacheData.textStatus, cacheData.jqXHR);
                } else {
                    logger("INFO", "webApi cache miss " + controller + "   " + data.versionNumber);
                    webApi._cache[cacheKey] = {
                        serverStartTime: data.serverStartTime,
                        versionNumber: data.versionNumber,
                        jsonStringData: JSON.stringify(data),
                        textStatus: textStatus,
                        jqXHR: jqXHR
                    };

                    deferred.resolve(data, textStatus, jqXHR);
                }
            })
            .fail(function (error) {
                deferred.reject(error);
            });

        return deferred;
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