import { Component, AfterViewInit, ViewChild, Input } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/observable/from';
import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { ReferenceDataService } from '../reference-data.service';
import { Converter } from '../converter';

import { HSimpleGridSetting, HSimpleGridComponent } from '../shared';

@Component({
  selector: 'app-don-hang',
  templateUrl: './don-hang.component.html',
  styleUrls: ['./don-hang.component.css']
})
export class DonHangComponent implements AfterViewInit {
  @ViewChild(HSimpleGridComponent) grid: HSimpleGridComponent;
  @Input() name = 'viewDonHang';

  maKhachHangSource = [];
  maKhoHangSource = [];
  maChanhSource = [];

  maKhachHangChanhArr = [];

  entities: Array<any>;

  DataTypeEnum = HSimpleGridSetting.DataTypeEnum;
  EditorTypeEnum = HSimpleGridSetting.EditorTypeEnum;
  FilterOperatorTypeEnum = HSimpleGridSetting.FilterOperatorTypeEnum;
  OrderTypeEnum = HSimpleGridSetting.OrderTypeEnum;

  constructor(private dataService: DataService, private refDataService: ReferenceDataService) { }

  ngAfterViewInit() {
    this.refDataService.gets(['rkhachhangchanh', 'rkhachhang', 'rkhohang', 'rchanh']).subscribe(data => {
      const khachHangChanhs = data[0];
      const khachHangs = data[1];
      const khoHangs = data[2];
      const chanhs = data[3];
      this.maKhachHangChanhArr = khachHangChanhs.items;
      this.maKhachHangSource = khachHangs.items;
      this.grid.setHeaderItems(2, khachHangs.items);
      this.maKhoHangSource = khoHangs.items;
      this.grid.setHeaderItems(3, khoHangs.items);
      this.maChanhSource = chanhs.items;
      this.grid.setHeaderItems(4, chanhs.items);
      this.onLoad(undefined);
    });
  }

  onAddingItem(newItem) {
    newItem.maKhachHangSource = this.maKhachHangSource;
    newItem.maKhoHangSource = this.maKhoHangSource;
    newItem.maChanhSource = this.getChanhByMaKhachHang(newItem.maKhachHang);
  }

  onSave(changeSet) {
    this.dataService.save('tDonHang', changeSet[0], changeSet[1], changeSet[2]).subscribe(p => {
      this.onLoad(undefined);
    });
  }

  onLoad(event) {
    const qe = Converter.FromHSimpleGridSettingToQueryExpression(this.grid.settings);
    this.dataService.get('tDonHang', qe).subscribe(data => {
      data.items.forEach(p => {
        p['ngay'] = p['ngay'].substring(0, 10);
        p.maKhachHangSource = this.maKhachHangSource;
        p.maKhoHangSource = this.maKhoHangSource;
        p.maChanhSource = this.getChanhByMaKhachHang(p.maKhachHang);
      });

      this.entities = data.items;
      this.grid.settings.pagingSetting.pageCount = data.pageCount;
      this.grid.settings.pagingSetting.rowCount = data.items.length;
    });
  }

  getChanhByMaKhachHang(maKhachHang) {
    const maKhachHangChanhFilteredArr = this.maKhachHangChanhArr.filter(p => p.maKhachHang === maKhachHang);
    return this.maChanhSource.filter(p => {
      return maKhachHangChanhFilteredArr.findIndex(item => item.maChanh === p.id) !== -1;
    });
  }

  actionRequireMatHang(action) {
    this.refDataService.get('tMatHang').subscribe(matHangs => {
      action(matHangs)
    });
  }
}
