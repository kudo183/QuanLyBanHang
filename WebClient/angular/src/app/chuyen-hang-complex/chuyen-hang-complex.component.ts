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
    // this.chiTietChuyenHangDonHangComp.evAfterLoad.subscribe(p => {
    //   const comp = this.chiTietChuyenHangDonHangComp;
    //   if (comp.entities.length === 0) {
    //     const maChuyenHangDonHang = comp.grid.settings.columnSettings[1].headerSetting.filterValue;
    //     this.dataService.getByID('tChuyenHangDonHang', maChuyenHangDonHang).subscribe(chdh => {
    //       const qe = new QueryExpression();
    //       qe.addWhereOption('=', 'maDonHang', chdh.maDonHang, WhereOptionTypes.Int);
    //       qe.addWhereOption('=', 'xong', false, WhereOptionTypes.Bool);
    //       this.dataService.get('tChiTietDonHang', qe).subscribe(ctdhs => {
    //         if (ctdhs.items.length > 0) {
    //           this.actionRequireKhoHangKhachHangMatHangNhanVien((khoHangs, khachHangs, matHangs, nhanViens) => {
    //             this.dataService.getByID('tDonHang', chdh.maDonHang).subscribe(dh => {
    //               this.dataService.getByID('tChuyenHang', chdh.maChuyenHang).subscribe(ch => {
    //                 this.dataService.getIntList('tChiTietChuyenHangDonHang', 'maChiTietDonHang', ctdhs.items.map(p => p.id)).subscribe(ctchdhs => {
    //                   ctdhs.items.forEach(ctdh => {
    //                     const newItem: any = {};
    //                     newItem.maChuyenHangDonHang = maChuyenHangDonHang;
    //                     newItem.chuyenHangDonHang = chdh;
    //                     newItem.chuyenHangDonHang.chuyenHang = ch;
    //                     newItem.chuyenHangDonHang.displayText = comp.getChuyenHangDonHangDisplayText(newItem.chuyenHangDonHang, nhanViens);

    //                     newItem.maChiTietDonHang = ctdh.id;
    //                     newItem.chiTietDonHang = ctdh;
    //                     newItem.chiTietDonHang.donHang = dh;
    //                     newItem.chiTietDonHang.displayText = comp.getChiTietDonHangDisplayText(newItem.chiTietDonHang, khoHangs, khachHangs, matHangs);

    //                     let soLuongDaGiao = 0;
    //                     ctchdhs.items.forEach(ctchdh => {
    //                       if (ctchdh.maChiTietDonHang === newItem.maChiTietDonHang) {
    //                         soLuongDaGiao = soLuongDaGiao + ctchdh.soLuong;
    //                       }
    //                     });
    //                     newItem.soLuong = ctdh.soLuong - soLuongDaGiao;

    //                     comp.grid.items.push(newItem);
    //                   });
    //                   comp.grid.updateGrid();
    //                 });
    //               });
    //             });
    //           });
    //         }
    //       });
    //     });
    //   }
    // });

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

  actionRequireKhoHangKhachHangMatHangNhanVien(action) {
    this.refDataService.gets(['rKhoHang', 'rKhachHang', 'tMatHang', 'rNhanVien']).subscribe(data => {
      action(data[0], data[1], data[2], data[3]);
    });
  }
}
