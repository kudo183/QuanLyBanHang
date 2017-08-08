window.app.dataProvider.create = function (settings, webApi, referenceDataManager) {
    var dataProvider = {
        _items: [],
        _needLoadReferenceData: true,
        getItemId: getItemId,
        setItemId: setItemId,
        toDto: toDto,
        processNewAddedItem: processNewAddedItem,
        getItemsAjax: getItemsAjax,
        saveChangesAjax: saveChangesAjax
    };

    return dataProvider;

    function getItemId(item) {
        return item[settings.keyProperty];
    }

    function setItemId(item, newId) {
        item[settings.keyProperty](newId);
    }

    function toDto(item) {
        var dto = {};
        for (var i = 0; i < settings.itemProperties.length; i++) {
            var propName = settings.itemProperties[i].name;
            dto[propName] = ko.unwrap(item[propName]);
        }
        return dto;
    }

    function processNewAddedItem(item) {
        for (var i = 0; i < settings.itemsSources.length; i++) {
            var itemsSource = settings.itemsSources[i];
            item[itemsSource.name] = referenceDataManager.get(itemsSource.controller);
        }
    }

    function getItemsAjax(filter, done, fail) {
        filter.pageSize = filter.pageSize || 30;

        if (dataProvider._needLoadReferenceData === true) {
            dataProvider._needLoadReferenceData = false;

            var ajax = [];
            ajax.push(webApi.get(settings.controller, filter));
            for (var i = 0; i < settings.itemsSources.length; i++) {
                var itemsSource = settings.itemsSources[i];
                ajax.push(referenceDataManager.loadOrUpdate(itemsSource.controller));
            }
            //$.when(ajax)
            $.when.apply($, ajax)
                .done(function (data) {
                    done(processResponseData(data[0]));
                })
                .fail(fail);
        } else {
            webApi.get(settings.controller, filter)
                .done(function (data) {
                    done(processResponseData(data));
                })
                .fail(fail)
        }
    }

    function saveChangesAjax(changes, done, fail) {
        if (changes.length > 0) {
            webApi.save(settings.controller, changes)
                .done(done)
                .fail(fail);
        }
    }

    function processResponseData(data) {
        var result = {
            items: [],
            totalItemCount: data.totalItemCount,
            pageIndex: data.pageIndex,
            pageCount: data.pageCount
        };
        var dataItems = data.items;
        for (var i = 0; i < dataItems.length; i++) {
            var item = dataItems[i];
            var dto = {};
            for (var j = 0; j < settings.itemProperties.length; j++) {
                var prop = settings.itemProperties[j];
                if (prop.type === "date") {
                    dto[prop.name] = ko.observable(huypq.dateTimeUtils.createUTCDate(item[prop.name]))
                } else {
                    dto[prop.name] = ko.observable(item[prop.name]);
                }
            }
            for (var j = 0; j < settings.itemsSources.length; j++) {
                var itemsSource = settings.itemsSources[j];
                dto[itemsSource.name] = referenceDataManager.get(itemsSource.controller);
            }
            result.items.push(dto);
        }

        return result;
    }
}