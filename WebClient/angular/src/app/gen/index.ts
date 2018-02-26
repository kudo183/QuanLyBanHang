import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HTopMenuModule, HSimpleGridModule, HComboBoxModule, HNumberModule, HWindowModule, HSplitPanelModule, HDraggableModule } from '../shared';

import { rBaiXeComponent } from './rBaiXe.component';
import { rCanhBaoTonKhoComponent } from './rCanhBaoTonKho.component';
import { rChanhComponent } from './rChanh.component';
import { rDiaDiemComponent } from './rDiaDiem.component';
import { rKhachHangComponent } from './rKhachHang.component';
import { rKhachHangChanhComponent } from './rKhachHangChanh.component';
import { rKhoHangComponent } from './rKhoHang.component';
import { rLoaiChiPhiComponent } from './rLoaiChiPhi.component';
import { rLoaiHangComponent } from './rLoaiHang.component';
import { rLoaiNguyenLieuComponent } from './rLoaiNguyenLieu.component';
import { rMatHangNguyenLieuComponent } from './rMatHangNguyenLieu.component';
import { rNuocComponent } from './rNuoc.component';
import { rNguyenLieuComponent } from './rNguyenLieu.component';
import { rNhaCungCapComponent } from './rNhaCungCap.component';
import { rNhanVienComponent } from './rNhanVien.component';
import { rPhuongTienComponent } from './rPhuongTien.component';
import { tCongNoKhachHangComponent } from './tCongNoKhachHang.component';
import { tChiPhiComponent } from './tChiPhi.component';
import { tChiTietChuyenHangDonHangComponent } from './tChiTietChuyenHangDonHang.component';
import { tChiTietChuyenKhoComponent } from './tChiTietChuyenKho.component';
import { tChiTietDonHangComponent } from './tChiTietDonHang.component';
import { tChiTietNhapHangComponent } from './tChiTietNhapHang.component';
import { tChiTietToaHangComponent } from './tChiTietToaHang.component';
import { tChuyenHangComponent } from './tChuyenHang.component';
import { tChuyenHangDonHangComponent } from './tChuyenHangDonHang.component';
import { tChuyenKhoComponent } from './tChuyenKho.component';
import { tDonHangComponent } from './tDonHang.component';
import { tGiamTruKhachHangComponent } from './tGiamTruKhachHang.component';
import { tMatHangComponent } from './tMatHang.component';
import { tNhanTienKhachHangComponent } from './tNhanTienKhachHang.component';
import { tNhapHangComponent } from './tNhapHang.component';
import { tNhapNguyenLieuComponent } from './tNhapNguyenLieu.component';
import { tPhuThuKhachHangComponent } from './tPhuThuKhachHang.component';
import { tToaHangComponent } from './tToaHang.component';
import { tTonKhoComponent } from './tTonKho.component';
import { ThamSoNgayComponent } from './ThamSoNgay.component';

export * from './rBaiXe.component';
export * from './rCanhBaoTonKho.component';
export * from './rChanh.component';
export * from './rDiaDiem.component';
export * from './rKhachHang.component';
export * from './rKhachHangChanh.component';
export * from './rKhoHang.component';
export * from './rLoaiChiPhi.component';
export * from './rLoaiHang.component';
export * from './rLoaiNguyenLieu.component';
export * from './rMatHangNguyenLieu.component';
export * from './rNuoc.component';
export * from './rNguyenLieu.component';
export * from './rNhaCungCap.component';
export * from './rNhanVien.component';
export * from './rPhuongTien.component';
export * from './tCongNoKhachHang.component';
export * from './tChiPhi.component';
export * from './tChiTietChuyenHangDonHang.component';
export * from './tChiTietChuyenKho.component';
export * from './tChiTietDonHang.component';
export * from './tChiTietNhapHang.component';
export * from './tChiTietToaHang.component';
export * from './tChuyenHang.component';
export * from './tChuyenHangDonHang.component';
export * from './tChuyenKho.component';
export * from './tDonHang.component';
export * from './tGiamTruKhachHang.component';
export * from './tMatHang.component';
export * from './tNhanTienKhachHang.component';
export * from './tNhapHang.component';
export * from './tNhapNguyenLieu.component';
export * from './tPhuThuKhachHang.component';
export * from './tToaHang.component';
export * from './tTonKho.component';
export * from './ThamSoNgay.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HTopMenuModule,
    HSimpleGridModule,
    HComboBoxModule,
    HNumberModule,
    HWindowModule,
    HSplitPanelModule,
    HDraggableModule
  ],
  declarations: [
    rBaiXeComponent,
    rCanhBaoTonKhoComponent,
    rChanhComponent,
    rDiaDiemComponent,
    rKhachHangComponent,
    rKhachHangChanhComponent,
    rKhoHangComponent,
    rLoaiChiPhiComponent,
    rLoaiHangComponent,
    rLoaiNguyenLieuComponent,
    rMatHangNguyenLieuComponent,
    rNuocComponent,
    rNguyenLieuComponent,
    rNhaCungCapComponent,
    rNhanVienComponent,
    rPhuongTienComponent,
    tCongNoKhachHangComponent,
    tChiPhiComponent,
    tChiTietChuyenHangDonHangComponent,
    tChiTietChuyenKhoComponent,
    tChiTietDonHangComponent,
    tChiTietNhapHangComponent,
    tChiTietToaHangComponent,
    tChuyenHangComponent,
    tChuyenHangDonHangComponent,
    tChuyenKhoComponent,
    tDonHangComponent,
    tGiamTruKhachHangComponent,
    tMatHangComponent,
    tNhanTienKhachHangComponent,
    tNhapHangComponent,
    tNhapNguyenLieuComponent,
    tPhuThuKhachHangComponent,
    tToaHangComponent,
    tTonKhoComponent,
    ThamSoNgayComponent,
  ],
  exports: [
    rBaiXeComponent,
    rCanhBaoTonKhoComponent,
    rChanhComponent,
    rDiaDiemComponent,
    rKhachHangComponent,
    rKhachHangChanhComponent,
    rKhoHangComponent,
    rLoaiChiPhiComponent,
    rLoaiHangComponent,
    rLoaiNguyenLieuComponent,
    rMatHangNguyenLieuComponent,
    rNuocComponent,
    rNguyenLieuComponent,
    rNhaCungCapComponent,
    rNhanVienComponent,
    rPhuongTienComponent,
    tCongNoKhachHangComponent,
    tChiPhiComponent,
    tChiTietChuyenHangDonHangComponent,
    tChiTietChuyenKhoComponent,
    tChiTietDonHangComponent,
    tChiTietNhapHangComponent,
    tChiTietToaHangComponent,
    tChuyenHangComponent,
    tChuyenHangDonHangComponent,
    tChuyenKhoComponent,
    tDonHangComponent,
    tGiamTruKhachHangComponent,
    tMatHangComponent,
    tNhanTienKhachHangComponent,
    tNhapHangComponent,
    tNhapNguyenLieuComponent,
    tPhuThuKhachHangComponent,
    tToaHangComponent,
    tTonKhoComponent,
    ThamSoNgayComponent,
  ]
})
export class GenModule { }
