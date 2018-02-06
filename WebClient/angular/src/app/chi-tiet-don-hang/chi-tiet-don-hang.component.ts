import { Component, OnInit, ViewChild } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/observable/from';
import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { Converter } from '../converter';

import { HSimpleGridSetting, HSimpleGridComponent } from '../shared';

@Component({
  selector: 'app-chi-tiet-don-hang',
  templateUrl: './chi-tiet-don-hang.component.html',
  styleUrls: ['./chi-tiet-don-hang.component.css']
})
export class ChiTietDonHangComponent implements OnInit {
  @ViewChild(HSimpleGridComponent) grid: HSimpleGridComponent;

  maMatHangSource = [];

  entities: Array<any>;

  DataTypeEnum = HSimpleGridSetting.DataTypeEnum;
  EditorTypeEnum = HSimpleGridSetting.EditorTypeEnum;
  FilterOperatorTypeEnum = HSimpleGridSetting.FilterOperatorTypeEnum;

  constructor(private dataService: DataService) {
    console.log('constructor: ');
  }

  ngOnInit() {
    console.log('chi-tiet-don-hang ngOnInit');
    this.dataService.getAll('tmathang').subscribe(data => {
      this.maMatHangSource = data.items;
      this.grid.settings.columnSettings[2].headerSetting.items = data.items;
    });
  }

  print() {
    console.log('don-hang print');
    this.entities.forEach(item => {
      console.log(JSON.stringify(item));
    });
  }

  onAddingItem(newItem) {
    newItem.maMatHangSource = this.maMatHangSource;
  }

  onSave(changeSet) {
    console.log('onSave: ');
    console.log('added: ' + changeSet[0].length + '  ' + JSON.stringify(changeSet[0]));
    console.log('deleted: ' + changeSet[1].length + '  ' + JSON.stringify(changeSet[1]));
    console.log('changed: ' + changeSet[2].length + '  ' + JSON.stringify(changeSet[2]));
  }

  onLoad(event) {
    const qe = Converter.FromHSimpleGridSettingToQueryExpression(this.grid.settings);
    this.dataService.get('tChiTietDonHang', qe).subscribe(data => {
      data.items.forEach(p => {
        p.maMatHangSource = this.maMatHangSource;
      });

      this.entities = data.items;
      this.grid.settings.pagingSetting.pageCount = data.pageCount;
      this.grid.settings.pagingSetting.rowCount = data.items.length;
    });
  }

  onFilterChanged(event) {
    console.log('onFilterChanged');
  }
}
