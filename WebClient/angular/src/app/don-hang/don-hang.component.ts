import { Component, OnInit, ViewChild } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/observable/from';
import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { Converter } from '../converter';

import { HSimpleGridSetting, HSimpleGridComponent } from '../shared';

@Component({
  selector: 'app-don-hang',
  templateUrl: './don-hang.component.html',
  styleUrls: ['./don-hang.component.css']
})
export class DonHangComponent implements OnInit {
  @ViewChild(HSimpleGridComponent) grid: HSimpleGridComponent;

  maKhachHangSource = [];
  maKhoHangSource = [];
  maChanhSource = [];

  maKhachHangChanhArr = [];

  entities: Array<any>;

  DataTypeEnum = HSimpleGridSetting.DataTypeEnum;
  EditorTypeEnum = HSimpleGridSetting.EditorTypeEnum;
  FilterOperatorTypeEnum = HSimpleGridSetting.FilterOperatorTypeEnum;
  OrderTypeEnum = HSimpleGridSetting.OrderTypeEnum;

  constructor(private dataService: DataService) {
    console.log('constructor: ');
  }

  ngOnInit() {
    console.log('don-hang ngOnInit');
    this.dataService.getAll('rkhachhangchanh').subscribe(data => {
      this.maKhachHangChanhArr = data.items;
    });

    this.dataService.getAll('rkhachhang').subscribe(data => {
      this.maKhachHangSource = data.items;
      this.grid.settings.columnSettings[2].headerSetting.items = data.items;
    });
    this.dataService.getAll('rkhohang').subscribe(data => {
      this.maKhoHangSource = data.items;
      this.grid.settings.columnSettings[3].headerSetting.items = data.items;
    });
    this.dataService.getAll('rchanh').subscribe(data => {
      this.maChanhSource = data.items;
      this.grid.settings.columnSettings[4].headerSetting.items = data.items;
    });
  }

  print() {
    console.log('don-hang print');
    this.entities.forEach(item => {
      console.log(JSON.stringify(item));
    });
  }

  onAddingItem(newItem) {
    newItem.maKhachHangSource = this.maKhachHangSource;
    newItem.maKhoHangSource = this.maKhoHangSource;
    newItem.maChanhSource = this.getChanhByMaKhachHang(newItem.maKhachHang);
  }

  onSave(changeSet) {
    console.log('onSave: ');
    console.log('added: ' + changeSet[0].length + '  ' + JSON.stringify(changeSet[0]));
    console.log('deleted: ' + changeSet[1].length + '  ' + JSON.stringify(changeSet[1]));
    console.log('changed: ' + changeSet[2].length + '  ' + JSON.stringify(changeSet[2]));
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

  onFilterChanged(event) {
    console.log('onFilterChanged');
  }

  getChanhByMaKhachHang(maKhachHang) {
    const maKhachHangChanhFilteredArr = this.maKhachHangChanhArr.filter(p => p.maKhachHang === maKhachHang);
    return this.maChanhSource.filter(p => {
      return maKhachHangChanhFilteredArr.findIndex(item => item.maChanh === p.id) !== -1;
    });
  }
}
