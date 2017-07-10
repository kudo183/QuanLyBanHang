window.app.dataProvider.tonKhoDataProvider = (function (webApi, referenceDataManager) {
    var dataProvider = {
        _items: [],
        getItemsAjax: getItemsAjax,
    };

    return dataProvider;

    function getItemsAjax(filter, done, fail) {
        filter.orderOptions = [{ propertyPath: "MaMatHangNavigation.TenMatHangDayDu", isAscending: true }];
        filter.pageIndex = 0;

        $.when(
            webApi.getData("ttonKho", filter),
            referenceDataManager.get("rloaiHang", { orderOptions: [{ propertyPath: "TenLoai", isAscending: true }] }),
            referenceDataManager.get("tmatHang"),
            referenceDataManager.get("rkhoHang", { orderOptions: [{ propertyPath: "TenKho", isAscending: true }] }),
            referenceDataManager.get("rcanhBaoTonKho")
        ).done(function (tonKhos, loaiHangs, matHangs, khoHangs, canhBaoTonKhos) {
            var canhBaoTonKho = {};
            var data = canhBaoTonKhos[0].items;
            for (var i = 0; i < data.length; i++) {
                canhBaoTonKho[data[i].maKhoHang] = canhBaoTonKho[data[i].maKhoHang] || {};

                canhBaoTonKho[data[i].maKhoHang][data[i].maMatHang] = {
                    tonCaoNhat: data[i].tonCaoNhat,
                    tonThapNhat: data[i].tonThapNhat,
                };
            }

            var matHang = {};
            var dataMatHang = matHangs[0].items;
            for (var i = 0; i < dataMatHang.length; i++) {
                matHang[dataMatHang[i].ma] = dataMatHang[i].tenMatHangDayDu;
            }

            var result = {
                items: [],
                totalItemCount: tonKhos[0].TotalItemCount,
                pageIndex: tonKhos[0].PageIndex,
                pageCount: tonKhos[0].PageCount
            };
            var tonKhoItems = tonKhos[0].items;
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

            result.comboBoxItemsSource = {};
            result.comboBoxItemsSource.loaiHangs = loaiHangs[0].items;
            result.comboBoxItemsSource.khoHangs = khoHangs[0].items;
            done(result);
        }).fail(fail);
    }
})(window.app.webApi, window.app.referenceDataManager);