import { Component, OnInit, ViewChild } from '@angular/core';

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
export class ChiTietChuyenHangDonHangComponent implements OnInit {

  @ViewChild(HSimpleGridComponent) grid: HSimpleGridComponent;

  @ViewChild('windowChiTietDonHang') windowChiTietDonHang: HWindowComponent;
  @ViewChild('chiTietDonHang') chiTietDonHang: ChiTietDonHangComponent;

  @ViewChild('windowChuyenHangDonHang') windowChuyenHangDonHang: HWindowComponent;
  @ViewChild('chuyenHangDonHang') chuyenHangDonHang: ChuyenHangDonHangComponent;
  entities: Array<any>;

  DataTypeEnum = HSimpleGridSetting.DataTypeEnum;
  EditorTypeEnum = HSimpleGridSetting.EditorTypeEnum;
  FilterOperatorTypeEnum = HSimpleGridSetting.FilterOperatorTypeEnum;

  constructor(private dataService: DataService, private refDataService: ReferenceDataService) {
    console.log('constructor: ');
  }

  ngOnInit() {
    console.log('chi-tiet-chuyen-hang-don-hang ngOnInit');
  }

  onAddingItem(newItem) {
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
        this.refDataService.get('tmathang').subscribe(matHangs => {
          this.refDataService.get('rnhanvien').subscribe(nhanViens => {
            const qe = Converter.FromHSimpleGridSettingToQueryExpression(this.grid.settings);
            this.dataService.get('tChiTietChuyenHangDonHang', qe).subscribe(ctchdh => {
              this.dataService.getIntList('tChiTietDonHang', 'id', ctchdh.items.map(p => p.maChiTietDonHang)).subscribe(ctdh => {
                this.dataService.getIntList('tChuyenHangDonHang', 'id', ctchdh.items.map(p => p.maChuyenHangDonHang)).subscribe(chdh => {
                  ctchdh.items.forEach(p => {
                    p.chiTietDonHang = ctdh.items.find(p1 => p1.id === p.maChiTietDonHang);
                    p.chuyenHangDonHang = chdh.items.find(p1 => p1.id === p.maChuyenHangDonHang);
                    this.dataService.getByID('tDonHang', p.chiTietDonHang.maDonHang).subscribe(donHang => {
                      this.dataService.getByID('tChuyenHang', p.chuyenHangDonHang.maChuyenHang).subscribe(chuyenHang => {

                        p.chuyenHangDonHang.chuyenHang = chuyenHang;
                        p.chuyenHangDonHang.displayText = this.getChuyenHangDonHangDisplayText(p.chuyenHangDonHang, nhanViens);

                        p.chiTietDonHang.donHang = donHang;
                        p.chiTietDonHang.displayText = this.getChiTietDonHangDisplayText(p.chiTietDonHang, khoHangs, khachHangs, matHangs);

                        this.entities = ctchdh.items;
                        this.grid.settings.pagingSetting.pageCount = ctchdh.pageCount;
                        this.grid.settings.pagingSetting.rowCount = ctchdh.items.length;
                      });
                    });
                  });
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
    this.refDataService.get('rkhohang').subscribe(khoHangs => {
      this.refDataService.get('rkhachhang').subscribe(khachHangs => {
        this.refDataService.get('tmathang').subscribe(matHangs => {
          item[property] = this.chiTietDonHang.grid.selectedItem.id;
          this.dataService.getByID('tDonHang', this.chiTietDonHang.grid.selectedItem.maDonHang).subscribe(donHang => {
            item.chiTietDonHang = this.chiTietDonHang.grid.selectedItem;
            item.chiTietDonHang.donHang = donHang;
            item.chiTietDonHang.displayText = this.getChiTietDonHangDisplayText(item.chiTietDonHang, khoHangs, khachHangs, matHangs);
            window.hide();
          });
        });
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
    this.refDataService.get('rnhanvien').subscribe(nhanViens => {
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
}
