import { Component, AfterViewInit, ViewChild } from '@angular/core';
import { tChuyenHangComponent, tChuyenHangDonHangComponent, tChiTietChuyenHangDonHangComponent } from '../gen'
import { DataService, QueryExpression, WhereOption, WhereOptionTypes, OrderOption } from '../data.service';
import { ReferenceDataService } from '../reference-data.service';

@Component({
  selector: 'app-chuyen-hang-complex',
  templateUrl: './chuyen-hang-complex.component.html',
  styleUrls: ['./chuyen-hang-complex.component.css']
})
export class ChuyenHangComplexComponent implements AfterViewInit {

  @ViewChild('chuyenHangComp') chuyenHangComp: tChuyenHangComponent;
  @ViewChild('chuyenHangDonHangComp') chuyenHangDonHangComp: tChuyenHangDonHangComponent;
  @ViewChild('chiTietChuyenHangDonHangComp') chiTietChuyenHangDonHangComp: tChiTietChuyenHangDonHangComponent;

  constructor(private dataService: DataService, private refDataService: ReferenceDataService) { }

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
