import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { tDonHangComponent, tChiTietDonHangComponent } from '../gen';

@Component({
  selector: 'app-don-hang-complex',
  templateUrl: './don-hang-complex.component.html',
  styleUrls: ['./don-hang-complex.component.css']
})
export class DonHangComplexComponent implements AfterViewInit {

  @ViewChild('donHangComp') donHangComp: tDonHangComponent;
  @ViewChild('chiTietDonHangComp') chiTietDonHangComp: tChiTietDonHangComponent;

  constructor() { }

  ngAfterViewInit() {
    this.donHangComp.grid.evSelectedItemChanged.subscribe(event => {
      this.chiTietDonHangComp.grid.settings.columnSettings[1].headerSetting.isEnableFilter = true;
      this.chiTietDonHangComp.grid.settings.columnSettings[1].headerSetting.filterValue = event.id;
      this.chiTietDonHangComp.onLoad(undefined);
    });
  }
}
