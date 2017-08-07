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
    var keyProperty = "ma";
    referenceDataManager._cache["rloaiHang"] = {
        data: ko.observableArray(),
        isLoaded: false,
        keyProperty: keyProperty,
        sortProperty: "tenLoai",
        isAscending: true
    };

    referenceDataManager._cache["tmatHang"] = {
        data: ko.observableArray(),
        isLoaded: false,
        keyProperty: keyProperty,
        sortProperty: "tenMatHang",
        isAscending: true
    };

    referenceDataManager._cache["rkhoHang"] = {
        data: ko.observableArray(),
        isLoaded: false,
        keyProperty: keyProperty,
        sortProperty: "tenKho",
        isAscending: true
    };

    referenceDataManager.getCache = function (name) {
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

    referenceDataManager.get = function (name) {
        return referenceDataManager.getCache(name).data;
    }

    referenceDataManager.loadOrUpdate = function (name) {
        var deferred = new $.Deferred();

        var cache = referenceDataManager.getCache(name);
        if (cache.isLoaded === true) {
            logger("INFO", "referenceDataManager cache hit: " + name);
            var filter = {
                whereOptions: [{
                    $type: "huypq.QueryBuilder.WhereExpression+WhereOptionLong, huypq.QueryBuilder",
                    predicate: ">",
                    propertyPath: "LastUpdateTime",
                    value: cache.lastUpdateTime
                }]
            };
            webApi.getUpdate(name, filter)
                .done(function (data, textStatus, jqXHR) {
                    logger("INFO", "getUpdate done: update data");
                    cache.lastUpdateTime = data.lastUpdateTime;
                    for (var i = 0; i < data.items.length; i++) {
                        var item = data.items[i];
                        if (item.state === 1) {//Add
                            cache.data.push(item);
                        } else if (item.state === 2) {//Delete
                            for (var j = 0; j < cache.data.length; j++) {
                                if (cache.data[j][cache.keyProperty] === item[cache.keyProperty]){
                                    cache.data.splice(j, 1);
                                    break;
                                }
                            }
                        } else if (item.state === 3) {//Update
                            for (var j = 0; j < cache.data.length; j++) {
                                if (cache.data[j][cache.keyProperty] === item[cache.keyProperty]) {
                                    //TODO: update item
                                    break;
                                }
                            }
                        }
                    }
                    deferred.resolve(data, textStatus, jqXHR);
                })
                .fail(function (error) {
                    deferred.reject(error);
                });
        } else {
            webApi.getAll(name)
                .done(function (data, textStatus, jqXHR) {
                    logger("INFO", "referenceDataManager cache miss: " + name);
                    cache.isLoaded = true;
                    cache.lastUpdateTime = data.lastUpdateTime;
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