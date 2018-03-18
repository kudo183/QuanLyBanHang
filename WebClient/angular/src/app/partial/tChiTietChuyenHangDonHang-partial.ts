import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { of } from 'rxjs/observable/of';
import { Utils } from '../utils';
import { HSimpleGridSetting } from '../shared';

import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { ReferenceDataService } from '../reference-data.service';
import { DisplayTextUtils } from './displayTextUtils';
import { ComponentCacheUtils } from './componentCacheUtils';

export class tChiTietChuyenHangDonHangPartial {

    static className = 'tChiTietChuyenHangDonHangComponent';

    static processItemPartial(parameters) {
        const comp = parameters[0];
        const item = parameters[1];
        const dataService: DataService = comp.dataService;
        const refDataService: ReferenceDataService = comp.refDataService;

        Utils.addCallback(item, (obj, prop) => {
            this.propertyChangedCallback(comp, refDataService, dataService, obj, prop);
        });

        ComponentCacheUtils.requireChuyenHangDonHang(comp, dataService, item.maChuyenHangDonHang, chdh => {
            ComponentCacheUtils.requireChiTietDonHang(comp, dataService, item.maChiTietDonHang, ctdh => {
                refDataService.gets(['rNhanVien', 'rKhoHang', 'rKhachHang', 'tmathang']).subscribe(refData => {
                    if (chdh !== undefined) {
                        ComponentCacheUtils.requireChuyenHang(comp, dataService, chdh.maChuyenHang, ch => {
                            ComponentCacheUtils.requireDonHang(comp, dataService, chdh.maDonHang, dh => {
                                const nhanVien = refData[0].items.find(p => p.id === ch.maNhanVienGiaoHang);
                                const khoHang = refData[1].items.find(p => p.id === dh.maKhoHang);
                                const khachHang = refData[2].items.find(p => p.id === dh.maKhachHang);
                                item.maChuyenHangDonHangNavigation = {
                                    displayText: DisplayTextUtils.chuyenHangDonHang(chdh, ch, dh, nhanVien, khoHang, khachHang)
                                };
                            });
                        });
                    }
                    if (ctdh !== undefined) {
                        ComponentCacheUtils.requireDonHang(comp, dataService, ctdh.maDonHang, dh => {
                            const khoHang = refData[1].items.find(p => p.id === dh.maKhoHang);
                            const khachHang = refData[2].items.find(p => p.id === dh.maKhachHang);
                            const matHang = refData[3].items.find(p => p.id === ctdh.maMatHang);
                            item.maChiTietDonHangNavigation = {
                                displayText: DisplayTextUtils.chiTietDonHang(ctdh, dh, khoHang, khachHang, matHang)
                            };
                        });
                    }
                });
            });
        });
    }

    static processItemListPartial(parameters): Observable<any> {
        const comp = parameters[0];
        const data = parameters[1];
        const dataService: DataService = comp.dataService;
        const refDataService: ReferenceDataService = comp.refDataService;

        const subject = new Subject();
        this.itemListRequire(refDataService, dataService, data, (chdhs, chs, dhs, ctdhs, refData) => {
            ComponentCacheUtils.setChuyenHangDonHang(comp, chdhs.items);
            ComponentCacheUtils.setChiTietDonHang(comp, ctdhs.items);
            ComponentCacheUtils.setDonHang(comp, dhs.items);
            ComponentCacheUtils.setChuyenHang(comp, chs.items);
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
        this.afterLoadRequire(comp, refDataService, dataService, maChuyenHangDonHang, (chdh, ctchdhs, ctdhs, ch, dh, nhanViens, khoHangs, khachHangs, matHangs) => {
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

    static afterLoadRequire(comp, refDataService, dataService, maChuyenHangDonHang, callback) {
        ComponentCacheUtils.requireChuyenHangDonHang(comp, dataService, maChuyenHangDonHang, chdh => {
            const qe = new QueryExpression();
            qe.addWhereOption('=', 'maDonHang', chdh.maDonHang, WhereOptionTypes.Int);
            qe.addWhereOption('=', 'xong', false, WhereOptionTypes.Bool);
            dataService.get('tChiTietDonHang', qe).subscribe(ctdhs => {
                if (ctdhs.items.length > 0) {
                    refDataService.gets(['rnhanvien', 'rkhohang', 'rkhachhang', 'tmathang']).subscribe(refData => {
                        ComponentCacheUtils.requireDonHang(comp, dataService, chdh.maDonHang, dh => {
                            ComponentCacheUtils.requireChuyenHang(comp, dataService, chdh.maChuyenHang, ch => {
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
                DisplayTextUtils.getChuyenHangDonHang(comp, refDataService, dataService, obj[prop], (text) => {
                    obj.maChuyenHangDonHangNavigation = {
                        displayText: text
                    };
                    comp.grid.updateGrid();
                });
                break;
            }
            case 'maChiTietDonHang': {
                DisplayTextUtils.getChiTietDonHang(comp, refDataService, dataService, obj[prop], (text) => {
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