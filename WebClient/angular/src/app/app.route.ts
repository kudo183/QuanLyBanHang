import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { TonKhoComponent } from './ton-kho/ton-kho.component';
import { DonHangComponent } from './don-hang/don-hang.component';
import { ChiTietDonHangComponent } from './chi-tiet-don-hang/chi-tiet-don-hang.component';
import { DonHangComplexComponent } from './don-hang-complex/don-hang-complex.component';
import { ChuyenHangComplexComponent } from './chuyen-hang-complex/chuyen-hang-complex.component';
import { ChiPhiComponent } from './chi-phi/chi-phi.component';
import { CheckLogin } from './checkLogin';

const appRoutes: Routes = [
    { path: '', component: TonKhoComponent, canActivate: [CheckLogin] },
    { path: 'chiphi', component: ChiPhiComponent, canActivate: [CheckLogin] },
    { path: 'donhang', component: DonHangComponent, canActivate: [CheckLogin] },
    { path: 'chitietdonhang', component: ChiTietDonHangComponent, canActivate: [CheckLogin] },
    { path: 'donhangcomplex', component: DonHangComplexComponent, canActivate: [CheckLogin] },
    { path: 'chuyenhangcomplex', component: ChuyenHangComplexComponent, canActivate: [CheckLogin] },
    { path: 'login', component: LoginComponent },
    { path: 'logout', redirectTo: 'login' },
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
