import { Component, OnInit, ViewChild, Input } from '@angular/core';

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
export class DonHangComponent implements OnInit {
  @ViewChild(HSimpleGridComponent) grid: HSimpleGridComponent;
  @Input() name='viewDonHang';

  maKhachHangSource = [];
  maKhoHangSource = [];
  maChanhSource = [];

  maKhachHangChanhArr = [];

  entities: Array<any>;

  DataTypeEnum = HSimpleGridSetting.DataTypeEnum;
  EditorTypeEnum = HSimpleGridSetting.EditorTypeEnum;
  FilterOperatorTypeEnum = HSimpleGridSetting.FilterOperatorTypeEnum;
  OrderTypeEnum = HSimpleGridSetting.OrderTypeEnum;

  constructor(private dataService: DataService, private refDataService: ReferenceDataService) {
    console.log('constructor: ');
  }

  ngOnInit() {
    console.log('don-hang ngOnInit');
    this.grid.evAfterInit.subscribe(event => {
      this.refDataService.get('rkhachhangchanh').subscribe(khachHangChanhs => {
        this.refDataService.get('rkhachhang').subscribe(khachHangs => {
          this.refDataService.get('rkhohang').subscribe(khoHangs => {
            this.refDataService.get('rchanh').subscribe(chanhs => {
              this.maKhachHangChanhArr = khachHangChanhs.items;
              this.maKhachHangSource = khachHangs.items;
              this.grid.setHeaderItems(2, khachHangs.items);
              this.maKhoHangSource = khoHangs.items;
              this.grid.setHeaderItems(3, khoHangs.items);
              this.maChanhSource = chanhs.items;
              this.grid.setHeaderItems(4, chanhs.items);
              this.onLoad(undefined);
            });
          });
        });
      });
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

  getChanhByMaKhachHang(maKhachHang) {
    const maKhachHangChanhFilteredArr = this.maKhachHangChanhArr.filter(p => p.maKhachHang === maKhachHang);
    return this.maChanhSource.filter(p => {
      return maKhachHangChanhFilteredArr.findIndex(item => item.maChanh === p.id) !== -1;
    });
  }
}
