import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { of } from 'rxjs/observable/of';
import { Utils } from '../utils';
import { HSimpleGridSetting } from '../shared';

import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { ReferenceDataService } from '../reference-data.service';
import { DisplayTextUtils } from './displayTextUtils';

export class tChiTietDonHangPartial {

    static className = 'tChiTietDonHangComponent';

    static afterContentInitPartial(parameters) {
        const comp = parameters[0];
        let temp = comp.grid.settings.columnSettings;
        let tonKhoColumn = new HSimpleGridSetting.ColumnSetting();
        tonKhoColumn.headerSetting.headerText = 'Ton Kho';
        tonKhoColumn.headerSetting.filterOperatorType = HSimpleGridSetting.FilterOperatorTypeEnum.NUMBER;
        tonKhoColumn.headerSetting.filterType = HSimpleGridSetting.EditorTypeEnum.HNumber;
        tonKhoColumn.headerSetting.hasOnlyText = true;
        tonKhoColumn.cellValueProperty = 'tonKho';
        tonKhoColumn.cellValueType = HSimpleGridSetting.DataTypeEnum.Int;
        tonKhoColumn.type = HSimpleGridSetting.EditorTypeEnum.HNumber;
        tonKhoColumn.isReadOnly = true;
        temp.splice(temp.length - 1, 0, tonKhoColumn);
        comp.grid.settings.columnSettings = temp;
    }

    static processItemListPartial(parameters): Observable<any> {
        const comp = parameters[0];
        const data = parameters[1];
        const dataService: DataService = comp.dataService;
        const refDataService: ReferenceDataService = comp.refDataService;

        const subject = new Subject();

        refDataService.gets(['rkhohang', 'rkhachhang']).subscribe(refData => {
            dataService.getIntList('tdonhang', 'id', data.items.map(p => p.maDonHang)).subscribe(donHangs => {
                const qe = new QueryExpression();
                const date = new Date();
                qe.addWhereOption('IN', 'maMatHang', data.items.map(p => p.maMatHang), WhereOptionTypes.IntList);
                qe.addWhereOption('IN', 'maKhoHang', donHangs.items.map(p => p.maKhoHang), WhereOptionTypes.IntList);
                qe.addWhereOption('=', 'ngay', `${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`, WhereOptionTypes.Date);
                dataService.get('ttonkho', qe).subscribe(tonKhos => {
                    data.items.forEach(item => {
                        Utils.addCallback(item, (obj, prop) => {
                            this.propertyChangedCallback(comp, refDataService, dataService, obj, prop);
                        });
                        const dh = donHangs.items.find(p => p.id === item.maDonHang);
                        const khoHang = refData[0].items.find(p => p.id === dh.maKhoHang);
                        const khachHang = refData[1].items.find(p => p.id === dh.maKhachHang);
                        item.maDonHangNavigation = {
                            maKhoHang: dh.maKhoHang,
                            displayText: DisplayTextUtils.donHang(dh, khoHang, khachHang)
                        };
                        const mh = tonKhos.items.find(p => p.maKhoHang === dh.maKhoHang && p.maMatHang === item.maMatHang);
                        if (mh !== undefined) {
                            item.tonKho = mh.soLuong;
                        } else {
                            item.tonKho = '';
                        }
                    });
                    subject.next();
                });
            });
        });
        return subject;
    }

    static propertyChangedCallback(comp, refDataService, dataService, obj, prop) {
        switch (prop) {
            case 'maDonHang': {
                console.log('maDonHang changed');
                refDataService.gets(['rkhohang', 'rkhachhang']).subscribe(refData => {
                    dataService.getByID('tdonhang', obj[prop]).subscribe(dh => {
                        const khoHang = refData[0].items.find(p => p.id === dh.maKhoHang);
                        const khachHang = refData[1].items.find(p => p.id === dh.maKhachHang);
                        obj.maDonHangNavigation = {
                            maKhoHang: dh.maKhoHang,
                            displayText: DisplayTextUtils.donHang(dh, khoHang, khachHang)
                        };
                        comp.grid.updateGrid();
                    });
                });
                break;
            }
            case 'maMatHang': {
                console.log('maMatHang changed');
                const qe = new QueryExpression();
                const date = new Date();
                qe.addWhereOption('=', 'maMatHang', obj.maMatHang, WhereOptionTypes.Int);
                qe.addWhereOption('=', 'maKhoHang', obj.maDonHangNavigation.maKhoHang, WhereOptionTypes.Int);
                qe.addWhereOption('=', 'ngay', `${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`, WhereOptionTypes.Date);
                dataService.get('ttonkho', qe).subscribe(tonKhos => {
                    if (tonKhos.items.length === 1) {
                        obj.tonKho = tonKhos.items[0].soLuong;
                    } else {
                        obj.tonKho = '';
                    }
                    comp.grid.updateGrid();
                });
            }
        }
    }
}