import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { of } from 'rxjs/observable/of';
import { Utils } from '../utils';
import { HSimpleGridSetting } from '../shared';

import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { ReferenceDataService } from '../reference-data.service';
import { DisplayTextUtils } from './displayTextUtils';
import { ComponentCacheUtils } from './componentCacheUtils';

export class tChuyenHangDonHangPartial {

    static className = 'tChuyenHangDonHangComponent';

    static processItemListPartial(parameters): Observable<any> {
        const comp = parameters[0];
        const data = parameters[1];
        const dataService: DataService = comp.dataService;
        const refDataService: ReferenceDataService = comp.refDataService;

        const subject = new Subject();
        refDataService.gets(['rKhoHang', 'rKhachHang', 'rNhanVien']).subscribe(refData => {
            dataService.getIntList('tDonHang', 'id', data.items.map(p => p.maDonHang)).subscribe(donHangs => {
                dataService.getIntList('tChuyenHang', 'id', data.items.map(p => p.maChuyenHang)).subscribe(chuyenHangs => {
                    ComponentCacheUtils.setDonHang(comp, donHangs.items);
                    ComponentCacheUtils.setChuyenHang(comp, chuyenHangs.items);
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

        ComponentCacheUtils.requireChuyenHang(comp, dataService, item.maChuyenHang, ch => {
            ComponentCacheUtils.requireDonHang(comp, dataService, item.maDonHang, dh => {
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
                DisplayTextUtils.getDonHang(comp, refDataService, dataService, obj[prop], (text) => {
                    obj.maDonHangNavigation = {
                        displayText: text
                    };
                    comp.grid.updateGrid();
                });
                break;
            }
            case 'maChuyenHang': {
                DisplayTextUtils.getChuyenHang(comp, refDataService, dataService, obj[prop], (text) => {
                    obj.maChuyenHangNavigation = {
                        displayText: text
                    };
                    comp.grid.updateGrid();
                });
                break;
            }
        }
    }
}