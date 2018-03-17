import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { of } from 'rxjs/observable/of';
import { Utils } from '../utils';
import { HSimpleGridSetting } from '../shared';

import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { ReferenceDataService } from '../reference-data.service';
import { DisplayTextUtils } from './displayTextUtils';

export class tChuyenHangDonHangPartial {

    static className = 'tChuyenHangDonHangComponent';

    static processItemListPartial(parameters): Observable<any> {
        const comp = parameters[0];
        const data = parameters[1];
        const dataService: DataService = comp.dataService;
        const refDataService: ReferenceDataService = comp.refDataService;

        comp.cache = comp.cache || {};
        const subject = new Subject();
        refDataService.gets(['rKhoHang', 'rKhachHang', 'rNhanVien']).subscribe(refData => {
            dataService.getIntList('tDonHang', 'id', data.items.map(p => p.maDonHang)).subscribe(donHangs => {
                dataService.getIntList('tChuyenHang', 'id', data.items.map(p => p.maChuyenHang)).subscribe(chuyenHangs => {
                    comp.cache.donHangs = donHangs.items;
                    comp.cache.chuyenHangs = chuyenHangs.items;
                    data.items.forEach(item => {
                        Utils.addCallback(item, (obj, prop) => {
                            this.propertyChangedCallback(comp, refDataService, dataService, obj, prop);
                        });
                        const dh = donHangs.items.find(p => p.id === item.maDonHang);
                        const khoHang = refData[0].items.find(p => p.id === dh.maKhoHang);
                        const khachHang = refData[1].items.find(p => p.id === dh.maKhachHang);
                        item.maDonHangNavigation = {
                            displayText: DisplayTextUtils.donHang(dh, khoHang, khachHang)
                        };
                        const ch = chuyenHangs.items.find(p => p.id === item.maChuyenHang);
                        const nhanVien = refData[2].items.find(p => p.id === ch.maNhanVienGiaoHang);
                        item.maChuyenHangNavigation = {
                            displayText: DisplayTextUtils.chuyenHang(ch, nhanVien)
                        };
                    });
                    subject.next();
                });
            });
        });
        return subject;
    }

    static processItemPartial(parameters) {
        const comp = parameters[0];
        const item = parameters[1];
        const dataService: DataService = comp.dataService;
        const refDataService: ReferenceDataService = comp.refDataService;

        Utils.addCallback(item, (obj, prop) => {
            this.propertyChangedCallback(comp, refDataService, dataService, obj, prop);
        });

        this.requireChuyenHang(comp, dataService, item.maChuyenHang, ch => {
            this.requireDonHang(comp, dataService, item.maDonHang, dh => {
                refDataService.gets(['rKhoHang', 'rKhachHang', 'rNhanVien']).subscribe(refData => {
                    if (dh !== undefined) {
                        const khoHang = refData[0].items.find(p => p.id === dh.maKhoHang);
                        const khachHang = refData[1].items.find(p => p.id === dh.maKhachHang);
                        item.maDonHangNavigation = {
                            displayText: DisplayTextUtils.donHang(dh, khoHang, khachHang)
                        };
                    }
                    if (ch !== undefined) {
                        const nhanVien = refData[2].items.find(p => p.id === ch.maNhanVienGiaoHang);
                        item.maChuyenHangNavigation = {
                            displayText: DisplayTextUtils.chuyenHang(ch, nhanVien)
                        };
                    }
                });
            });
        });
    }

    static propertyChangedCallback(comp, refDataService, dataService, obj, prop) {
        switch (prop) {
            case 'maDonHang': {
                this.requireDonHang(comp, dataService, obj[prop], dh => {
                    refDataService.gets(['rkhohang', 'rkhachhang']).subscribe(refData => {
                        const khoHang = refData[0].items.find(p => p.id === dh.maKhoHang);
                        const khachHang = refData[1].items.find(p => p.id === dh.maKhachHang);
                        obj.maDonHangNavigation = {
                            displayText: DisplayTextUtils.donHang(dh, khoHang, khachHang)
                        };
                        comp.grid.updateGrid();
                    });
                });
                break;
            }
            case 'maChuyenHang': {
                this.requireChuyenHang(comp, dataService, obj[prop], ch => {
                    refDataService.gets(['rnhanvien']).subscribe(refData => {
                        const nhanVien = refData[0].items.find(p => p.id === ch.maNhanVienGiaoHang);
                        obj.maChuyenHangNavigation = {
                            displayText: DisplayTextUtils.chuyenHang(ch, nhanVien)
                        };
                        comp.grid.updateGrid();
                    });
                });
                break;
            }
        }
    }

    static requireDonHang(comp, dataService, maDonHang, callback) {
        if (maDonHang === undefined || maDonHang === null || maDonHang == '') {
            callback(undefined);
            return;
        }
        let donHang;
        if (comp.cache.donHangs !== undefined) {
            donHang = comp.cache.donHangs.find(p => p.id === maDonHang);
        }

        if (donHang !== undefined) {
            callback(donHang);
        } else {
            dataService.getByID('tdonhang', maDonHang).subscribe(dh => {
                comp.cache.donHangs.push(dh);
                callback(dh);
            });
        }
    }

    static requireChuyenHang(comp, dataService, maChuyenHang, callback) {
        if (maChuyenHang === undefined || maChuyenHang === null || maChuyenHang == '') {
            callback(undefined);
            return;
        }
        let chuyenHang;
        if (comp.cache.chuyenHangs !== undefined) {
            chuyenHang = comp.cache.chuyenHangs.find(p => p.id === maChuyenHang);
        }

        if (chuyenHang !== undefined) {
            callback(chuyenHang);
        } else {
            dataService.getByID('tchuyenhang', maChuyenHang).subscribe(dh => {
                comp.cache.chuyenHangs.push(dh);
                callback(dh);
            });
        }
    }
}