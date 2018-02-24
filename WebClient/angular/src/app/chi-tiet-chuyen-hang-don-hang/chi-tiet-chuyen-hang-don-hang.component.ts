import { Component, AfterViewInit, Output, EventEmitter, ViewChild } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/observable/from';
import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { ReferenceDataService } from '../reference-data.service';
import { Converter } from '../converter';

import { ChiTietDonHangComponent } from '../chi-tiet-don-hang/chi-tiet-don-hang.component';
import { ChuyenHangDonHangComponent } from '../chuyen-hang-don-hang/chuyen-hang-don-hang.component';
import { HSimpleGridSetting, HSimpleGridComponent, HWindowComponent } from '../shared';

@Component({
  selector: 'app-chi-tiet-chuyen-hang-don-hang',
  templateUrl: './chi-tiet-chuyen-hang-don-hang.component.html',
  styleUrls: ['./chi-tiet-chuyen-hang-don-hang.component.css']
})
export class ChiTietChuyenHangDonHangComponent implements AfterViewInit {

  @ViewChild(HSimpleGridComponent) grid: HSimpleGridComponent;

  @ViewChild('windowChiTietDonHang') windowChiTietDonHang: HWindowComponent;
  @ViewChild('chiTietDonHang') chiTietDonHang: ChiTietDonHangComponent;

  @ViewChild('windowChuyenHangDonHang') windowChuyenHangDonHang: HWindowComponent;
  @ViewChild('chuyenHangDonHang') chuyenHangDonHang: ChuyenHangDonHangComponent;

  @Output() evAfterLoad = new EventEmitter();

  entities: Array<any>;

  DataTypeEnum = HSimpleGridSetting.DataTypeEnum;
  EditorTypeEnum = HSimpleGridSetting.EditorTypeEnum;
  FilterOperatorTypeEnum = HSimpleGridSetting.FilterOperatorTypeEnum;

  constructor(private dataService: DataService, private refDataService: ReferenceDataService) { }

  ngAfterViewInit() {
  }

  onAddingItem(newItem) {
    if (newItem.maChuyenHangDonHang !== undefined) {
      this.actionRequireNhanVien(nhanViens => {
        this.dataService.getByID('tChuyenHangDonHang', newItem.maChuyenHangDonHang).subscribe(chdh => {
          newItem.chuyenHangDonHang = chdh;
          this.dataService.getByID('tChuyenHang', chdh.maChuyenHang).subscribe(ch => {
            newItem.chuyenHangDonHang.chuyenHang = ch;
            newItem.chuyenHangDonHang.displayText = this.getChuyenHangDonHangDisplayText(newItem.chuyenHangDonHang, nhanViens);
          });
        });
      });
    }

    if (newItem.maChiTietDonHang !== undefined) {
      this.actionRequireKhoHangKhachHangMatHang((khoHangs, khachHangs, matHangs) => {
        this.dataService.getByID('tChiTietDonHang', newItem.maChiTietDonHang).subscribe(ctdh => {
          newItem.chiTietDonHang = ctdh;
          this.dataService.getByID('tDonHang', ctdh.maDonHang).subscribe(dh => {
            newItem.chiTietDonHang.donHang = dh;
            newItem.chiTietDonHang.displayText = this.getChiTietDonHangDisplayText(newItem.chiTietDonHang, khoHangs, khachHangs, matHangs);
          })
        });
      });
    }
  }

  onSave(changeSet) {
    this.dataService.save('tChiTietChuyenHangDonHang', changeSet[0], changeSet[1], changeSet[2]).subscribe(p => {
      this.onLoad(undefined);
    });
  }

  onLoad(event) {
    this.actionRequireKhoHangKhachHangMatHang((khoHangs, khachHangs, matHangs) => {
      this.actionRequireNhanVien(nhanViens => {
        const qe = Converter.FromHSimpleGridSettingToQueryExpression(this.grid.settings);
        this.dataService.get('tChiTietChuyenHangDonHang', qe).subscribe(ctchdh => {
          this.dataService.getIntList('tChiTietDonHang', 'id', ctchdh.items.map(p => p.maChiTietDonHang)).subscribe(ctdh => {
            this.dataService.getIntList('tChuyenHangDonHang', 'id', ctchdh.items.map(p => p.maChuyenHangDonHang)).subscribe(chdh => {
              this.dataService.getIntList('tDonHang', 'id', chdh.items.map(p => p.maDonHang)).subscribe(donHang => {
                this.dataService.getIntList('tChuyenHang', 'id', chdh.items.map(p => p.maChuyenHang)).subscribe(chuyenHang => {

                  ctchdh.items.forEach((p, index) => {
                    p.chiTietDonHang = ctdh.items.find(p1 => p1.id === p.maChiTietDonHang);
                    p.chuyenHangDonHang = chdh.items.find(p1 => p1.id === p.maChuyenHangDonHang);

                    p.chuyenHangDonHang.chuyenHang = chuyenHang.items.find(p1 => p1.id === p.chuyenHangDonHang.maChuyenHang);
                    p.chuyenHangDonHang.displayText = this.getChuyenHangDonHangDisplayText(p.chuyenHangDonHang, nhanViens);

                    p.chiTietDonHang.donHang = donHang.items.find(p1 => p1.id === p.chuyenHangDonHang.maDonHang);
                    p.chiTietDonHang.displayText = this.getChiTietDonHangDisplayText(p.chiTietDonHang, khoHangs, khachHangs, matHangs);
                  });

                  this.entities = ctchdh.items;
                  this.grid.settings.pagingSetting.pageCount = ctchdh.pageCount;
                  this.grid.settings.pagingSetting.rowCount = ctchdh.items.length;

                  this.evAfterLoad.emit();
                });
              });
            });
          });
        });
      });
    });
  }

  showChiTietDonHang(item, property) {
    this.windowChiTietDonHang.data = {
      item: item,
      property: property
    };
    if (item.chiTietDonHang !== undefined) {
      this.windowChiTietDonHang.title = item.chiTietDonHang.displayText;
    }
    this.windowChiTietDonHang.show();
  }

  selectChiTietDonHang(window: HWindowComponent) {
    if (this.chiTietDonHang.grid.selectedItem === undefined) {
      window.hide();
      return;
    }
    const item = window.data.item;
    const property = window.data.property;
    this.actionRequireKhoHangKhachHangMatHang((khoHangs, khachHangs, matHangs) => {
      item[property] = this.chiTietDonHang.grid.selectedItem.id;
      this.dataService.getByID('tDonHang', this.chiTietDonHang.grid.selectedItem.maDonHang).subscribe(donHang => {
        item.chiTietDonHang = this.chiTietDonHang.grid.selectedItem;
        item.chiTietDonHang.donHang = donHang;
        item.chiTietDonHang.displayText = this.getChiTietDonHangDisplayText(item.chiTietDonHang, khoHangs, khachHangs, matHangs);
        window.hide();
      });
    });
  }

  getChiTietDonHangDisplayText(chiTietDonHang, khoHangs, khachHangs, matHangs) {
    const donHang = chiTietDonHang.donHang;
    const tenKhachHang = khachHangs.items.find(p2 => p2.id === donHang.maKhachHang).tenKhachHang;
    const tenKho = khoHangs.items.find(p2 => p2.id === donHang.maKhoHang).tenKho;
    const tenMatHang = matHangs.items.find(p2 => p2.id === chiTietDonHang.maMatHang).tenMatHang;
    return chiTietDonHang.id + '|' + donHang.id + '|' + tenKho + '|' + tenKhachHang + '|' + tenMatHang;
  }

  showChuyenHangDonHang(item, property) {
    this.windowChuyenHangDonHang.data = {
      item: item,
      property: property
    };
    if (item.chuyenHangDonHang !== undefined) {
      this.windowChuyenHangDonHang.title = item.chuyenHangDonHang.displayText;
    }
    this.windowChuyenHangDonHang.show();
  }

  selectChuyenHangDonHang(window: HWindowComponent) {
    if (this.chuyenHangDonHang.grid.selectedItem === undefined) {
      window.hide();
      return;
    }
    const item = window.data.item;
    const property = window.data.property;
    this.actionRequireNhanVien(nhanViens => {
      item[property] = this.chuyenHangDonHang.grid.selectedItem.id;
      this.dataService.getByID('tChuyenHang', this.chuyenHangDonHang.grid.selectedItem.maChuyenHang).subscribe(chuyenHang => {
        item.chuyenHangDonHang = this.chuyenHangDonHang.grid.selectedItem;
        item.chuyenHangDonHang.chuyenHang = chuyenHang;
        item.chuyenHangDonHang.displayText = this.getChuyenHangDonHangDisplayText(item.chuyenHangDonHang, nhanViens);
        window.hide();
      });
    });
  }

  getChuyenHangDonHangDisplayText(chuyenHangDonHang, nhanViens) {
    const chuyenHang = chuyenHangDonHang.chuyenHang;
    const tenNhanVien = nhanViens.items.find(p2 => p2.id === chuyenHang.maNhanVienGiaoHang).tenNhanVien;
    return chuyenHangDonHang.id + '|' + chuyenHang.id + '|' + tenNhanVien;
  }

  actionRequireKhoHangKhachHangMatHang(action) {
    this.refDataService.gets(['rKhoHang', 'rKhachHang', 'tMatHang']).subscribe(data => {
      action(data[0], data[1], data[2]);
    });
  }

  actionRequireNhanVien(action) {
    this.refDataService.get('rNhanVien').subscribe(nhanViens => {
      action(nhanViens);
    });
  }
}
