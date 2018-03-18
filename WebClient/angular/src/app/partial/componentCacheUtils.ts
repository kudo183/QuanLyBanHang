export class ComponentCacheUtils {

    static require(comp, cacheProperty, entityName, dataService, id, callback) {
        if (id === undefined || id === null || id == '') {
            callback(undefined);
            return;
        }

        comp.cache[cacheProperty] = comp.cache[cacheProperty] || {};
        let cache = comp.cache[cacheProperty];

        let item;
        item = cache.find(p => p.id === id);

        if (item !== undefined) {
            callback(item);
        } else {
            dataService.getByID(entityName, id).subscribe(item => {
                cache.push(item);
                callback(item);
            });
        }
    }

    static requireDonHang(comp, dataService, id, callback) {
        this.require(comp, 'donHangs', 'tdonhang', dataService, id, callback);
    }

    static requireNhapHang(comp, dataService, id, callback) {
        this.require(comp, 'nhapHangs', 'tnhaphang', dataService, id, callback);
    }

    static requireChuyenHang(comp, dataService, id, callback) {
        this.require(comp, 'chuyenHangs', 'tchuyenhang', dataService, id, callback);
    }

    static requireChuyenHangDonHang(comp, dataService, id, callback) {
        this.require(comp, 'chdhs', 'tchuyenhangdonhang', dataService, id, callback);
    }

    static requireChiTietDonHang(comp, dataService, id, callback) {
        this.require(comp, 'ctdhs', 'tchitietdonhang', dataService, id, callback);
    }

    static set(comp, cacheProperty, value) {
        comp.cache = comp.cache || {};
        comp.cache[cacheProperty] = value;
    }

    static setDonHang(comp, value) {
        this.set(comp, 'donHangs', value);
    }
    
    static setNhapHang(comp, value) {
        this.set(comp, 'nhapHangs', value);
    }
    
    static setChuyenHang(comp, value) {
        this.set(comp, 'chuyenHangs', value);
    }
    
    static setChuyenHangDonHang(comp, value) {
        this.set(comp, 'chdhs', value);
    }
    
    static setChiTietDonHang(comp, value) {
        this.set(comp, 'ctdhs', value);
    }
}