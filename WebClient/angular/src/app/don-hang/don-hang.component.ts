import { Component, OnInit, ViewChild, Input } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/observable/from';
import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { ReferenceDataService } from '../reference-data.service';
import { Converter } from '../converter';

import { HSimpleGridSetting, HSimpleGridComponent } from '../shared';

@Component({
  selector: 'app-don-hang',
  templateUrl: './don-hang.component.html',
  styleUrls: ['./don-hang.component.css']
})
export class DonHangComponent implements OnInit {
  @ViewChild(HSimpleGridComponent) grid: HSimpleGridComponent;
  @Input() name = 'viewDonHang';

  maKhachHangSource = [];
  maKhoHangSource = [];
  maChanhSource = [];

  maKhachHangChanhArr = [];

  entities: Array<any>;

  DataTypeEnum = HSimpleGridSetting.DataTypeEnum;
  EditorTypeEnum = HSimpleGridSetting.EditorTypeEnum;
  FilterOperatorTypeEnum = HSimpleGridSetting.FilterOperatorTypeEnum;
  OrderTypeEnum = HSimpleGridSetting.OrderTypeEnum;

  constructor(private dataService: DataService, private refDataService: ReferenceDataService) {
    console.log('constructor: ');
  }

  ngOnInit() {
    console.log('don-hang ngOnInit');
    this.grid.evAfterInit.subscribe(event => {
      this.refDataService.get('rkhachhangchanh').subscribe(khachHangChanhs => {
        this.refDataService.get('rkhachhang').subscribe(khachHangs => {
          this.refDataService.get('rkhohang').subscribe(khoHangs => {
            this.refDataService.get('rchanh').subscribe(chanhs => {
              this.maKhachHangChanhArr = khachHangChanhs.items;
              this.maKhachHangSource = khachHangs.items;
              this.grid.setHeaderItems(2, khachHangs.items);
              this.maKhoHangSource = khoHangs.items;
              this.grid.setHeaderItems(3, khoHangs.items);
              this.maChanhSource = chanhs.items;
              this.grid.setHeaderItems(4, chanhs.items);
              this.onLoad(undefined);
            });
          });
        });
      });
    });
  }

  print(): void {
    if (this.grid.selectedItem === undefined) {
      return;
    }

    let tenKhachHang = this.maKhachHangSource.find(p => p.id === this.grid.selectedItem.maKhachHang).tenKhachHang;

    const qe = new QueryExpression();
    qe.addWhereOption('=', 'maDonHang', this.grid.selectedItem.id, WhereOptionTypes.Int);
    this.dataService.get('tchitietdonhang', qe).subscribe(ctdhs => {
      this.dataService.getIntList('tchitietchuyenhangdonhang', 'maChiTietDonHang', ctdhs.items.map(p => p.id)).subscribe(ctchdhs => {
        this.refDataService.get('tmathang').subscribe(matHangs => {
          let printContents, popupWin, tenMatHangIn, tongSoLuong, soLuongConLai;
          printContents = '<div style="text-align:center;font-weight:bold;height:10mm">' + tenKhachHang + '</div>';

          ctdhs.items.forEach(p => {
            tongSoLuong = 0;
            ctchdhs.items.forEach(ctchdh => {
              if (ctchdh.maChiTietDonHang === p.id) {
                tongSoLuong = tongSoLuong + ctchdh.soLuong;
              }
            });
            soLuongConLai = p.soLuong - tongSoLuong;
            if (soLuongConLai > 0) {
              tenMatHangIn = matHangs.items.find(mh => mh.id === p.maMatHang).tenMatHangIn;
              printContents = printContents + '<div>' + this.formatNumber(soLuongConLai) + tenMatHangIn + '</div>';
            }
          });

          popupWin = window.open('', '_blank', 'top=0,left=0,height=100%,width=auto');
          popupWin.document.open();
          popupWin.document.write(`<html><body style="width:58mm;min-height:50mm;font-family:'Courier New';white-space:pre-wrap" onload="window.print();window.close()">${printContents}</body></html>`);
          popupWin.document.close();
        });
      });
    });
  }

  printAll(): void {
    if (this.grid.selectedItem === undefined) {
      return;
    }

    let tenKhachHang = this.maKhachHangSource.find(p => p.id === this.grid.selectedItem.maKhachHang).tenKhachHang;

    const qe = new QueryExpression();
    qe.addWhereOption('=', 'maDonHang', this.grid.selectedItem.id, WhereOptionTypes.Int);
    this.dataService.get('tchitietdonhang', qe).subscribe(ctdhs => {
      this.refDataService.get('tmathang').subscribe(matHangs => {
        let printContents, popupWin, tenMatHangIn;
        printContents = '<div style="text-align:center;font-weight:bold;height:10mm">' + tenKhachHang + '</div>';
        ctdhs.items.forEach(p => {
          tenMatHangIn = matHangs.items.find(mh => mh.id === p.maMatHang).tenMatHangIn;
          printContents = printContents + '<div>' + this.formatNumber(p.soLuong) + tenMatHangIn + '</div>';
        });

        popupWin = window.open('', '_blank', 'top=0,left=0,height=100%,width=auto');
        popupWin.document.open();
        popupWin.document.write(`<html><body style="width:58mm;min-height:50mm;font-family:'Courier New';white-space:pre-wrap" onload="window.print();window.close()">${printContents}</body></html>`);
        popupWin.document.close();
      });
    });
  }

  onAddingItem(newItem) {
    newItem.maKhachHangSource = this.maKhachHangSource;
    newItem.maKhoHangSource = this.maKhoHangSource;
    newItem.maChanhSource = this.getChanhByMaKhachHang(newItem.maKhachHang);
  }

  onSave(changeSet) {
    this.dataService.save('tDonHang', changeSet[0], changeSet[1], changeSet[2]).subscribe(p => {
      this.onLoad(undefined);
    });
  }

  onLoad(event) {
    const qe = Converter.FromHSimpleGridSettingToQueryExpression(this.grid.settings);
    this.dataService.get('tDonHang', qe).subscribe(data => {
      data.items.forEach(p => {
        p['ngay'] = p['ngay'].substring(0, 10);
        p.maKhachHangSource = this.maKhachHangSource;
        p.maKhoHangSource = this.maKhoHangSource;
        p.maChanhSource = this.getChanhByMaKhachHang(p.maKhachHang);
      });

      this.entities = data.items;
      this.grid.settings.pagingSetting.pageCount = data.pageCount;
      this.grid.settings.pagingSetting.rowCount = data.items.length;
    });
  }

  getChanhByMaKhachHang(maKhachHang) {
    const maKhachHangChanhFilteredArr = this.maKhachHangChanhArr.filter(p => p.maKhachHang === maKhachHang);
    return this.maChanhSource.filter(p => {
      return maKhachHangChanhFilteredArr.findIndex(item => item.maChanh === p.id) !== -1;
    });
  }

  formatNumber(number: number) {
    if (number < 10) {
      return number + '   ';
    }
    if (number < 100) {
      return number + '  ';
    }
    if (number < 1000) {
      return number + ' ';
    }
    return number + '';
  }
}
