export class DisplayTextUtils {
    static donHang(dh, khoHang, khachHang) {
        const ngay = DisplayTextUtils.formatDate(new Date(dh.ngay));
        return `${dh.id}|${ngay}|${khoHang.tenKho}|${khachHang.tenKhachHang}`;
    }
    static getDonHang(refDataService, dataService, id, callback) {
        refDataService.gets(['rkhohang', 'rkhachhang']).subscribe(refData => {
            dataService.getByID('tdonhang', id).subscribe(dh => {
                const khoHang = refData[0].items.find(p => p.id === dh.maKhoHang);
                const khachHang = refData[1].items.find(p => p.id === dh.maKhachHang);
                callback(DisplayTextUtils.donHang(dh, khoHang, khachHang));
            });
        });
    }
    static chuyenHang(ch, nhanVien) {
        const ngay = DisplayTextUtils.formatDate(new Date(ch.ngay));
        return `${ch.id}|${ngay}|${ch.gio}|${nhanVien.tenNhanVien}`;
    }
    static chuyenHangDonHang(chdh, ch, dh, nhanVien, khoHang, khachHang) {
        const ngayDH = DisplayTextUtils.formatDate(new Date(dh.ngay));
        const ngayCH = DisplayTextUtils.formatDate(new Date(ch.ngay));
        return `${chdh.id}|${ch.id}|${ngayCH}|${nhanVien.tenNhanVien}|${dh.id}`;//|${ngayDH}|${khoHang.tenKho}|${khachHang.tenKhachHang}`;
    }
    static getChuyenHangDonHang(refDataService, dataService, id, callback) {
        refDataService.gets(['rnhanvien', 'rkhohang', 'rkhachhang']).subscribe(refData => {
            dataService.getByID('tChuyenHangDonHang', id).subscribe(chdh => {
                dataService.getByID('tChuyenHang', chdh.maChuyenHang).subscribe(ch => {
                    dataService.getByID('tDonHang', chdh.maDonHang).subscribe(dh => {
                        const nhanVien = refData[0].items.find(p => p.id === ch.maNhanVienGiaoHang);
                        const khoHang = refData[1].items.find(p => p.id === dh.maKhoHang);
                        const khachHang = refData[2].items.find(p => p.id === dh.maKhachHang);
                        callback(DisplayTextUtils.chuyenHangDonHang(chdh, ch, dh, nhanVien, khoHang, khachHang))
                    });
                });
            });
        });
    }
    static chiTietDonHang(ctdh, dh, khoHang, khachHang, matHang) {
        const ngay = DisplayTextUtils.formatDate(new Date(dh.ngay));
        return `${ctdh.id}|${dh.id}|${ngay}|${khoHang.tenKho}|${khachHang.tenKhachHang}|${matHang.tenMatHang}`;
    }
    static getChiTietDonHang(refDataService, dataService, id, callback) {
        refDataService.gets(['rkhohang', 'rkhachhang', 'tmathang']).subscribe(refData => {
            dataService.getByID('tChiTietDonHang', id).subscribe(ctdh => {
                dataService.getByID('tDonHang', ctdh.maDonHang).subscribe(dh => {
                    const khoHang = refData[0].items.find(p => p.id === dh.maKhoHang);
                    const khachHang = refData[1].items.find(p => p.id === dh.maKhachHang);
                    const matHang = refData[2].items.find(p => p.id === dh.maMatHang);
                    callback(DisplayTextUtils.chiTietDonHang(ctdh, dh, khoHang, khachHang, matHang))
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