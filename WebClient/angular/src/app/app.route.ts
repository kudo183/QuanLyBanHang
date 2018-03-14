import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { TonKhoComponent } from './ton-kho/ton-kho.component';
import { DonHangComplexComponent } from './don-hang-complex/don-hang-complex.component';
import { ChuyenHangComplexComponent } from './chuyen-hang-complex/chuyen-hang-complex.component';
import { NhapHangComplexComponent } from './nhap-hang-complex/nhap-hang-complex.component';
import { ChuyenKhoComplexComponent } from './chuyen-kho-complex/chuyen-kho-complex.component';
import { ToaHangComplexComponent } from './toa-hang-complex/toa-hang-complex.component';
import { tChiPhiComponent } from './gen';
import { CheckLogin } from './checkLogin';

import { TestGenComponent } from './gen/test-gen.component';

const appRoutes: Routes = [
    { path: '', component: TonKhoComponent, canActivate: [CheckLogin] },
    { path: 'chiphi', component: tChiPhiComponent, canActivate: [CheckLogin] },
    { path: 'all', component: TestGenComponent, canActivate: [CheckLogin] },
    { path: 'donhang', component: DonHangComplexComponent, canActivate: [CheckLogin] },
    { path: 'chuyenhang', component: ChuyenHangComplexComponent, canActivate: [CheckLogin] },
    { path: 'nhaphang', component: NhapHangComplexComponent, canActivate: [CheckLogin] },
    { path: 'chuyenkho', component: ChuyenKhoComplexComponent, canActivate: [CheckLogin] },
    { path: 'toahang', component: ToaHangComplexComponent, canActivate: [CheckLogin] },
    { path: 'login', component: LoginComponent },
    { path: 'logout', redirectTo: 'login' },
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
