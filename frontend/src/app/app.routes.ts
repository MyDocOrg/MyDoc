import { Routes } from '@angular/router';
import { LoginComponent } from './pages/features/auth/login/login.component';
import { RegisterComponent } from './pages/features/auth/register/register.component';
import { HomeComponent } from './pages/features/home/home';
import { DashboardComponent } from './pages/features/doctor/dashboard/dashboard.component';
import { PatientsComponent } from './pages/features/doctor/patients/patients.component';
import { PrescriptionsComponent } from './pages/features/doctor/prescriptions/prescriptions.component';
import { ScheduleComponent } from './pages/features/doctor/schedule/schedule.component';
import { SettingsComponent } from './pages/features/doctor/settings/settings.component';

export const routes: Routes = [
    { path: '', redirectTo: '/login', pathMatch: 'full' },
    { path: 'login', component: LoginComponent },
    { path: 'home', component: HomeComponent },
    { path: 'register', component: RegisterComponent},
    
    // Rutas del módulo Doctor
    { 
        path: 'doctor', 
        children: [
            { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
            { path: 'dashboard', component: DashboardComponent },
            { path: 'patients', component: PatientsComponent },
            { path: 'prescriptions', component: PrescriptionsComponent },
            { path: 'schedule', component: ScheduleComponent },
            { path: 'settings', component: SettingsComponent }
        ]
    },
    
    { path: '**', redirectTo: '/login' }
];
