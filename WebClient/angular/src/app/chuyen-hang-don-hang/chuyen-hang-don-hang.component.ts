import { Component, OnInit, ViewChild, Input } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/observable/from';
import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { ReferenceDataService } from '../reference-data.service';
import { Converter } from '../converter';

import { DonHangComponent } from '../don-hang/don-hang.component';
import { ChuyenHangComponent } from '../chuyen-hang/chuyen-hang.component';
import { HSimpleGridSetting, HSimpleGridComponent, HWindowComponent } from '../shared';

@Component({
  selector: 'app-chuyen-hang-don-hang',
  templateUrl: './chuyen-hang-don-hang.component.html',
  styleUrls: ['./chuyen-hang-don-hang.component.css']
})
export class ChuyenHangDonHangComponent implements OnInit {

  @ViewChild(HSimpleGridComponent) grid: HSimpleGridComponent;
  @ViewChild('windowDonHang') windowDonHang: HWindowComponent;
  @ViewChild('donHang') donHang: DonHangComponent;

  @ViewChild('windowChuyenHang') windowChuyenHang: HWindowComponent;
  @ViewChild('chuyenHang') chuyenHang: ChuyenHangComponent;

  @Input() name = 'viewChuyenHangDonHang';

  entities: Array<any>;

  DataTypeEnum = HSimpleGridSetting.DataTypeEnum;
  EditorTypeEnum = HSimpleGridSetting.EditorTypeEnum;
  FilterOperatorTypeEnum = HSimpleGridSetting.FilterOperatorTypeEnum;

  constructor(private dataService: DataService, private refDataService: ReferenceDataService) {
  }

  ngOnInit() {
    console.log('chuyen-hang-don-hang ngOnInit');

    this.donHang.grid.evSelectedItemChanged.subscribe(item => {
      this.actionRequireKhoHangKhachHang((khoHangs, khachHangs) => {
        this.windowDonHang.title = this.getDonHangDisplayText(item, khoHangs, khachHangs);
      });
    });

    this.chuyenHang.grid.evSelectedItemChanged.subscribe(item => {
      this.actionRequireNhanVien(nhanViens => {
        this.windowChuyenHang.title = this.getChuyenHangDisplayText(item, nhanViens);
      });
    });
  }

  onAddingItem(newItem) {
    if (newItem.maDonHang !== undefined) {
      this.actionRequireKhoHangKhachHang((khoHangs, khachHangs) => {
        this.dataService.getByID('tDonHang', newItem.maDonHang).subscribe(dh => {
          newItem.donHang = dh;
          newItem.donHang.displayText = this.getDonHangDisplayText(newItem.donHang, khoHangs, khachHangs);
        });
      });
    }
    if (newItem.maChuyenHang !== undefined) {
      this.actionRequireNhanVien(nhanViens => {
        this.dataService.getByID('tChuyenHang', newItem.maChuyenHang).subscribe(ch => {
          newItem.chuyenHang = ch;
          newItem.chuyenHang.displayText = this.getChuyenHangDisplayText(newItem.chuyenHang, nhanViens);
        })
      });
    }
  }

  onSave(changeSet) {
    this.dataService.save('tChuyenHangDonHang', changeSet[0], changeSet[1], changeSet[2]).subscribe(p => {
      this.onLoad(undefined);
    });
  }

  onLoad(event) {
    this.actionRequireKhoHangKhachHang((khoHangs, khachHangs) => {
      this.actionRequireNhanVien(nhanViens => {
        const qe = Converter.FromHSimpleGridSettingToQueryExpression(this.grid.settings);
        this.dataService.get('tChuyenHangDonHang', qe).subscribe(chdh => {
          this.dataService.getIntList('tDonHang', 'id', chdh.items.map(p => p.maDonHang)).subscribe(dh => {
            this.dataService.getIntList('tChuyenHang', 'id', chdh.items.map(p => p.maChuyenHang)).subscribe(ch => {
              chdh.items.forEach(p => {
                p.donHang = dh.items.find(p1 => p1.id === p.maDonHang);
                p.donHang.displayText = this.getDonHangDisplayText(p.donHang, khoHangs, khachHangs);

                p.chuyenHang = ch.items.find(p1 => p1.id === p.maChuyenHang);
                p.chuyenHang.displayText = this.getChuyenHangDisplayText(p.chuyenHang, nhanViens);
              });
              this.entities = chdh.items;
              this.grid.settings.pagingSetting.pageCount = chdh.pageCount;
              this.grid.settings.pagingSetting.rowCount = chdh.items.length;
            });
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
    this.actionRequireKhoHangKhachHang((khoHangs, khachHangs) => {
      item[property] = this.donHang.grid.selectedItem.id;
      item.donHang = this.donHang.grid.selectedItem;
      item.donHang.displayText = this.getDonHangDisplayText(item.donHang, khoHangs, khachHangs);
      window.hide();
    });
  }

  showChuyenHang(item, property) {
    this.windowChuyenHang.data = {
      item: item,
      property: property
    };
    if (item.chuyenHang !== undefined) {
      this.windowChuyenHang.title = item.chuyenHang.displayText;
    }
    this.windowChuyenHang.show();
  }

  selectChuyenHang(window: HWindowComponent) {
    if (this.chuyenHang.grid.selectedItem === undefined) {
      window.hide();
      return;
    }
    const item = window.data.item;
    const property = window.data.property;
    this.actionRequireNhanVien(nhanViens => {
      item[property] = this.chuyenHang.grid.selectedItem.id;
      item.chuyenHang = this.chuyenHang.grid.selectedItem;
      item.chuyenHang.displayText = this.getChuyenHangDisplayText(item.chuyenHang, nhanViens);
      window.hide();
    });
  }

  getDonHangDisplayText(donHang, khoHangs, khachHangs) {
    const tenKhachHang = khachHangs.items.find(p2 => p2.id === donHang.maKhachHang).tenKhachHang;
    const tenKho = khoHangs.items.find(p2 => p2.id === donHang.maKhoHang).tenKho;
    return donHang.id + '|' + tenKho + '|' + tenKhachHang;
  }

  getChuyenHangDisplayText(chuyenHang, rnhanViens) {
    const tenNhanVien = rnhanViens.items.find(p2 => p2.id === chuyenHang.maNhanVienGiaoHang).tenNhanVien;
    return chuyenHang.id + '|' + tenNhanVien;
  }

  actionRequireKhoHangKhachHang(action) {
    this.refDataService.gets(['rKhoHang', 'rKhachHang']).subscribe(data => {
      action(data[0], data[1]);
    });
  }

  actionRequireNhanVien(action) {
    this.refDataService.get('rNhanVien').subscribe(nhanViens => {
      action(nhanViens);
    });
  }
}
