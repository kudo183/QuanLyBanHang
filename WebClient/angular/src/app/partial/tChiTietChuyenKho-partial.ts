import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { of } from 'rxjs/observable/of';
import { Utils } from '../utils';
import { HSimpleGridSetting } from '../shared';

import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { ReferenceDataService } from '../reference-data.service';
import { DisplayTextUtils } from './displayTextUtils';
import { ComponentCacheUtils } from './componentCacheUtils';

export class tChiTietChuyenKhoPartial {

    static className = 'tChiTietChuyenKhoComponent';

    static afterContentInitPartial(parameters) {
        const comp = parameters[0];
        let temp = comp.grid.settings.columnSettings;

        let tonKhoXuatColumn = new HSimpleGridSetting.ColumnSetting();
        tonKhoXuatColumn.headerSetting.headerText = 'Kho Xuat';
        tonKhoXuatColumn.headerSetting.filterOperatorType = HSimpleGridSetting.FilterOperatorTypeEnum.NUMBER;
        tonKhoXuatColumn.headerSetting.filterType = HSimpleGridSetting.EditorTypeEnum.HNumber;
        tonKhoXuatColumn.headerSetting.hasOnlyText = true;
        tonKhoXuatColumn.cellValueProperty = 'tonKhoXuat';
        tonKhoXuatColumn.cellValueType = HSimpleGridSetting.DataTypeEnum.Int;
        tonKhoXuatColumn.type = HSimpleGridSetting.EditorTypeEnum.HNumber;
        tonKhoXuatColumn.isReadOnly = true;
        temp.push(tonKhoXuatColumn);

        let tonKhoNhapColumn = new HSimpleGridSetting.ColumnSetting();
        tonKhoNhapColumn.headerSetting.headerText = 'Kho Nhap';
        tonKhoNhapColumn.headerSetting.filterOperatorType = HSimpleGridSetting.FilterOperatorTypeEnum.NUMBER;
        tonKhoNhapColumn.headerSetting.filterType = HSimpleGridSetting.EditorTypeEnum.HNumber;
        tonKhoNhapColumn.headerSetting.hasOnlyText = true;
        tonKhoNhapColumn.cellValueProperty = 'tonKhoNhap';
        tonKhoNhapColumn.cellValueType = HSimpleGridSetting.DataTypeEnum.Int;
        tonKhoNhapColumn.type = HSimpleGridSetting.EditorTypeEnum.HNumber;
        tonKhoNhapColumn.isReadOnly = true;
        temp.push(tonKhoNhapColumn);

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

        ComponentCacheUtils.requireChuyenKho(comp, dataService, item.maChuyenKho, ck => {
            if (ck !== undefined) {
                refDataService.gets(['rkhohang']).subscribe(refData => {
                    const khoXuat = refData[0].items.find(p => p.id === ck.maKhoHangXuat);
                    const khoNHap = refData[0].items.find(p => p.id === ck.maKhoHangNhap);
                    item.maChuyenKhoNavigation = {
                        maKhoHangXuat: ck.maKhoHangXuat,
                        maKhoHangNhap: ck.maKhoHangNhap,
                        displayText: DisplayTextUtils.chuyenKho(ck, khoXuat, khoNHap)
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

        refDataService.gets(['rkhohang']).subscribe(refData => {
            dataService.getIntList('tchuyenkho', 'id', data.items.map(p => p.maChuyenKho)).subscribe(chuyenKhos => {
                ComponentCacheUtils.setChuyenKho(comp, chuyenKhos.items);
                const qe = new QueryExpression();
                const date = new Date();
                const idKhoHangs = chuyenKhos.items.map(p => p.maKhoHangXuat).concat(chuyenKhos.items.map(p => p.maKhoHangNhap));
                qe.addWhereOption('IN', 'maMatHang', data.items.map(p => p.maMatHang), WhereOptionTypes.IntList);
                qe.addWhereOption('IN', 'maKhoHang', idKhoHangs, WhereOptionTypes.IntList);
                qe.addWhereOption('=', 'ngay', `${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`, WhereOptionTypes.Date);
                dataService.get('ttonkho', qe).subscribe(tonKhos => {
                    data.items.forEach(item => {
                        Utils.addCallback(item, (obj, prop) => {
                            this.propertyChangedCallback(comp, refDataService, dataService, obj, prop);
                        });
                        const ck = chuyenKhos.items.find(p => p.id === item.maChuyenKho);
                        const khoXuat = refData[0].items.find(p => p.id === ck.maKhoHangXuat);
                        const khoNhap = refData[0].items.find(p => p.id === ck.maKhoHangNhap);
                        item.maChuyenKhoNavigation = {
                            maKhoHangXuat: ck.maKhoHangXuat,
                            maKhoHangNhap: ck.maKhoHangNhap,
                            displayText: DisplayTextUtils.chuyenKho(ck, khoXuat, khoNhap)
                        };
                        const mhXuat = tonKhos.items.find(p => p.maKhoHang === ck.maKhoHangXuat && p.maMatHang === item.maMatHang);
                        if (mhXuat !== undefined) {
                            item.tonKhoXuat = mhXuat.soLuong;
                        } else {
                            item.tonKhoXuat = '';
                        }
                        const mhNhap = tonKhos.items.find(p => p.maKhoHang === ck.maKhoHangNhap && p.maMatHang === item.maMatHang);
                        if (mhNhap !== undefined) {
                            item.tonKhoNhap = mhNhap.soLuong;
                        } else {
                            item.tonKhoNhap = '';
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
            case 'maChuyenKho': {
                DisplayTextUtils.getChuyenKho(comp, refDataService, dataService, obj[prop], (text, ck) => {
                    obj.maChuyenKhoNavigation = {
                        maKhoHangXuat: ck.maKhoHangXuat,
                        maKhoHangNhap: ck.maKhoHangNhap,
                        displayText: text
                    };
                    comp.grid.updateGrid();
                });
                break;
            }
            case 'maMatHang': {
                const qe = new QueryExpression();
                const date = new Date();
                const idKhoHangs = [obj.maChuyenKhoNavigation.maKhoHangXuat, obj.maChuyenKhoNavigation.maKhoHangNhap];
                qe.addWhereOption('=', 'maMatHang', obj.maMatHang, WhereOptionTypes.Int);
                qe.addWhereOption('IN', 'maKhoHang', idKhoHangs, WhereOptionTypes.IntList);
                qe.addWhereOption('=', 'ngay', `${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`, WhereOptionTypes.Date);
                dataService.get('ttonkho', qe).subscribe(tonKhos => {
                    const mhXuat = tonKhos.items.find(p => p.maKhoHang === obj.maChuyenKhoNavigation.maKhoHangXuat && p.maMatHang === obj.maMatHang);
                    if (mhXuat !== undefined) {
                        obj.tonKhoXuat = mhXuat.soLuong;
                    } else {
                        obj.tonKhoXuat = '';
                    }
                    const mhNhap = tonKhos.items.find(p => p.maKhoHang === obj.maChuyenKhoNavigation.maKhoHangNhap && p.maMatHang === obj.maMatHang);
                    if (mhNhap !== undefined) {
                        obj.tonKhoNhap = mhNhap.soLuong;
                    } else {
                        obj.tonKhoNhap = '';
                    }
                    comp.grid.updateGrid();
                });
            }
        }
    }
}