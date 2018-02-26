﻿import { Component, AfterViewInit, ViewChild, Input } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/observable/from';
import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { PartialMethodService } from '../partial-method.service';
import { ReferenceDataService } from '../reference-data.service';
import { Converter } from '../converter';

import { HSimpleGridSetting, HSimpleGridComponent } from '../shared';

@Component({
  selector: 'app-rNguyenLieu',
  templateUrl: './rNguyenLieu.component.html'
})
export class rNguyenLieuComponent implements AfterViewInit {
  @ViewChild(HSimpleGridComponent) grid: HSimpleGridComponent;
  @Input() name = 'view_rNguyenLieu';

  DataTypeEnum = HSimpleGridSetting.DataTypeEnum;
  EditorTypeEnum = HSimpleGridSetting.EditorTypeEnum;
  FilterOperatorTypeEnum = HSimpleGridSetting.FilterOperatorTypeEnum;
  OrderTypeEnum = HSimpleGridSetting.OrderTypeEnum;

  entities: Array<any>;
  className = 'rNguyenLieuComponent';

  maLoaiNguyenLieuSource = [];
  
  constructor(private dataService: DataService, private refDataService: ReferenceDataService, private partialMethodService: PartialMethodService) { }

  ngAfterViewInit() {
    this.refDataService.gets(['rLoaiNguyenLieu']).subscribe(data => {
      this.maLoaiNguyenLieuSource = data[0].items;
      this.grid.setHeaderItems(1, data[0].items);
      this.partialMethodService.loadReferenceDataPartial(this.className, [this]).subscribe(event => {
        this.onLoad(undefined);
      });
    });
  }

  onAddingItem(item) {
    item.maLoaiNguyenLieuSource = this.maLoaiNguyenLieuSource;
    this.partialMethodService.processItemPartial(this.className, [this, item]);
  }

  onSave(changeSet) {
    this.dataService.save('rNguyenLieu', changeSet[0], changeSet[1], changeSet[2]).subscribe(p => {
      this.onLoad(undefined);
    });
  }

  onLoad(event) {
    const qe = Converter.FromHSimpleGridSettingToQueryExpression(this.grid.settings);
    this.dataService.get('rNguyenLieu', qe).subscribe(data => {
      data.items.forEach(item => {
        item.maLoaiNguyenLieuSource = this.maLoaiNguyenLieuSource;
      });
      
      this.partialMethodService.processItemListPartial(this.className, [this, data]).subscribe(event => {
        this.entities = data.items;
        this.grid.settings.pagingSetting.pageCount = data.pageCount;
        this.grid.settings.pagingSetting.rowCount = data.items.length;

        this.partialMethodService.afterLoadPartial(this.className, [this]);
      });
    });
  }

  getDisplayText(itemID): Observable<string> {
    return this.partialMethodService.getDisplayText(this.className, [this, itemID]);
  }
}
