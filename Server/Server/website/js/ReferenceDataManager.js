window.app.referenceDataManagerLog = window.app.referenceDataManagerLog || function (logLevel, msg) {
    if (logLevel === "INFO") {
        console.log(msg);
    } else if (typeof (window.huypq.log) !== "undefined") {
        window.huypq.log(msg);
    }
};

window.app.referenceDataManager = (function (webApi, logger) {

    var referenceDataManager = {
        _cache: {}
    };

    referenceDataManager.get = function (name, filter) {
        var deferred = new $.Deferred();

        var cacheData = referenceDataManager._cache[name];
        if (cacheData !== undefined) {
            logger("INFO", "referenceDataManager cache hit: " + name);
            deferred.resolve(cacheData.data, cacheData.textStatus, cacheData.jqXHR);
        } else {
            webApi.getData(name, filter)
                .done(function (data, textStatus, jqXHR) {
                    logger("INFO", "referenceDataManager cache miss: " + name);
                    referenceDataManager._cache[name] = {
                        data: data,
                        textStatus: textStatus,
                        jqXHR: jqXHR
                    };
                    deferred.resolve(data, textStatus, jqXHR);
                })
                .fail(function (error) {
                    deferred.reject(error);
                });
        }

        return deferred;
    }

    return referenceDataManager;
})(window.app.webApi, window.app.referenceDataManagerLog);