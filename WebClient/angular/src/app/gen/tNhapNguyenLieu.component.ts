﻿import { Component, OnInit, AfterViewInit, ViewChild, Input } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { PartialMethodService } from '../partial-method.service';
import { ReferenceDataService } from '../reference-data.service';
import { Converter } from '../converter';

import { HSimpleGridSetting, HSimpleGridComponent } from '../shared';

@Component({
  selector: 'app-tNhapNguyenLieu',
  templateUrl: './tNhapNguyenLieu.component.html'
})
export class tNhapNguyenLieuComponent implements OnInit, AfterViewInit {
  @ViewChild(HSimpleGridComponent) grid: HSimpleGridComponent;
  @Input() name = 'view_tNhapNguyenLieu';

  DataTypeEnum = HSimpleGridSetting.DataTypeEnum;
  EditorTypeEnum = HSimpleGridSetting.EditorTypeEnum;
  FilterOperatorTypeEnum = HSimpleGridSetting.FilterOperatorTypeEnum;
  OrderTypeEnum = HSimpleGridSetting.OrderTypeEnum;

  entities: Array<any>;
  className = 'tNhapNguyenLieuComponent';

  maNguyenLieuSource = [];
  maNhaCungCapSource = [];
  
  constructor(private dataService: DataService, private refDataService: ReferenceDataService, private partialMethodService: PartialMethodService) { }

  ngOnInit() {
    this.grid.evAfterContentInit.subscribe(p => {
      this.partialMethodService.afterContentInitPartial(this.className, [this]);
    });
  }

  ngAfterViewInit() {
    this.refDataService.gets(['rNguyenLieu', 'rNhaCungCap']).subscribe(data => {
      this.maNguyenLieuSource = data[0].items;
      this.grid.setHeaderItems(2, data[0].items);
      this.maNhaCungCapSource = data[1].items;
      this.grid.setHeaderItems(3, data[1].items);
      this.partialMethodService.loadReferenceDataPartial(this.className, [this]).subscribe(event => {
        this.onLoad(undefined);
      });
    });
  }

  onAddingItem(item) {
    item.maNguyenLieuSource = this.maNguyenLieuSource;
    item.maNhaCungCapSource = this.maNhaCungCapSource;
    this.partialMethodService.processItemPartial(this.className, [this, item]);
  }

  onSave(changeSet) {
    this.dataService.save('tNhapNguyenLieu', changeSet[0], changeSet[1], changeSet[2]).subscribe(p => {
      this.onLoad(undefined);
    });
  }

  onLoad(event) {
    const qe = Converter.FromHSimpleGridSettingToQueryExpression(this.grid.settings);
    this.dataService.get('tNhapNguyenLieu', qe).subscribe(data => {
      data.items.forEach(item => {
        item.maNguyenLieuSource = this.maNguyenLieuSource;
        item.maNhaCungCapSource = this.maNhaCungCapSource;
      });
      
      this.partialMethodService.processItemListPartial(this.className, [this, data]).subscribe(event => {
        this.entities = data.items;
        this.grid.settings.pagingSetting.pageCount = data.pageCount;
        this.grid.settings.pagingSetting.rowCount = data.items.length;

        this.partialMethodService.afterLoadPartial(this.className, [this]);
      });
    });
  }
}
