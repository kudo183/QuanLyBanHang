import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { tNhapHangComponent, tChiTietNhapHangComponent } from '../gen';

@Component({
  selector: 'app-nhap-hang-complex',
  templateUrl: './nhap-hang-complex.component.html',
  styleUrls: ['./nhap-hang-complex.component.css']
})
export class NhapHangComplexComponent implements AfterViewInit {

  @ViewChild('nhapHangComp') nhapHangComp: tNhapHangComponent;
  @ViewChild('chiTietNhapHangComp') chiTietNhapHangComp: tChiTietNhapHangComponent;

  constructor() { }

  ngAfterViewInit() {
    this.nhapHangComp.grid.evSelectedItemChanged.subscribe(event => {
      this.chiTietNhapHangComp.grid.settings.columnSettings[1].headerSetting.isEnableFilter = true;
      this.chiTietNhapHangComp.grid.settings.columnSettings[1].headerSetting.filterValue = event.id;
      this.chiTietNhapHangComp.onLoad(undefined);
    });
  }
}
