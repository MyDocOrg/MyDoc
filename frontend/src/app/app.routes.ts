import { Routes } from '@angular/router';
import { LoginComponent } from './pages/features/auth/login/login.component';
import { RegisterComponent } from './pages/features/auth/register/register.component';
import { HomeComponent } from './pages/features/home/home';

export const routes: Routes = [
    { path: '', redirectTo: '/login', pathMatch: 'full' },
    { path: 'login', component: LoginComponent },
    { path: 'home', component: HomeComponent },
    { path: 'register', component: RegisterComponent},
    { path: '**', redirectTo: '/login' }
];
