import { BrowserModule, Title } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { routing } from './app.route';
import { AuthService } from './auth.service';
import { DataService } from './data.service';
import { CheckLogin } from './checkLogin';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { TonKhoComponent } from './ton-kho/ton-kho.component';
import { ChiPhiComponent } from './chi-phi/chi-phi.component';

import { HTopMenuModule, HSimpleGridModule, HComboBoxModule, HNumberModule } from './shared';
import { DonHangComplexComponent } from './don-hang-complex/don-hang-complex.component';
import { DonHangComponent } from './don-hang/don-hang.component';
import { ChiTietDonHangComponent } from './chi-tiet-don-hang/chi-tiet-don-hang.component';
import { ChuyenHangComponent } from './chuyen-hang/chuyen-hang.component';
import { ChuyenHangDonHangComponent } from './chuyen-hang-don-hang/chuyen-hang-don-hang.component';
import { ChiTietChuyenHangDonHangComponent } from './chi-tiet-chuyen-hang-don-hang/chi-tiet-chuyen-hang-don-hang.component';
import { ChuyenHangComplexComponent } from './chuyen-hang-complex/chuyen-hang-complex.component';
// import { HSemanticDropDownModule, , HWindowModule, HDraggableModule } from './shared';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    TonKhoComponent,
    ChiPhiComponent,
    DonHangComplexComponent,
    DonHangComponent,
    ChiTietDonHangComponent,
    ChuyenHangComponent,
    ChuyenHangDonHangComponent,
    ChiTietChuyenHangDonHangComponent,
    ChuyenHangComplexComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    HTopMenuModule,
    HSimpleGridModule,
    HComboBoxModule,
    HNumberModule,
    routing
  ],
  providers: [Title, AuthService, CheckLogin, DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
