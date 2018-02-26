import { Component, AfterViewInit, ViewChild, Input } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/observable/from';
import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { PartialMethodService } from '../partial-method.service';
import { ReferenceDataService } from '../reference-data.service';
import { Converter } from '../converter';

import { HSimpleGridSetting, HSimpleGridComponent } from '../shared';

@Component({
  selector: 'app-tChiPhi',
  templateUrl: './tChiPhi.component.html'
})
export class tChiPhiComponent implements AfterViewInit {
  @ViewChild(HSimpleGridComponent) grid: HSimpleGridComponent;
  @Input() name = 'view_tChiPhi';

  DataTypeEnum = HSimpleGridSetting.DataTypeEnum;
  EditorTypeEnum = HSimpleGridSetting.EditorTypeEnum;
  FilterOperatorTypeEnum = HSimpleGridSetting.FilterOperatorTypeEnum;
  OrderTypeEnum = HSimpleGridSetting.OrderTypeEnum;

  entities: Array<any>;
  className = 'tChiPhiComponent';

  maNhanVienGiaoHangSource = [];
  maLoaiChiPhiSource = [];
  
  constructor(private dataService: DataService, private refDataService: ReferenceDataService, private partialMethodService: PartialMethodService) { }

  ngAfterViewInit() {
    this.refDataService.gets(['rNhanVien', 'rLoaiChiPhi']).subscribe(data => {
      this.maNhanVienGiaoHangSource = data[0].items;
      this.grid.setHeaderItems(3, data[0].items);
      this.maLoaiChiPhiSource = data[1].items;
      this.grid.setHeaderItems(2, data[1].items);
      this.partialMethodService.loadReferenceDataPartial(this.className, [this]).subscribe(event => {
        this.onLoad(undefined);
      });
    });
  }

  onAddingItem(item) {
    item.maNhanVienGiaoHangSource = this.maNhanVienGiaoHangSource;
    item.maLoaiChiPhiSource = this.maLoaiChiPhiSource;
    this.partialMethodService.processItemPartial(this.className, [this, item]);
  }

  onSave(changeSet) {
    this.dataService.save('tChiPhi', changeSet[0], changeSet[1], changeSet[2]).subscribe(p => {
      this.onLoad(undefined);
    });
  }

  onLoad(event) {
    const qe = Converter.FromHSimpleGridSettingToQueryExpression(this.grid.settings);
    this.dataService.get('tChiPhi', qe).subscribe(data => {
      data.items.forEach(item => {
        item.maNhanVienGiaoHangSource = this.maNhanVienGiaoHangSource;
        item.maLoaiChiPhiSource = this.maLoaiChiPhiSource;
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
