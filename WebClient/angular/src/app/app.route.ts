import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { TonKhoComponent } from './ton-kho/ton-kho.component';
import { ChiPhiComponent } from './chi-phi/chi-phi.component';
import { CheckLogin } from './checkLogin';

const appRoutes: Routes = [
    { path: '', component: TonKhoComponent, canActivate: [CheckLogin] },
    { path: 'chiphi', component: ChiPhiComponent, canActivate: [CheckLogin] },
    { path: 'login', component: LoginComponent },
    { path: 'logout', redirectTo: 'login' },
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
