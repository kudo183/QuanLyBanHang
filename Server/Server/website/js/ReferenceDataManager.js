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

    referenceDataManager._cache["rloaiHang"] = {
        data: ko.observableArray(),
        isLoaded: false,
        sortProperty: "tenLoai",
        isAscending: true
    };

    referenceDataManager._cache["tmatHang"] = {
        data: ko.observableArray(),
        isLoaded: false,
        sortProperty: "tenMatHang",
        isAscending: true
    };

    referenceDataManager._cache["rkhoHang"] = {
        data: ko.observableArray(),
        isLoaded: false,
        sortProperty: "tenKho",
        isAscending: true
    };

    referenceDataManager.getCache = function (name, filter) {
        var cache = referenceDataManager._cache[name];
        if (cache === undefined) {
            cache = {
                data: ko.observableArray(),
                isLoaded: false
            };
            referenceDataManager._cache[name] = cache;
        }
        return cache;
    }

    referenceDataManager.get = function (name, filter) {
        return referenceDataManager.getCache(name, filter).data;
    }

    referenceDataManager.loadOrUpdate = function (name, filter) {
        var deferred = new $.Deferred();

        var cache = referenceDataManager.getCache(name, filter);
        if (cache.isLoaded === true) {
            logger("INFO", "referenceDataManager cache hit: " + name);
            webApi.getUpdate(name, filter)
                .done(function (data, textStatus, jqXHR) {
                    logger("INFO", "getUpdate done: update data");
                    //TODO: update cache.data
                    deferred.resolve(data, textStatus, jqXHR);
                })
                .fail(function (error) {
                    deferred.reject(error);
                });
        } else {
            webApi.getAll(name, filter)
                .done(function (data, textStatus, jqXHR) {
                    logger("INFO", "referenceDataManager cache miss: " + name);
                    cache.isLoaded = true;
                    cache.data(data.items);
                    if (cache.sortProperty !== undefined) {
                        huypq.arrayUtils.sort(cache.data, cache.sortProperty, cache.isAscending);
                    }
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