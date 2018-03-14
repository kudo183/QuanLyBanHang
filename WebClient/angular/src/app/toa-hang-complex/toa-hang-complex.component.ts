import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { tToaHangComponent, tChiTietToaHangComponent } from '../gen';

@Component({
  selector: 'app-toa-hang-complex',
  templateUrl: './toa-hang-complex.component.html',
  styleUrls: ['./toa-hang-complex.component.css']
})
export class ToaHangComplexComponent implements AfterViewInit {

  @ViewChild('toaHangComp') toaHangComp: tToaHangComponent;
  @ViewChild('chiTietToaHangComp') chiTietToaHangComp: tChiTietToaHangComponent;

  constructor() { }

  ngAfterViewInit() {
    this.toaHangComp.grid.evSelectedItemChanged.subscribe(event => {
      this.chiTietToaHangComp.grid.settings.columnSettings[1].headerSetting.isEnableFilter = true;
      this.chiTietToaHangComp.grid.settings.columnSettings[1].headerSetting.filterValue = event.id;
      this.chiTietToaHangComp.onLoad(undefined);
    });
  }
}
