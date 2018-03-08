import { Component, OnInit, AfterViewInit, ViewChild, Input } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { PartialMethodService } from '../partial-method.service';
import { ReferenceDataService } from '../reference-data.service';
import { Converter } from '../converter';

import { HSimpleGridSetting, HSimpleGridComponent } from '../shared';

@Component({
  selector: 'app-tChuyenKho',
  templateUrl: './tChuyenKho.component.html'
})
export class tChuyenKhoComponent implements OnInit, AfterViewInit {
  @ViewChild(HSimpleGridComponent) grid: HSimpleGridComponent;
  @Input() name = 'view_tChuyenKho';

  DataTypeEnum = HSimpleGridSetting.DataTypeEnum;
  EditorTypeEnum = HSimpleGridSetting.EditorTypeEnum;
  FilterOperatorTypeEnum = HSimpleGridSetting.FilterOperatorTypeEnum;
  OrderTypeEnum = HSimpleGridSetting.OrderTypeEnum;

  entities: Array<any>;
  className = 'tChuyenKhoComponent';

  maNhanVienSource = [];
  maKhoHangXuatSource = [];
  maKhoHangNhapSource = [];
  
  constructor(private dataService: DataService, private refDataService: ReferenceDataService, private partialMethodService: PartialMethodService) { }

  ngOnInit() {
    this.grid.evAfterContentInit.subscribe(p => {
      this.partialMethodService.afterContentInitPartial(this.className, [this]);
    });
  }

  ngAfterViewInit() {
    this.refDataService.gets(['rNhanVien', 'rKhoHang', 'rKhoHang']).subscribe(data => {
      this.maNhanVienSource = data[0].items;
      this.grid.setHeaderItems(2, data[0].items);
      this.maKhoHangXuatSource = data[1].items;
      this.grid.setHeaderItems(3, data[1].items);
      this.maKhoHangNhapSource = data[2].items;
      this.grid.setHeaderItems(4, data[2].items);
      this.partialMethodService.loadReferenceDataPartial(this.className, [this]).subscribe(event => {
        this.onLoad(undefined);
      });
    });
  }

  onAddingItem(item) {
    item.maNhanVienSource = this.maNhanVienSource;
    item.maKhoHangXuatSource = this.maKhoHangXuatSource;
    item.maKhoHangNhapSource = this.maKhoHangNhapSource;
    this.partialMethodService.processItemPartial(this.className, [this, item]);
  }

  onSave(changeSet) {
    this.dataService.save('tChuyenKho', changeSet[0], changeSet[1], changeSet[2]).subscribe(p => {
      this.onLoad(undefined);
    });
  }

  onLoad(event) {
    const qe = Converter.FromHSimpleGridSettingToQueryExpression(this.grid.settings);
    this.dataService.get('tChuyenKho', qe).subscribe(data => {
      data.items.forEach(item => {
        item.maNhanVienSource = this.maNhanVienSource;
        item.maKhoHangXuatSource = this.maKhoHangXuatSource;
        item.maKhoHangNhapSource = this.maKhoHangNhapSource;
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
