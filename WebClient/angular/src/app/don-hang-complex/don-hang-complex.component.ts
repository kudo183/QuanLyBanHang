import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { DonHangComponent } from '../don-hang/don-hang.component';
import { ChiTietDonHangComponent } from '../chi-tiet-don-hang/chi-tiet-don-hang.component';

@Component({
  selector: 'app-don-hang-complex',
  templateUrl: './don-hang-complex.component.html',
  styleUrls: ['./don-hang-complex.component.css']
})
export class DonHangComplexComponent implements AfterViewInit {

  @ViewChild('donHangComp') donHangComp: DonHangComponent;
  @ViewChild('chiTietDonHangComp') chiTietDonHangComp: ChiTietDonHangComponent;

  constructor() { }

  ngAfterViewInit() {
    this.donHangComp.grid.evSelectedItemChanged.subscribe(event => {
      this.chiTietDonHangComp.grid.settings.columnSettings[1].headerSetting.isEnableFilter = true;
      this.chiTietDonHangComp.grid.settings.columnSettings[1].headerSetting.filterValue = event.id;
      this.chiTietDonHangComp.onLoad(undefined);
    });
  }
}
