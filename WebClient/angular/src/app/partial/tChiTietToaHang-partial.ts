import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { of } from 'rxjs/observable/of';
import { Utils } from '../utils';
import { HSimpleGridSetting } from '../shared';

import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { ReferenceDataService } from '../reference-data.service';
import { DisplayTextUtils } from './displayTextUtils';
import { ComponentCacheUtils } from './componentCacheUtils';

export class tChiTietToaHangPartial {

    static className = 'tChiTietToaHangComponent';

    static afterContentInitPartial(parameters) {
        const comp = parameters[0];
        let temp = comp.grid.settings.columnSettings;
        let soLuongColumn = new HSimpleGridSetting.ColumnSetting();
        soLuongColumn.headerSetting.headerText = 'So luong';
        soLuongColumn.headerSetting.filterOperatorType = HSimpleGridSetting.FilterOperatorTypeEnum.NUMBER;
        soLuongColumn.headerSetting.filterType = HSimpleGridSetting.EditorTypeEnum.HNumber;
        soLuongColumn.headerSetting.hasOnlyText = true;
        soLuongColumn.cellValueProperty = 'soLuong';
        soLuongColumn.cellValueType = HSimpleGridSetting.DataTypeEnum.Int;
        soLuongColumn.type = HSimpleGridSetting.EditorTypeEnum.HNumber;
        soLuongColumn.isReadOnly = true;
        temp.push(soLuongColumn);

        let thanhTienColumn = new HSimpleGridSetting.ColumnSetting();
        thanhTienColumn.headerSetting.headerText = 'Thanh tien';
        thanhTienColumn.headerSetting.filterOperatorType = HSimpleGridSetting.FilterOperatorTypeEnum.NUMBER;
        thanhTienColumn.headerSetting.filterType = HSimpleGridSetting.EditorTypeEnum.HNumber;
        thanhTienColumn.headerSetting.hasOnlyText = true;
        thanhTienColumn.cellValueProperty = 'thanhTien';
        thanhTienColumn.cellValueType = HSimpleGridSetting.DataTypeEnum.Int;
        thanhTienColumn.type = HSimpleGridSetting.EditorTypeEnum.HNumber;
        thanhTienColumn.isReadOnly = true;
        temp.push(thanhTienColumn);

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

        ComponentCacheUtils.requireToaHang(comp, dataService, item.maToaHang, th => {
            ComponentCacheUtils.requireChiTietDonHang(comp, dataService, item.maChiTietDonHang, ctdh => {
                refDataService.gets(['rKhoHang', 'rKhachHang', 'tmathang']).subscribe(refData => {
                    if (th !== undefined) {
                        const khachHang = refData[1].items.find(p => p.id === th.maKhachHang);
                        item.maToaHangNavigation = {
                            maKhachHang: th.maKhachHang,
                            displayText: DisplayTextUtils.toaHang(th, khachHang)
                        };
                    }
                    if (ctdh !== undefined) {
                        ComponentCacheUtils.requireDonHang(comp, dataService, ctdh.maDonHang, dh => {
                            const khoHang = refData[0].items.find(p => p.id === dh.maKhoHang);
                            const khachHang = refData[1].items.find(p => p.id === dh.maKhachHang);
                            const matHang = refData[2].items.find(p => p.id === ctdh.maMatHang);
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

        refDataService.gets(['rKhoHang', 'rKhachHang', 'tmathang']).subscribe(refData => {
            dataService.getIntList('ttoahang', 'id', data.items.map(p => p.maToaHang)).subscribe(toaHangs => {
                dataService.getIntList('tchitietdonhang', 'id', data.items.map(p => p.maChiTietDonHang)).subscribe(ctdhs => {
                    dataService.getIntList('tdonhang', 'id', ctdhs.items.map(p => p.maDonHang)).subscribe(dhs => {
                        ComponentCacheUtils.setToaHang(comp, toaHangs.items);
                        ComponentCacheUtils.setChiTietDonHang(comp, ctdhs.items);
                        ComponentCacheUtils.setDonHang(comp, dhs.items);
                        data.items.forEach(item => {
                            Utils.addCallback(item, (obj, prop) => {
                                this.propertyChangedCallback(comp, refDataService, dataService, obj, prop);
                            });
                            const th = toaHangs.items.find(p => p.id === item.maToaHang);
                            const khachHang = refData[1].items.find(p => p.id === th.maKhachHang);
                            item.maToaHangNavigation = {
                                displayText: DisplayTextUtils.toaHang(th, khachHang)
                            };
                            const ctdh = ctdhs.items.find(p => p.id === item.maChiTietDonHang);
                            const dh = dhs.items.find(p => p.id === ctdh.maDonHang);
                            const khoHang = refData[0].items.find(p => p.id === dh.maKhoHang);
                            const khachHang1 = refData[1].items.find(p => p.id === dh.maKhachHang);
                            const matHang = refData[2].items.find(p => p.id === ctdh.maMatHang);
                            item.maChiTietDonHangNavigation = {
                                displayText: DisplayTextUtils.chiTietDonHang(ctdh, dh, khoHang, khachHang1, matHang)
                            };
                            if (ctdh !== undefined) {
                                item.soLuong = ctdh.soLuong;
                                item.thanhTien = this.calculateThanhTien(item.giaTien, ctdh.soLuong);
                            } else {
                                item.soLuong = '';
                                item.thanhTien = '';
                            }
                        });
                        subject.next();
                    });
                });
            });
        });
        return subject;
    }

    static propertyChangedCallback(comp, refDataService, dataService, obj, prop) {
        switch (prop) {
            case 'maToaHang': {
                DisplayTextUtils.getToaHang(comp, refDataService, dataService, obj[prop], (text) => {
                    obj.maToaHangNavigation = {
                        displayText: text
                    };
                    comp.grid.updateGrid();
                });
                break;
            }
            case 'maChiTietDonHang': {
                DisplayTextUtils.getChiTietDonHang(comp, refDataService, dataService, obj[prop], (text, ctdh) => {
                    obj.maChiTietDonHangNavigation = {
                        displayText: text
                    };
                    obj.soLuong = ctdh.soLuong;
                    obj.thanhTien = this.calculateThanhTien(obj.giaTien, ctdh.soLuong);
                    comp.grid.updateGrid();
                });
                break;
            }
            case 'giaTien': {
                obj.thanhTien = this.calculateThanhTien(obj.giaTien, obj.soLuong);
                break;
            }
        }
    }

    static calculateThanhTien(giaTien, soLuong) {
        if (giaTien === undefined) {
            return '';
        }
        return giaTien * soLuong;
    }
}