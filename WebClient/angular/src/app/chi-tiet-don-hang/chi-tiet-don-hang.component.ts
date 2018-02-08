import { Component, OnInit, ViewChild } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/observable/from';
import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { ReferenceDataService } from '../reference-data.service';
import { Converter } from '../converter';

import { DonHangComponent } from '../don-hang/don-hang.component';
import { HSimpleGridSetting, HSimpleGridComponent, HWindowComponent } from '../shared';

@Component({
  selector: 'app-chi-tiet-don-hang',
  templateUrl: './chi-tiet-don-hang.component.html',
  styleUrls: ['./chi-tiet-don-hang.component.css']
})
export class ChiTietDonHangComponent implements OnInit {
  @ViewChild(HSimpleGridComponent) grid: HSimpleGridComponent;

  @ViewChild('windowDonHang') windowDonHang: HWindowComponent;
  @ViewChild('donHang') donHang: DonHangComponent;

  maMatHangSource = [];

  entities: Array<any>;

  DataTypeEnum = HSimpleGridSetting.DataTypeEnum;
  EditorTypeEnum = HSimpleGridSetting.EditorTypeEnum;
  FilterOperatorTypeEnum = HSimpleGridSetting.FilterOperatorTypeEnum;

  constructor(private dataService: DataService, private refDataService: ReferenceDataService) {
    console.log('constructor: ');
  }

  ngOnInit() {
    console.log('chi-tiet-don-hang ngOnInit');

    this.donHang.grid.evSelectedItemChanged.subscribe(item => {
      this.refDataService.get('rkhohang').subscribe(khoHangs => {
        this.refDataService.get('rkhachhang').subscribe(khachHangs => {
          this.windowDonHang.title = this.getDonHangDisplayText(item, khoHangs, khachHangs);
        });
      });
    });

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
    this.refDataService.get('rkhohang').subscribe(khoHangs => {
      this.refDataService.get('rkhachhang').subscribe(khachHangs => {
        const qe = Converter.FromHSimpleGridSettingToQueryExpression(this.grid.settings);
        this.dataService.get('tChiTietDonHang', qe).subscribe(ctdh => {
          this.dataService.getIntList('tDonHang', 'id', ctdh.items.map(p => p.maDonHang)).subscribe(dh => {
            ctdh.items.forEach(p => {
              p.maMatHangSource = this.maMatHangSource;

              p.donHang = dh.items.find(p1 => p1.id === p.maDonHang);
              p.donHang.displayText = this.getDonHangDisplayText(p.donHang, khoHangs, khachHangs);
            });

            this.entities = ctdh.items;
            this.grid.settings.pagingSetting.pageCount = ctdh.pageCount;
            this.grid.settings.pagingSetting.rowCount = ctdh.items.length;
          });
        });
      });
    });
  }

  showDonHang(item, property) {
    this.windowDonHang.data = {
      item: item,
      property: property
    };
    if (item.donHang !== undefined) {
      this.windowDonHang.title = item.donHang.displayText;
    }
    this.windowDonHang.show();
  }

  selectDonHang(window: HWindowComponent) {
    if (this.donHang.grid.selectedItem === undefined) {
      window.hide();
      return;
    }
    const item = window.data.item;
    const property = window.data.property;
    this.refDataService.get('rkhohang').subscribe(khoHangs => {
      this.refDataService.get('rkhachhang').subscribe(khachHangs => {
        item[property] = this.donHang.grid.selectedItem.id;
        item.donHang = this.donHang.grid.selectedItem;
        item.donHang.displayText = this.getDonHangDisplayText(item.donHang, khoHangs, khachHangs);
        window.hide();
      });
    });
  }

  getDonHangDisplayText(donHang, khoHangs, khachHangs) {
    const tenKhachHang = khachHangs.items.find(p2 => p2.id === donHang.maKhachHang).tenKhachHang;
    const tenKho = khoHangs.items.find(p2 => p2.id === donHang.maKhoHang).tenKho;
    return donHang.id + '|' + tenKho + '|' + tenKhachHang;
  }
}
