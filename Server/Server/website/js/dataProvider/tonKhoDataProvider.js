window.app.dataProvider.tonKhoDataProvider = (function (webApi, referenceDataManager) {
    var dataProvider = {
        _items: [],
        _needLoadReferenceData: true,
        getItemsAjax: getItemsAjax,
    };

    return dataProvider;

    function getItemsAjax(filter, done, fail) {
        filter.orderOptions = [{ propertyPath: "MaMatHangNavigation.TenMatHangDayDu", isAscending: true }];
        filter.pageIndex = 1;
        filter.pageSize = 30;

        if (dataProvider._needLoadReferenceData === true) {
            dataProvider._needLoadReferenceData = false;
            $.when(
                webApi.get("ttonKho", filter),
                referenceDataManager.loadOrUpdate("rloaiHang"),
                referenceDataManager.loadOrUpdate("tmatHang"),
                referenceDataManager.loadOrUpdate("rkhoHang"),
                referenceDataManager.loadOrUpdate("rcanhBaoTonKho")
            ).done(function (tonKhos) {
                done(processResponseData(
                    tonKhos[0],
                    referenceDataManager.get("rloaiHang"),
                    referenceDataManager.get("tmatHang"),
                    referenceDataManager.get("rkhoHang"),
                    referenceDataManager.get("rcanhBaoTonKho"))
                );
            }).fail(fail);
        } else {
            webApi.get("ttonKho", filter)
                .done(function (tonKhos) {
                    done(processResponseData(
                        tonKhos,
                        referenceDataManager.get("rloaiHang"),
                        referenceDataManager.get("tmatHang"),
                        referenceDataManager.get("rkhoHang"),
                        referenceDataManager.get("rcanhBaoTonKho"))
                    );
                })
                .fail(fail)
        }
    }

    function processResponseData(tonKhos, loaiHangItems, matHangItems, khoHangItems, canhBaoTonKhoItems) {        
        var canhBaoTonKho = {};
        var data = canhBaoTonKhoItems();
        for (var i = 0; i < data.length; i++) {
            canhBaoTonKho[data[i].maKhoHang] = canhBaoTonKho[data[i].maKhoHang] || {};

            canhBaoTonKho[data[i].maKhoHang][data[i].maMatHang] = {
                tonCaoNhat: data[i].tonCaoNhat,
                tonThapNhat: data[i].tonThapNhat,
            };
        }

        var matHang = {};
        var data = matHangItems();
        for (var i = 0; i < data.length; i++) {
            matHang[data[i].ma] = data[i].tenMatHangDayDu;
        }

        var result = {
            items: [],
            totalItemCount: tonKhos.TotalItemCount,
            pageIndex: tonKhos.PageIndex,
            pageCount: tonKhos.PageCount
        };
        var tonKhoItems = tonKhos.items;
        for (var i = 0; i < tonKhoItems.length; i++) {
            var item = tonKhoItems[i];
            var css = "";

            if (canhBaoTonKho[item.maKhoHang] !== undefined
                && canhBaoTonKho[item.maKhoHang][item.maMatHang] !== undefined) {

                var range = canhBaoTonKho[item.maKhoHang][item.maMatHang];
                var soLuong = item.soLuong;

                if (soLuong == 0 && range.tonThapNhat == 0)
                    continue;

                if (soLuong < range.tonThapNhat) {
                    css = "warningLower";
                } else if (soLuong > range.tonCaoNhat) {
                    css = "warningUpper";
                }
            }

            result.items.push({
                tenMatHang: ko.observable(matHang[item.maMatHang]),
                soLuong: ko.observable(item.soLuong),
                css: ko.observable(css)
            });
        }
        
        return result;
    }
})(window.app.webApi, window.app.referenceDataManager);