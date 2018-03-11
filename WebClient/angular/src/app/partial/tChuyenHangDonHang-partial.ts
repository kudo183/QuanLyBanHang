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

        const subject = new Subject();
        refDataService.gets(['rKhoHang', 'rKhachHang', 'rNhanVien']).subscribe(refData => {
            dataService.getIntList('tDonHang', 'id', data.items.map(p => p.maDonHang)).subscribe(donHangs => {
                dataService.getIntList('tChuyenHang', 'id', data.items.map(p => p.maChuyenHang)).subscribe(chuyenHangs => {
                    data.items.forEach(item => {
                        Utils.addCallback(item, (obj, prop) => {
                            this.propertyChangedCallback(comp, dataService, obj, prop);
                        });
                        const dh = donHangs.items.find(p => p.id === item.maDonHang);
                        item.maDonHangNavigation = {
                            displayText: DisplayTextUtils.donHang(dh)
                        };
                        const ch = chuyenHangs.items.find(p => p.id === item.maChuyenHang);
                        item.maChuyenHangNavigation = {
                            displayText: `${ch.id}-${ch.maNhanVienGiaoHang}`
                        };
                    });
                    subject.next();
                });
            });
        });
        return subject;
    }

    static propertyChangedCallback(comp, dataService, obj, prop) {
        switch (prop) {
            case 'maDonHang': {
                dataService.getByID('tdonhang', obj[prop]).subscribe(p => {
                    obj.maDonHangNavigation = {
                        displayText: DisplayTextUtils.donHang(p)
                    };
                    comp.grid.updateGrid();
                });
                break;
            }
            case 'maChuyenHang': {
                dataService.getByID('tchuyenhang', obj[prop]).subscribe(p => {
                    obj.maChuyenHangNavigation = {
                        displayText: `${p.id}-${p.maNhanVienGiaoHang}`
                    };
                    comp.grid.updateGrid();
                });
                break;
            }
        }
    }
}