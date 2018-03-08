import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { of } from 'rxjs/observable/of';
import { Utils } from '../utils';

import { DataService } from '../data.service';

export class tChiTietDonHangPartial {

    static className = 'tChiTietDonHangComponent';

    static processItemListPartial(parameters): Observable<any> {
        const comp = parameters[0];
        const data = parameters[1];
        const dataService: DataService = comp.dataService;

        const subject = new Subject();
        dataService.getIntList('tdonhang', 'id', data.items.map(p => p.maDonHang)).subscribe(donHangs => {
            data.items.forEach(item => {
                const dh = donHangs.items.find(p => p.id === item.maDonHang);
                item.maDonHangNavigation = {
                    displayText: `${dh.id}-${dh.maKhachHang}-${dh.maKhoHang}`
                };

                Utils.addCallback(item, (obj, prop) => {
                    switch (prop) {
                        case 'maDonHang': {
                            console.log('maDonHang changed');
                            dataService.getByID('tdonhang', obj[prop]).subscribe(p => {
                                item.maDonHangNavigation = {
                                    displayText: `${p.id}-${p.maKhachHang}-${p.maKhoHang}`
                                };
                                comp.grid.updateGrid();
                            });
                            break;
                        }
                    }
                });
            });
            subject.next();
        });
        return subject;
    }
}