import { Component, OnInit, ViewChild, Input } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/observable/from';
import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { ReferenceDataService } from '../reference-data.service';
import { Converter } from '../converter';

import { HSimpleGridSetting, HSimpleGridComponent } from '../shared';

@Component({
  selector: 'app-chuyen-hang',
  templateUrl: './chuyen-hang.component.html',
  styleUrls: ['./chuyen-hang.component.css']
})
export class ChuyenHangComponent implements OnInit {

  @ViewChild(HSimpleGridComponent) grid: HSimpleGridComponent;
  @Input() name = 'viewChuyenHang';
  maNhanVienSource = [];

  entities: Array<any>;

  DataTypeEnum = HSimpleGridSetting.DataTypeEnum;
  EditorTypeEnum = HSimpleGridSetting.EditorTypeEnum;
  FilterOperatorTypeEnum = HSimpleGridSetting.FilterOperatorTypeEnum;

  constructor(private dataService: DataService, private refDataService: ReferenceDataService) {
    console.log('constructor: ');
  }

  ngOnInit() {
    console.log('chuyen-hang ngOnInit');
    this.grid.evAfterInit.subscribe(event => {
      this.refDataService.get('rnhanvien').subscribe(nhanViens => {
        this.maNhanVienSource = nhanViens.items;
        this.grid.setHeaderItems(2, nhanViens.items);
      });
    });
  }

  onAddingItem(newItem) {
    newItem.maNhanVienSource = this.maNhanVienSource;
  }

  onSave(changeSet) {
    console.log('onSave: ');
    console.log('added: ' + changeSet[0].length + '  ' + JSON.stringify(changeSet[0]));
    console.log('deleted: ' + changeSet[1].length + '  ' + JSON.stringify(changeSet[1]));
    console.log('changed: ' + changeSet[2].length + '  ' + JSON.stringify(changeSet[2]));
  }

  onLoad(event) {
    const qe = Converter.FromHSimpleGridSettingToQueryExpression(this.grid.settings);
    this.dataService.get('tChuyenHang', qe).subscribe(data => {
      data.items.forEach(p => {
        p['ngay'] = p['ngay'].substring(0, 10);
        p.maNhanVienSource = this.maNhanVienSource;
      });

      this.entities = data.items;
      this.grid.settings.pagingSetting.pageCount = data.pageCount;
      this.grid.settings.pagingSetting.rowCount = data.items.length;
    });
  }
}
