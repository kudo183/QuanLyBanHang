import { Component, OnInit, ViewChild, Input } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { PartialMethodService } from '../partial-method.service';
import { ReferenceDataService } from '../reference-data.service';
import { Converter } from '../converter';

import { HSimpleGridSetting, HSimpleGridComponent } from '../shared';

@Component({
  selector: 'app-tNhapHang',
  templateUrl: './tNhapHang.component.html'
})
export class tNhapHangComponent implements OnInit {
  @ViewChild(HSimpleGridComponent) grid: HSimpleGridComponent;
  @Input() name = 'view_tNhapHang';
  @Input() autoLoad = true;

  DataTypeEnum = HSimpleGridSetting.DataTypeEnum;
  EditorTypeEnum = HSimpleGridSetting.EditorTypeEnum;
  FilterOperatorTypeEnum = HSimpleGridSetting.FilterOperatorTypeEnum;
  OrderTypeEnum = HSimpleGridSetting.OrderTypeEnum;

  entities: Array<any>;
  className = 'tNhapHangComponent';

  maNhanVienSource = [];
  maKhoHangSource = [];
  maNhaCungCapSource = [];
  
  constructor(private dataService: DataService, private refDataService: ReferenceDataService, private partialMethodService: PartialMethodService) { }

  ngOnInit() {
    this.grid.evAfterContentInit.subscribe(p => {
      this.partialMethodService.afterContentInitPartial(this.className, [this]);
    });

    this.refDataService.gets(['rNhanVien', 'rKhoHang', 'rNhaCungCap']).subscribe(data => {
      this.maNhanVienSource = data[0].items;
      this.grid.setHeaderItems(2, data[0].items);
      this.maKhoHangSource = data[1].items;
      this.grid.setHeaderItems(4, data[1].items);
      this.maNhaCungCapSource = data[2].items;
      this.grid.setHeaderItems(3, data[2].items);
      this.partialMethodService.loadReferenceDataPartial(this.className, [this]).subscribe(event => {
        if (this.autoLoad === true) { this.onLoad(undefined); }
      });
    });
  }

  onAddingItem(item) {
    item.maNhanVienSource = this.maNhanVienSource;
    item.maKhoHangSource = this.maKhoHangSource;
    item.maNhaCungCapSource = this.maNhaCungCapSource;
    this.partialMethodService.processItemPartial(this.className, [this, item]);
  }

  onSave(changeSet) {
    this.dataService.save('tNhapHang', changeSet[0], changeSet[1], changeSet[2]).subscribe(p => {
      this.onLoad(undefined);
    });
  }

  onLoad(event) {
    const qe = Converter.FromHSimpleGridSettingToQueryExpression(this.grid.settings);
    this.dataService.get('tNhapHang', qe).subscribe(data => {
      data.items.forEach(item => {
        item.maNhanVienSource = this.maNhanVienSource;
        item.maKhoHangSource = this.maKhoHangSource;
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
