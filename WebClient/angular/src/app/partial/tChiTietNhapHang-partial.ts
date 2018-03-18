import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { of } from 'rxjs/observable/of';
import { Utils } from '../utils';
import { HSimpleGridSetting } from '../shared';

import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { ReferenceDataService } from '../reference-data.service';
import { DisplayTextUtils } from './displayTextUtils';
import { ComponentCacheUtils } from './componentCacheUtils';

export class tChiTietNhapHangPartial {

    static className = 'tChiTietNhapHangComponent';

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
        temp.splice(temp.length, 0, tonKhoColumn);
        comp.grid.settings.columnSettings = temp;
    }

    static processItemPartial(parameters) {
        const comp = parameters[0];
        const item = parameters[1];
        const dataService: DataService = comp.dataService;
        const refDataService: ReferenceDataService = comp.refDataService;

        Utils.addCallback(item, (obj, prop) => {
            this.propertyChangedCallback(comp, refDataService, dataService, obj, prop);
        });

        ComponentCacheUtils.requireNhapHang(comp, dataService, item.maNhapHang, nh => {
            if (nh !== undefined) {
                refDataService.gets(['rkhohang', 'rnhacungcap']).subscribe(refData => {
                    const khoHang = refData[0].items.find(p => p.id === nh.maKhoHang);
                    const nhaCungCap = refData[1].items.find(p => p.id === nh.maNhaCungCap);
                    item.maNhapHangNavigation = {
                        maKhoHang: nh.maKhoHang,
                        displayText: DisplayTextUtils.nhapHang(nh, khoHang, nhaCungCap)
                    };
                    comp.grid.updateGrid();
                });
            }
        });
    }

    static processItemListPartial(parameters): Observable<any> {
        const comp = parameters[0];
        const data = parameters[1];
        const dataService: DataService = comp.dataService;
        const refDataService: ReferenceDataService = comp.refDataService;

        const subject = new Subject();

        refDataService.gets(['rkhohang', 'rnhacungcap']).subscribe(refData => {
            dataService.getIntList('tNhapHang', 'id', data.items.map(p => p.maNhapHang)).subscribe(nhapHangs => {
                ComponentCacheUtils.setNhapHang(comp, nhapHangs.items);
                const qe = new QueryExpression();
                const date = new Date();
                qe.addWhereOption('IN', 'maMatHang', data.items.map(p => p.maMatHang), WhereOptionTypes.IntList);
                qe.addWhereOption('IN', 'maKhoHang', nhapHangs.items.map(p => p.maKhoHang), WhereOptionTypes.IntList);
                qe.addWhereOption('=', 'ngay', `${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`, WhereOptionTypes.Date);
                dataService.get('ttonkho', qe).subscribe(tonKhos => {
                    data.items.forEach(item => {
                        Utils.addCallback(item, (obj, prop) => {
                            this.propertyChangedCallback(comp, refDataService, dataService, obj, prop);
                        });
                        const nh = nhapHangs.items.find(p => p.id === item.maNhapHang);
                        const khoHang = refData[0].items.find(p => p.id === nh.maKhoHang);
                        const nhaCungCap = refData[1].items.find(p => p.id === nh.maNhaCungCap);
                        item.maNhapHangNavigation = {
                            maKhoHang: nh.maKhoHang,
                            displayText: DisplayTextUtils.nhapHang(nh, khoHang, nhaCungCap)
                        };
                        const mh = tonKhos.items.find(p => p.maKhoHang === nh.maKhoHang && p.maMatHang === item.maMatHang);
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
            case 'maNhapHang': {
                DisplayTextUtils.getNhapHang(comp, refDataService, dataService, obj[prop], (text, nh) => {
                    obj.maNhapHangNavigation = {
                        maKhoHang: nh.maKhoHang,
                        displayText: text
                    };
                    comp.grid.updateGrid();
                });
                break;
            }
            case 'maMatHang': {
                const qe = new QueryExpression();
                const date = new Date();
                qe.addWhereOption('=', 'maMatHang', obj.maMatHang, WhereOptionTypes.Int);
                qe.addWhereOption('=', 'maKhoHang', obj.maNhapHangNavigation.maKhoHang, WhereOptionTypes.Int);
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