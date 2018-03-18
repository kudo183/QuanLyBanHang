import { ComponentCacheUtils } from './componentCacheUtils';

export class DisplayTextUtils {
    static donHang(dh, khoHang, khachHang) {
        const ngay = DisplayTextUtils.formatDate(new Date(dh.ngay));
        return `${dh.id}|${ngay}|${khoHang.tenKho}|${khachHang.tenKhachHang}`;
    }
    static getDonHang(comp, refDataService, dataService, id, callback) {
        refDataService.gets(['rkhohang', 'rkhachhang']).subscribe(refData => {
            ComponentCacheUtils.requireDonHang(comp, dataService, id, dh => {
                const khoHang = refData[0].items.find(p => p.id === dh.maKhoHang);
                const khachHang = refData[1].items.find(p => p.id === dh.maKhachHang);
                callback(DisplayTextUtils.donHang(dh, khoHang, khachHang), dh);
            });
        });
    }
    static chuyenHang(ch, nhanVien) {
        const ngay = DisplayTextUtils.formatDate(new Date(ch.ngay));
        return `${ch.id}|${ngay}|${ch.gio}|${nhanVien.tenNhanVien}`;
    }
    static getChuyenHang(comp, refDataService, dataService, id, callback) {
        ComponentCacheUtils.requireChuyenHang(comp, dataService, id, ch => {
            refDataService.gets(['rnhanvien']).subscribe(refData => {
                const nhanVien = refData[0].items.find(p => p.id === ch.maNhanVienGiaoHang);
                callback(DisplayTextUtils.chuyenHang(ch, nhanVien), ch);
            });
        });
    }
    static chuyenHangDonHang(chdh, ch, dh, nhanVien, khoHang, khachHang) {
        const ngayDH = DisplayTextUtils.formatDate(new Date(dh.ngay));
        const ngayCH = DisplayTextUtils.formatDate(new Date(ch.ngay));
        return `${chdh.id}|${ch.id}|${ngayCH}|${nhanVien.tenNhanVien}|${dh.id}`;//|${ngayDH}|${khoHang.tenKho}|${khachHang.tenKhachHang}`;
    }
    static getChuyenHangDonHang(comp, refDataService, dataService, id, callback) {
        refDataService.gets(['rnhanvien', 'rkhohang', 'rkhachhang']).subscribe(refData => {
            ComponentCacheUtils.requireChuyenHangDonHang(comp, dataService, id, chdh => {
                ComponentCacheUtils.requireChuyenHang(comp, dataService, chdh.maChuyenHang, ch => {
                    ComponentCacheUtils.requireDonHang(comp, dataService, chdh.maDonHang, dh => {
                        const nhanVien = refData[0].items.find(p => p.id === ch.maNhanVienGiaoHang);
                        const khoHang = refData[1].items.find(p => p.id === dh.maKhoHang);
                        const khachHang = refData[2].items.find(p => p.id === dh.maKhachHang);
                        callback(DisplayTextUtils.chuyenHangDonHang(chdh, ch, dh, nhanVien, khoHang, khachHang), chdh)
                    });
                });
            });
        });
    }
    static chiTietDonHang(ctdh, dh, khoHang, khachHang, matHang) {
        const ngay = DisplayTextUtils.formatDate(new Date(dh.ngay));
        return `${ctdh.id}|${dh.id}|${ngay}|${khoHang.tenKho}|${khachHang.tenKhachHang}|${matHang.tenMatHang}`;
    }
    static getChiTietDonHang(comp, refDataService, dataService, id, callback) {
        refDataService.gets(['rkhohang', 'rkhachhang', 'tmathang']).subscribe(refData => {
            ComponentCacheUtils.requireChiTietDonHang(comp, dataService, id, ctdh => {
                ComponentCacheUtils.requireDonHang(comp, dataService, ctdh.maDonHang, dh => {
                    const khoHang = refData[0].items.find(p => p.id === dh.maKhoHang);
                    const khachHang = refData[1].items.find(p => p.id === dh.maKhachHang);
                    const matHang = refData[2].items.find(p => p.id === ctdh.maMatHang);
                    callback(DisplayTextUtils.chiTietDonHang(ctdh, dh, khoHang, khachHang, matHang), ctdh)
                });
            });
        });
    }

    static formatDate(date: Date) {
        const day = date.getDate();
        const month = date.getMonth() + 1;
        const year = date.getFullYear();
        return `${DisplayTextUtils.formatNumber(day)}/${DisplayTextUtils.formatNumber(month)}/${year}`;
    }

    static formatNumber(number) {
        return number < 10 ? '0' + number : '' + number;
    }
}