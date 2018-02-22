import { Component, OnInit, ViewChild, Input } from '@angular/core';

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
  @Input() name = 'viewChiTietDonHang';

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

    this.grid.evAfterInit.subscribe(event => {
      this.refDataService.get('tmathang').subscribe(matHangs => {
        this.maMatHangSource = matHangs.items;
        this.grid.setHeaderItems(2, matHangs.items);
      });
    });
  }

  onAddingItem(newItem) {
    newItem.maMatHangSource = this.maMatHangSource;
    if (newItem.maDonHang !== undefined) {
      this.refDataService.get('rkhohang').subscribe(khoHangs => {
        this.refDataService.get('rkhachhang').subscribe(khachHangs => {
          this.dataService.getByID('tDonHang', newItem.maDonHang).subscribe(p => {
            newItem.donHang = p;
            newItem.donHang.displayText = this.getDonHangDisplayText(newItem.donHang, khoHangs, khachHangs);
          });
        });
      });
    }
  }

  onSave(changeSet) {
    this.dataService.save('tChiTietDonHang', changeSet[0], changeSet[1], changeSet[2]).subscribe(p => {
      this.onLoad(undefined);
    });
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
