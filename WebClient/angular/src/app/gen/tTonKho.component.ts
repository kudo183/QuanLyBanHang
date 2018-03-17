import { Component, OnInit, ViewChild, Input } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { PartialMethodService } from '../partial-method.service';
import { ReferenceDataService } from '../reference-data.service';
import { Converter } from '../converter';

import { HSimpleGridSetting, HSimpleGridComponent } from '../shared';

@Component({
  selector: 'app-tTonKho',
  templateUrl: './tTonKho.component.html'
})
export class tTonKhoComponent implements OnInit {
  @ViewChild(HSimpleGridComponent) grid: HSimpleGridComponent;
  @Input() name = 'view_tTonKho';
  @Input() autoLoad = true;

  DataTypeEnum = HSimpleGridSetting.DataTypeEnum;
  EditorTypeEnum = HSimpleGridSetting.EditorTypeEnum;
  FilterOperatorTypeEnum = HSimpleGridSetting.FilterOperatorTypeEnum;
  OrderTypeEnum = HSimpleGridSetting.OrderTypeEnum;

  entities: Array<any>;
  className = 'tTonKhoComponent';

  maKhoHangSource = [];
  maMatHangSource = [];
  
  constructor(private dataService: DataService, private refDataService: ReferenceDataService, private partialMethodService: PartialMethodService) { }

  ngOnInit() {
    this.grid.evAfterContentInit.subscribe(p => {
      this.partialMethodService.afterContentInitPartial(this.className, [this]);

      this.refDataService.gets(['rKhoHang', 'tMatHang']).subscribe(data => {
        this.maKhoHangSource = data[0].items;
        this.grid.setHeaderItems(3, data[0].items);
        this.maMatHangSource = data[1].items;
        this.grid.setHeaderItems(2, data[1].items);
        this.partialMethodService.loadReferenceDataPartial(this.className, [this]).subscribe(event => {
          if (this.autoLoad === true) { this.onLoad(undefined); }
        });
      });
    });
  }

  onAddingItem(item) {
    item.maKhoHangSource = this.maKhoHangSource;
    item.maMatHangSource = this.maMatHangSource;
    this.partialMethodService.processItemPartial(this.className, [this, item]);
  }

  onSave(changeSet) {
    this.dataService.save('tTonKho', changeSet[0], changeSet[1], changeSet[2]).subscribe(p => {
      this.onLoad(undefined);
    });
  }

  onLoad(event) {
    const qe = Converter.FromHSimpleGridSettingToQueryExpression(this.grid.settings);
    this.dataService.get('tTonKho', qe).subscribe(data => {
      data.items.forEach(item => {
        item.maKhoHangSource = this.maKhoHangSource;
        item.maMatHangSource = this.maMatHangSource;
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
