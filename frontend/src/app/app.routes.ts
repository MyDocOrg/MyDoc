import { Routes } from '@angular/router';
import { Login } from './pages/feactures/login/login';
import { Register } from './pages/feactures/register/register';
import { Home } from './pages/feactures/home/home';

export const routes: Routes = [
    { path: '', component: Home },
    { path: 'login', component: Login },
    { path: 'register', component: Register},
    { path: '**', redirectTo: '' }
];
