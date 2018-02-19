import { Component, AfterViewInit, ViewChild } from '@angular/core';
import { ChuyenHangComponent } from '../chuyen-hang/chuyen-hang.component';
import { ChuyenHangDonHangComponent } from '../chuyen-hang-don-hang/chuyen-hang-don-hang.component';
import { ChiTietChuyenHangDonHangComponent } from '../chi-tiet-chuyen-hang-don-hang/chi-tiet-chuyen-hang-don-hang.component';

@Component({
  selector: 'app-chuyen-hang-complex',
  templateUrl: './chuyen-hang-complex.component.html',
  styleUrls: ['./chuyen-hang-complex.component.css']
})
export class ChuyenHangComplexComponent implements AfterViewInit {

  @ViewChild('chuyenHangComp') chuyenHangComp: ChuyenHangComponent;
  @ViewChild('chuyenHangDonHangComp') chuyenHangDonHangComp: ChuyenHangDonHangComponent;
  @ViewChild('chiTietChuyenHangDonHangComp') chiTietChuyenHangDonHangComp: ChiTietChuyenHangDonHangComponent;

  constructor() { }

  ngAfterViewInit() {
    this.chuyenHangComp.grid.evSelectedItemChanged.subscribe(event => {
      this.chuyenHangDonHangComp.grid.settings.columnSettings[1].headerSetting.isEnableFilter = true;
      this.chuyenHangDonHangComp.grid.settings.columnSettings[1].headerSetting.filterValue = event.id;
      this.chuyenHangDonHangComp.onLoad(undefined);
    });

    this.chuyenHangDonHangComp.grid.evSelectedItemChanged.subscribe(event => {
      this.chiTietChuyenHangDonHangComp.grid.settings.columnSettings[1].headerSetting.isEnableFilter = true;
      this.chiTietChuyenHangDonHangComp.grid.settings.columnSettings[1].headerSetting.filterValue = event.id;
      this.chiTietChuyenHangDonHangComp.onLoad(undefined);
    });
  }
}
