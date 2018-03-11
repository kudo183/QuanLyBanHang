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
        this.itemListRequire(refDataService, dataService, data, (chdhs, chs, dhs, ctdhs) => {
            data.items.forEach(item => {
                Utils.addCallback(item, (obj, prop) => {
                    this.propertyChangedCallback(comp, dataService, obj, prop);
                });
                const chdh = chdhs.items.find(p => p.id === item.maChuyenHangDonHang);
                const ch = chs.items.find(p => p.id === chdh.maChuyenHang);
                const dh = dhs.items.find(p => p.id === chdh.maDonHang);
                item.maChuyenHangDonHangNavigation = {
                    displayText: DisplayTextUtils.chuyenHangDonHang(chdh, ch, dh)
                };
                const ctdh = ctdhs.items.find(p => p.id === item.maChiTietDonHang);
                item.maChiTietDonHangNavigation = {
                    displayText: `${ctdh.id}-${ctdh.maDonHang}`
                };
            });
            subject.next();
        });
        return subject;
    }

    static itemListRequire(refDataService, dataService, data, callback) {
        refDataService.gets(['rKhoHang', 'rKhachHang', 'rNhanVien']).subscribe(refData => {
            dataService.getIntList('tChuyenHangDonHang', 'id', data.items.map(p => p.maChuyenHangDonHang)).subscribe(chdhs => {
                dataService.getIntList('tChiTietDonHang', 'id', data.items.map(p => p.maChiTietDonHang)).subscribe(ctdhs => {
                    dataService.getIntList('tDonHang', 'id', chdhs.items.map(p => p.maDonHang)).subscribe(dhs => {
                        dataService.getIntList('tChuyenHang', 'id', chdhs.items.map(p => p.maChuyenHang)).subscribe(chs => {
                            callback(chdhs, chs, dhs, ctdhs);
                        });
                    });
                });
            });
        });
    }

    static propertyChangedCallback(comp, dataService, obj, prop) {
        switch (prop) {
            case 'maChuyenHangDonHang': {
                console.debug('maChuyenHangDonHang changed');
                console.debug(dataService);
                DisplayTextUtils.getChuyenHangDonHang(dataService, obj[prop], (text) => {
                    obj.maChuyenHangDonHangNavigation = {
                        displayText: text
                    };
                    comp.grid.updateGrid();
                });
                break;
            }
            case 'maChiTietDonHang': {
                dataService.getByID('tChiTietDonHang', obj[prop]).subscribe(p => {
                    obj.maChiTietDonHangNavigation = {
                        displayText: `${p.id}-${p.maDonHang}`
                    };
                    comp.grid.updateGrid();
                });
                break;
            }
        }
    }
}