import { BrowserModule } from '@angular/platform-browser';
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
// import { HSemanticDropDownModule, , HWindowModule, HDraggableModule } from './shared';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    TonKhoComponent,
    ChiPhiComponent
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
  providers: [AuthService, CheckLogin, DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
