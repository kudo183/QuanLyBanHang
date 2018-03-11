export class DisplayTextUtils {
    static donHang(dh) {
        return `${dh.id}-${dh.maKhachHang}-${dh.maKhoHang}`;
    }
    static getDonHang(dataService, id, callback) {
        dataService.getByID('tdonhang', id).subscribe(dh => {
            callback(DisplayTextUtils.donHang(dh));
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
}