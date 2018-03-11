export class DisplayTextUtils {
    static donHang(dh, khoHang, khachHang) {
        const ngay = new Date(dh.ngay);
        return `${dh.id}|${DisplayTextUtils.formatDate(ngay)}|${khoHang.tenKho}|${khachHang.tenKhachHang}`;
    }
    static getDonHang(refDataService, dataService, id, callback) {
        dataService.getByID('tdonhang', id).subscribe(dh => {
            refDataService.gets(['rkhohang', 'rkhachhang']).subscribe(refData => {
                const khoHang = refData[0].items.find(p => p.id === dh.maKhoHang);
                const khachHang = refData[1].items.find(p => p.id === dh.maKhachHang);
                callback(DisplayTextUtils.donHang(dh, khoHang, khachHang));
            });
        });
    }
    static chuyenHangDonHang(chdh, ch, dh) {
        return `${chdh.id}-${ch.ngay}-${dh.ngay}`;
    }
    static getChuyenHangDonHang(dataService, id, callback) {
        dataService.getByID('tChuyenHangDonHang', id).subscribe(chdh => {
            dataService.getByID('tChuyenHang', chdh.maChuyenHang).subscribe(ch => {
                dataService.getByID('tDonHang', chdh.maDonHang).subscribe(dh => {
                    callback(DisplayTextUtils.chuyenHangDonHang(chdh, ch, dh))
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