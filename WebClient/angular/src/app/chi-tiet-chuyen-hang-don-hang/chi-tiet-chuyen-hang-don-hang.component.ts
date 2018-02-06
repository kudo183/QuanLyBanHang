import { Component, OnInit, ViewChild } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/observable/from';
import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { Converter } from '../converter';

import { HSimpleGridSetting, HSimpleGridComponent } from '../shared';

@Component({
  selector: 'app-chi-tiet-chuyen-hang-don-hang',
  templateUrl: './chi-tiet-chuyen-hang-don-hang.component.html',
  styleUrls: ['./chi-tiet-chuyen-hang-don-hang.component.css']
})
export class ChiTietChuyenHangDonHangComponent implements OnInit {

  @ViewChild(HSimpleGridComponent) grid: HSimpleGridComponent;

  entities: Array<any>;

  DataTypeEnum = HSimpleGridSetting.DataTypeEnum;
  EditorTypeEnum = HSimpleGridSetting.EditorTypeEnum;
  FilterOperatorTypeEnum = HSimpleGridSetting.FilterOperatorTypeEnum;

  constructor(private dataService: DataService) {
    console.log('constructor: ');
  }

  ngOnInit() {
    console.log('chi-tiet-chuyen-hang-don-hang ngOnInit');
  }

  onAddingItem(newItem) {
  }

  onSave(changeSet) {
    console.log('onSave: ');
    console.log('added: ' + changeSet[0].length + '  ' + JSON.stringify(changeSet[0]));
    console.log('deleted: ' + changeSet[1].length + '  ' + JSON.stringify(changeSet[1]));
    console.log('changed: ' + changeSet[2].length + '  ' + JSON.stringify(changeSet[2]));
  }

  onLoad(event) {
    const qe = Converter.FromHSimpleGridSettingToQueryExpression(this.grid.settings);
    this.dataService.get('tChiTietChuyenHangDonHang', qe).subscribe(data => {

      this.entities = data.items;
      this.grid.settings.pagingSetting.pageCount = data.pageCount;
      this.grid.settings.pagingSetting.rowCount = data.items.length;
    });
  }

  onFilterChanged(event) {
    console.log('onFilterChanged');
  }
}
