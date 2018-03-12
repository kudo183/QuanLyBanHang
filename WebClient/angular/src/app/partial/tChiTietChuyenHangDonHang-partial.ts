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
                item.maChiTietDonHangNavigation = {
                    displayText: DisplayTextUtils.chiTietDonHang(ctdh, dh, khoHang, khachHang)
                };
            });
            subject.next();
        });
        return subject;
    }

    static itemListRequire(refDataService, dataService, data, callback) {
        refDataService.gets(['rNhanVien', 'rKhoHang', 'rKhachHang']).subscribe(refData => {
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