import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { of } from 'rxjs/observable/of';
import { Utils } from '../utils';
import { HSimpleGridSetting } from '../shared';

import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { ReferenceDataService } from '../reference-data.service';
import { DisplayTextUtils } from './displayTextUtils';

export class tChiTietChuyenHangDonHangPartial {

    static className = 'tChiTietChuyenHangDonHangComponent';

    static processItemListPartial(parameters): Observable<any> {
        const comp = parameters[0];
        const data = parameters[1];
        const dataService: DataService = comp.dataService;
        const refDataService: ReferenceDataService = comp.refDataService;

        const subject = new Subject();
        this.itemListRequire(refDataService, dataService, data, (chdhs, chs, dhs, ctdhs, refData) => {
            data.items.forEach(item => {
                Utils.addCallback(item, (obj, prop) => {
                    this.propertyChangedCallback(comp, refDataService, dataService, obj, prop);
                });
                const chdh = chdhs.items.find(p => p.id === item.maChuyenHangDonHang);
                const ch = chs.items.find(p => p.id === chdh.maChuyenHang);
                const dh = dhs.items.find(p => p.id === chdh.maDonHang);
                const nhanVien = refData[0].items.find(p => p.id === ch.maNhanVienGiaoHang);
                const khoHang = refData[1].items.find(p => p.id === dh.maKhoHang);
                const khachHang = refData[2].items.find(p => p.id === dh.maKhachHang);
                item.maChuyenHangDonHangNavigation = {
                    displayText: DisplayTextUtils.chuyenHangDonHang(chdh, ch, dh, nhanVien, khoHang, khachHang)
                };
                const ctdh = ctdhs.items.find(p => p.id === item.maChiTietDonHang);
                const matHang = refData[3].items.find(p => p.id === ctdh.maMatHang);
                item.maChiTietDonHangNavigation = {
                    displayText: DisplayTextUtils.chiTietDonHang(ctdh, dh, khoHang, khachHang, matHang)
                };
            });
            subject.next();
        });
        return subject;
    }

    static afterLoadPartial(parameters) {
        const comp = parameters[0];
        const dataService: DataService = comp.dataService;
        const refDataService: ReferenceDataService = comp.refDataService;

        if (comp.entities.length !== 0) {
            return;
        }
        const maChuyenHangDonHang = comp.grid.settings.columnSettings[1].headerSetting.filterValue;
        this.afterLoadRequire(refDataService, dataService, maChuyenHangDonHang, (chdh, ctchdhs, ctdhs, ch, dh, nhanViens, khoHangs, khachHangs, matHangs) => {
            const newItems = [];
            const nhanVien = nhanViens.items.find(p => p.id === ch.maNhanVienGiaoHang);
            const khoHang = khoHangs.items.find(p => p.id === dh.maKhoHang);
            const khachHang = khachHangs.items.find(p => p.id === dh.maKhachHang);
            ctdhs.items.forEach(ctdh => {
                const newItem: any = {};
                newItem.maChuyenHangDonHang = chdh.id;
                newItem.maChuyenHangDonHangNavigation = {
                    displayText: DisplayTextUtils.chuyenHangDonHang(chdh, ch, dh, nhanVien, khoHang, khachHang)
                };

                const matHang = matHangs.items.find(p => p.id === ctdh.maMatHang);
                newItem.maChiTietDonHang = ctdh.id;
                newItem.maChiTietDonHangNavigation = {
                    displayText: DisplayTextUtils.chiTietDonHang(ctdh, dh, khoHang, khachHang, matHang)
                };

                let soLuongDaGiao = 0;
                ctchdhs.items.forEach(ctchdh => {
                    if (ctchdh.maChiTietDonHang === newItem.maChiTietDonHang) {
                        soLuongDaGiao = soLuongDaGiao + ctchdh.soLuong;
                    }
                });
                newItem.soLuong = ctdh.soLuong - soLuongDaGiao;

                newItems.push(newItem);
            });
            comp.entities = newItems;
            comp.grid.updateGrid();
        });
    }

    static itemListRequire(refDataService, dataService, data, callback) {
        refDataService.gets(['rNhanVien', 'rKhoHang', 'rKhachHang', 'tmathang']).subscribe(refData => {
            dataService.getIntList('tChuyenHangDonHang', 'id', data.items.map(p => p.maChuyenHangDonHang)).subscribe(chdhs => {
                dataService.getIntList('tChiTietDonHang', 'id', data.items.map(p => p.maChiTietDonHang)).subscribe(ctdhs => {
                    dataService.getIntList('tDonHang', 'id', chdhs.items.map(p => p.maDonHang)).subscribe(dhs => {
                        dataService.getIntList('tChuyenHang', 'id', chdhs.items.map(p => p.maChuyenHang)).subscribe(chs => {
                            callback(chdhs, chs, dhs, ctdhs, refData);
                        });
                    });
                });
            });
        });
    }

    static afterLoadRequire(refDataService, dataService, maChuyenHangDonHang, callback) {
        dataService.getByID('tChuyenHangDonHang', maChuyenHangDonHang).subscribe(chdh => {
            const qe = new QueryExpression();
            qe.addWhereOption('=', 'maDonHang', chdh.maDonHang, WhereOptionTypes.Int);
            qe.addWhereOption('=', 'xong', false, WhereOptionTypes.Bool);
            dataService.get('tChiTietDonHang', qe).subscribe(ctdhs => {
                if (ctdhs.items.length > 0) {
                    refDataService.gets(['rnhanvien', 'rkhohang', 'rkhachhang', 'tmathang']).subscribe(refData => {
                        dataService.getByID('tDonHang', chdh.maDonHang).subscribe(dh => {
                            dataService.getByID('tChuyenHang', chdh.maChuyenHang).subscribe(ch => {
                                dataService.getIntList('tChiTietChuyenHangDonHang', 'maChiTietDonHang', ctdhs.items.map(p => p.id)).subscribe(ctchdhs => {
                                    callback(chdh, ctchdhs, ctdhs, ch, dh, refData[0], refData[1], refData[2], refData[3]);
                                });
                            });
                        });
                    });
                }
            });
        });
    }

    static propertyChangedCallback(comp, refDataService, dataService, obj, prop) {
        switch (prop) {
            case 'maChuyenHangDonHang': {
                DisplayTextUtils.getChuyenHangDonHang(refDataService, dataService, obj[prop], (text) => {
                    obj.maChuyenHangDonHangNavigation = {
                        displayText: text
                    };
                    comp.grid.updateGrid();
                });
                break;
            }
            case 'maChiTietDonHang': {
                DisplayTextUtils.getChiTietDonHang(refDataService, dataService, obj[prop], (text) => {
                    obj.maChiTietDonHangNavigation = {
                        displayText: text
                    };
                    comp.grid.updateGrid();
                });
                break;
            }
        }
    }
}