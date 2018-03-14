import { BrowserModule, Title } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { routing } from './app.route';
import { AuthService } from './auth.service';
import { DataService } from './data.service';
import { ReferenceDataService } from './reference-data.service';
import { CheckLogin } from './checkLogin';
import { PartialMethodService } from './partial-method.service';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { TonKhoComponent } from './ton-kho/ton-kho.component';

import { HTopMenuModule, HSimpleGridModule, HComboBoxModule, HNumberModule, HWindowModule, HSplitPanelModule, HDraggableModule } from './shared';
import { DonHangComplexComponent } from './don-hang-complex/don-hang-complex.component';
import { ChuyenHangComplexComponent } from './chuyen-hang-complex/chuyen-hang-complex.component';

import { GenModule } from './gen';
import { TestGenComponent } from './gen/test-gen.component';
import { NhapHangComplexComponent } from './nhap-hang-complex/nhap-hang-complex.component';
import { ChuyenKhoComplexComponent } from './chuyen-kho-complex/chuyen-kho-complex.component';
import { ToaHangComplexComponent } from './toa-hang-complex/toa-hang-complex.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    TonKhoComponent,
    DonHangComplexComponent,
    ChuyenHangComplexComponent,
    TestGenComponent,
    NhapHangComplexComponent,
    ChuyenKhoComplexComponent,
    ToaHangComplexComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    HTopMenuModule,
    HSimpleGridModule,
    HComboBoxModule,
    HNumberModule,
    HWindowModule,
    HSplitPanelModule,
    HDraggableModule,
    GenModule,
    routing
  ],
  providers: [Title, AuthService, CheckLogin, DataService, ReferenceDataService, PartialMethodService],
  bootstrap: [AppComponent]
})
export class AppModule { }
