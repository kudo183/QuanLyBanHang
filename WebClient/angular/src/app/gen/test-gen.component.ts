import { Component } from '@angular/core';

@Component({
  selector: 'app-test-gen',
  styles: [`
    .item {
        cursor: pointer;
    }

    .active {
        background: blue;
    }
  `],
  template: `
    <h-split-panel [isVertical]="false">
      <div *hSplitPanel="20">
          <div class="item" *ngFor="let item of items" [ngClass]="{active:selectedItem===item}" (click)="selectedItem=item;">{{item}}</div>
      </div>
      <div *hSplitPanel="80">
          <ng-container [ngSwitch]="selectedItem">
              <app-rBaiXe *ngSwitchCase="'rBaiXe'"></app-rBaiXe>
              <app-rCanhBaoTonKho *ngSwitchCase="'rCanhBaoTonKho'"></app-rCanhBaoTonKho>
              <app-rChanh *ngSwitchCase="'rChanh'"></app-rChanh>
              <app-rDiaDiem *ngSwitchCase="'rDiaDiem'"></app-rDiaDiem>
              <app-rKhachHang *ngSwitchCase="'rKhachHang'"></app-rKhachHang>
              <app-rKhachHangChanh *ngSwitchCase="'rKhachHangChanh'"></app-rKhachHangChanh>
              <app-rKhoHang *ngSwitchCase="'rKhoHang'"></app-rKhoHang>
              <app-rLoaiChiPhi *ngSwitchCase="'rLoaiChiPhi'"></app-rLoaiChiPhi>
              <app-rLoaiHang *ngSwitchCase="'rLoaiHang'"></app-rLoaiHang>
              <app-rLoaiNguyenLieu *ngSwitchCase="'rLoaiNguyenLieu'"></app-rLoaiNguyenLieu>
              <app-rMatHangNguyenLieu *ngSwitchCase="'rMatHangNguyenLieu'"></app-rMatHangNguyenLieu>
              <app-rNuoc *ngSwitchCase="'rNuoc'"></app-rNuoc>
              <app-rNguyenLieu *ngSwitchCase="'rNguyenLieu'"></app-rNguyenLieu>
              <app-rNhaCungCap *ngSwitchCase="'rNhaCungCap'"></app-rNhaCungCap>
              <app-rNhanVien *ngSwitchCase="'rNhanVien'"></app-rNhanVien>
              <app-rPhuongTien *ngSwitchCase="'rPhuongTien'"></app-rPhuongTien>
              <app-tCongNoKhachHang *ngSwitchCase="'tCongNoKhachHang'"></app-tCongNoKhachHang>
              <app-tChiPhi *ngSwitchCase="'tChiPhi'"></app-tChiPhi>
              <app-tChiTietChuyenHangDonHang *ngSwitchCase="'tChiTietChuyenHangDonHang'"></app-tChiTietChuyenHangDonHang>
              <app-tChiTietChuyenKho *ngSwitchCase="'tChiTietChuyenKho'"></app-tChiTietChuyenKho>
              <app-tChiTietDonHang *ngSwitchCase="'tChiTietDonHang'"></app-tChiTietDonHang>
              <app-tChiTietNhapHang *ngSwitchCase="'tChiTietNhapHang'"></app-tChiTietNhapHang>
              <app-tChiTietToaHang *ngSwitchCase="'tChiTietToaHang'"></app-tChiTietToaHang>
              <app-tChuyenHang *ngSwitchCase="'tChuyenHang'"></app-tChuyenHang>
              <app-tChuyenHangDonHang *ngSwitchCase="'tChuyenHangDonHang'"></app-tChuyenHangDonHang>
              <app-tChuyenKho *ngSwitchCase="'tChuyenKho'"></app-tChuyenKho>
              <app-tDonHang *ngSwitchCase="'tDonHang'"></app-tDonHang>
              <app-tGiamTruKhachHang *ngSwitchCase="'tGiamTruKhachHang'"></app-tGiamTruKhachHang>
              <app-tMatHang *ngSwitchCase="'tMatHang'"></app-tMatHang>
              <app-tNhanTienKhachHang *ngSwitchCase="'tNhanTienKhachHang'"></app-tNhanTienKhachHang>
              <app-tNhapHang *ngSwitchCase="'tNhapHang'"></app-tNhapHang>
              <app-tNhapNguyenLieu *ngSwitchCase="'tNhapNguyenLieu'"></app-tNhapNguyenLieu>
              <app-tPhuThuKhachHang *ngSwitchCase="'tPhuThuKhachHang'"></app-tPhuThuKhachHang>
              <app-tToaHang *ngSwitchCase="'tToaHang'"></app-tToaHang>
              <app-tTonKho *ngSwitchCase="'tTonKho'"></app-tTonKho>
              <app-ThamSoNgay *ngSwitchCase="'ThamSoNgay'"></app-ThamSoNgay>
          </ng-container>
      </div>
    </h-split-panel>
    `
})

export class TestGenComponent {
  items = ['rBaiXe', 'rCanhBaoTonKho', 'rChanh', 'rDiaDiem', 'rKhachHang', 'rKhachHangChanh', 'rKhoHang', 'rLoaiChiPhi', 'rLoaiHang', 'rLoaiNguyenLieu', 'rMatHangNguyenLieu', 'rNuoc', 'rNguyenLieu', 'rNhaCungCap', 'rNhanVien', 'rPhuongTien', 'tCongNoKhachHang', 'tChiPhi', 'tChiTietChuyenHangDonHang', 'tChiTietChuyenKho', 'tChiTietDonHang', 'tChiTietNhapHang', 'tChiTietToaHang', 'tChuyenHang', 'tChuyenHangDonHang', 'tChuyenKho', 'tDonHang', 'tGiamTruKhachHang', 'tMatHang', 'tNhanTienKhachHang', 'tNhapHang', 'tNhapNguyenLieu', 'tPhuThuKhachHang', 'tToaHang', 'tTonKho', 'ThamSoNgay'];
  selectedItems;
}
