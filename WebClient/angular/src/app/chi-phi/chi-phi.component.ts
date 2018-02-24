import { Component, AfterViewInit, ViewChild } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/observable/from';
import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { ReferenceDataService } from '../reference-data.service';
import { PartialMethodService } from '../partial-method.service';
import { Converter } from '../converter';

import { HSimpleGridSetting, HSimpleGridComponent } from '../shared';

@Component({
  selector: 'app-chi-phi',
  templateUrl: './chi-phi.component.html',
  styleUrls: ['./chi-phi.component.css']
})
export class ChiPhiComponent implements AfterViewInit {
  @ViewChild(HSimpleGridComponent) grid: HSimpleGridComponent;

  maLoaiChiPhiSource = [];
  maNhanVienGiaoHangSource = [];

  entities: Array<any>;

  DataTypeEnum = HSimpleGridSetting.DataTypeEnum;
  EditorTypeEnum = HSimpleGridSetting.EditorTypeEnum;
  FilterOperatorTypeEnum = HSimpleGridSetting.FilterOperatorTypeEnum;

  constructor(private dataService: DataService, private refDataService: ReferenceDataService) { }

  ngAfterViewInit() {
    this.refDataService.gets(['rloaichiphi', 'rnhanvien']).subscribe(data => {
      const loaiChiPhis = data[0];
      const nhanViens = data[1];
      this.maLoaiChiPhiSource = loaiChiPhis.items;
      this.grid.setHeaderItems(2, loaiChiPhis.items);
      this.maNhanVienGiaoHangSource = nhanViens.items;
      this.grid.setHeaderItems(3, nhanViens.items);
      this.onLoad(undefined);
    });
  }

  onAddingItem(newItem) {
    newItem.maLoaiChiPhiSource = this.maLoaiChiPhiSource;
    newItem.maNhanVienGiaoHangSource = this.maNhanVienGiaoHangSource;
  }

  onSave(changeSet) {
    this.dataService.save('tchiphi', changeSet[0], changeSet[1], changeSet[2]).subscribe(p => {
      this.onLoad(undefined);
    });
  }

  onLoad(event) {
    const qe = Converter.FromHSimpleGridSettingToQueryExpression(this.grid.settings);
    this.dataService.get('tChiPhi', qe).subscribe(data => {
      data.items.forEach(p => {
        p['ngay'] = p['ngay'].substring(0, 10);
        p.maLoaiChiPhiSource = this.maLoaiChiPhiSource;
        p.maNhanVienGiaoHangSource = this.maNhanVienGiaoHangSource;
      });

      this.entities = data.items;
      this.grid.settings.pagingSetting.pageCount = data.pageCount;
      this.grid.settings.pagingSetting.rowCount = data.items.length;
    });
  }
}
