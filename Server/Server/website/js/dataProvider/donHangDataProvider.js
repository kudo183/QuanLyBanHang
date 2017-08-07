window.app.dataProvider.donHangDataProvider = (function (webApi, referenceDataManager) {
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
        return item.ma;
    }

    function setItemId(item, newId) {
        item.ma(newId);
    }

    function toDto(item) {
        return {
            ma: ko.unwrap(item.ma),
            tenantID: item.tenantID,
            ngay: ko.unwrap(item.ngay),
            maKhachHang: ko.unwrap(item.maKhachHang),
            maKhoHang: ko.unwrap(item.maKhoHang),
            state: item.state
        };
    }

    function processNewAddedItem(item) {
        item.maKhoHangItemsSource = referenceDataManager.get("rkhoHang");
        item.maKhachHangItemsSource = referenceDataManager.get("rkhachHang");
    }

    function getItemsAjax(filter, done, fail) {
        filter.pageSize = filter.pageSize || 30;

        if (dataProvider._needLoadReferenceData === true) {
            dataProvider._needLoadReferenceData = false;
            $.when(
                webApi.get("tdonhang", filter),
                referenceDataManager.loadOrUpdate("rkhachHang"),
                referenceDataManager.loadOrUpdate("rkhoHang")
            ).done(function (donHangs) {
                done(processResponseData(
                    donHangs[0],
                    referenceDataManager.get("rkhachHang"),
                    referenceDataManager.get("rkhoHang"))
                );
            }).fail(fail);
        } else {
            webApi.get("tdonhang", filter)
                .done(function (donHangs) {
                    done(processResponseData(
                        donHangs,
                        referenceDataManager.get("rkhachHang"),
                        referenceDataManager.get("rkhoHang"))
                    );
                })
                .fail(fail)
        }
    }

    function saveChangesAjax(changes, done, fail) {
        if (changes.length > 0) {
            console.log("changes: " + JSON.stringify(changes));
            webApi.save("tdonhang", changes)
                .done(done)
                .fail(fail);
        }
    }

    function processResponseData(donHangs, khachHangItems, khoHangItems) {
        var result = {
            items: [],
            totalItemCount: donHangs.totalItemCount,
            pageIndex: donHangs.pageIndex,
            pageCount: donHangs.pageCount
        };
        var donHangItems = donHangs.items;
        for (var i = 0; i < donHangItems.length; i++) {
            var item = donHangItems[i];
            result.items.push({
                ma: ko.observable(item.ma),
                tenantID: item.tenantID,
                ngay: ko.observable(huypq.dateTimeUtils.createUTCDate(item.ngay)),
                maKhachHang: ko.observable(item.maKhachHang),
                maKhoHang: ko.observable(item.maKhoHang),
                maKhoHangItemsSource: khoHangItems,
                maKhachHangItemsSource: khachHangItems
            });
        }

        return result;
    }
})(window.app.webApi, window.app.referenceDataManager);