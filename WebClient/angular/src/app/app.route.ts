import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { TonKhoComponent } from './ton-kho/ton-kho.component';
import { DonHangComplexComponent } from './don-hang-complex/don-hang-complex.component';
import { ChuyenHangComplexComponent } from './chuyen-hang-complex/chuyen-hang-complex.component';
import { tChiPhiComponent } from './gen';
import { CheckLogin } from './checkLogin';

import { TestGenComponent } from './gen/test-gen.component';

const appRoutes: Routes = [
    { path: '', component: TonKhoComponent, canActivate: [CheckLogin] },
    { path: 'chiphi', component: tChiPhiComponent, canActivate: [CheckLogin] },
    { path: 'all', component: TestGenComponent, canActivate: [CheckLogin] },
    { path: 'donhangcomplex', component: DonHangComplexComponent, canActivate: [CheckLogin] },
    { path: 'chuyenhangcomplex', component: ChuyenHangComplexComponent, canActivate: [CheckLogin] },
    { path: 'login', component: LoginComponent },
    { path: 'logout', redirectTo: 'login' },
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
