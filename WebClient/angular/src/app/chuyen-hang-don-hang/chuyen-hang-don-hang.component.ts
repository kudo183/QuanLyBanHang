import { Component, OnInit, ViewChild } from '@angular/core';

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

  entities: Array<any>;

  DataTypeEnum = HSimpleGridSetting.DataTypeEnum;
  EditorTypeEnum = HSimpleGridSetting.EditorTypeEnum;
  FilterOperatorTypeEnum = HSimpleGridSetting.FilterOperatorTypeEnum;

  constructor(private dataService: DataService, private refDataService: ReferenceDataService) {
  }

  ngOnInit() {
    console.log('chuyen-hang-don-hang ngOnInit');
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
        this.refDataService.get('rnhanvien').subscribe(nhanViens => {
          const qe = Converter.FromHSimpleGridSettingToQueryExpression(this.grid.settings);
          this.dataService.get('tChuyenHangDonHang', qe).subscribe(chdh => {
            this.dataService.getIntList('tDonHang', 'id', chdh.items.map(p => p.maDonHang)).subscribe(dh => {
              this.dataService.getIntList('tChuyenHang', 'id', chdh.items.map(p => p.maChuyenHang)).subscribe(ch => {
                chdh.items.forEach(p => {
                  p.donHang = dh.items.find(p1 => p1.id === p.maDonHang);
                  const tenKhachHang = khachHangs.items.find(p2 => p2.id === p.donHang.maKhachHang).tenKhachHang;
                  const tenKho = khoHangs.items.find(p2 => p2.id === p.donHang.maKhoHang).tenKho;
                  p.donHang.displayText = p.maDonHang + '|' + tenKho + '|' + tenKhachHang;

                  p.chuyenHang = ch.items.find(p1 => p1.id === p.maChuyenHang);
                  const tenNhanVien = nhanViens.items.find(p2 => p2.id === p.chuyenHang.maNhanVienGiaoHang).tenNhanVien;
                  p.chuyenHang.displayText = p.maChuyenHang + '|' + tenNhanVien;
                });
                this.entities = chdh.items;
                this.grid.settings.pagingSetting.pageCount = chdh.pageCount;
                this.grid.settings.pagingSetting.rowCount = chdh.items.length;
              });
            });
          });
        });
      });
    });
  }

  showDonHang(item, property) {
    if (item.donHang !== undefined) {
      this.windowDonHang.title = item.donHang.displayText;
    }
    this.windowDonHang.evClose.subscribe(event => {
      this.refDataService.get('rkhohang').subscribe(khoHangs => {
        this.refDataService.get('rkhachhang').subscribe(khachHangs => {
          item[property] = this.donHang.grid.selectedItem.id;
          item.donHang = this.donHang.grid.selectedItem;
          const tenKhachHang = khachHangs.items.find(p2 => p2.id === item.donHang.maKhachHang).tenKhachHang;
          const tenKho = khoHangs.items.find(p2 => p2.id === item.donHang.maKhoHang).tenKho;
          item.donHang.displayText = item.maDonHang + '|' + tenKho + '|' + tenKhachHang;
        });
      });
    });
    this.windowDonHang.show();
  }

  showChuyenHang(item, property) {
    if (item.chuyenHang !== undefined) {
      this.windowChuyenHang.title = item.chuyenHang.displayText;
    }
    this.windowChuyenHang.evClose.subscribe(event => {
      this.refDataService.get('rnhanvien').subscribe(nhanViens => {
        item[property] = this.chuyenHang.grid.selectedItem.id;
        item.chuyenHang = this.chuyenHang.grid.selectedItem;
        const tenNhanVien = nhanViens.items.find(p2 => p2.id === item.chuyenHang.maNhanVienGiaoHang).tenNhanVien;
        item.chuyenHang.displayText = item.maChuyenHang + '|' + tenNhanVien;
      });
    });
    this.windowChuyenHang.show();
  }

  onFilterChanged(event) {
    console.log('onFilterChanged');
  }
}
