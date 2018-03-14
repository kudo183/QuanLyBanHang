import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { tChuyenKhoComponent, tChiTietChuyenKhoComponent } from '../gen';

@Component({
  selector: 'app-chuyen-kho-complex',
  templateUrl: './chuyen-kho-complex.component.html',
  styleUrls: ['./chuyen-kho-complex.component.css']
})
export class ChuyenKhoComplexComponent implements AfterViewInit {

  @ViewChild('chuyenKhoComp') chuyenKhoComp: tChuyenKhoComponent;
  @ViewChild('chiTietChuyenKhoComp') chiTietChuyenKhoComp: tChiTietChuyenKhoComponent;

  constructor() { }

  ngAfterViewInit() {
    this.chuyenKhoComp.grid.evSelectedItemChanged.subscribe(event => {
      this.chiTietChuyenKhoComp.grid.settings.columnSettings[1].headerSetting.isEnableFilter = true;
      this.chiTietChuyenKhoComp.grid.settings.columnSettings[1].headerSetting.filterValue = event.id;
      this.chiTietChuyenKhoComp.onLoad(undefined);
    });
  }
}
