import { Routes } from '@angular/router';
import { LoginComponent } from './pages/features/auth/login/login.component';
import { RegisterComponent } from './pages/features/auth/register/register.component';
import { HomeComponent } from './pages/features/home/home';
import { DashboardComponent } from './pages/features/doctor/dashboard/dashboard.component';
import { PatientsComponent } from './pages/features/doctor/patients/patients.component';
import { PrescriptionsComponent } from './pages/features/doctor/prescriptions/prescriptions.component';
import { ScheduleComponent } from './pages/features/doctor/schedule/schedule.component';
import { SettingsComponent } from './pages/features/doctor/settings/settings.component';

// Patient
import { PatientHome } from './pages/features/patient/patient-home/patient-home';
import { PatientAdd } from './pages/features/patient/patient-add/patient-add';
import { PatientEdit } from './pages/features/patient/patient-edit/patient-edit';

// Doctor
import { DoctorHome } from './pages/features/doctor/doctor-home/doctor-home';
import { DoctorAdd } from './pages/features/doctor/doctor-add/doctor-add';
import { DoctorEdit } from './pages/features/doctor/doctor-edit/doctor-edit';

// Clinic
import { ClinicHome } from './pages/features/clinic/clinic-home/clinic-home';
import { ClinicAdd } from './pages/features/clinic/clinic-add/clinic-add';

// Appointment
import { AppointmentHome } from './pages/features/appointment/appointment-home/appointment-home';
import { AppointmentAdd } from './pages/features/appointment/appointment-add/appointment-add';

// Consultation
import { ConsultationHome } from './pages/features/consultation/consultation-home/consultation-home';
import { ConsultationAdd } from './pages/features/consultation/consultation-add/consultation-add';
import { ConsultationEdit } from './pages/features/consultation/consultation-edit/consultation-edit';

// Medicine
import { MedicineHome } from './pages/features/medicine/medicine-home/medicine-home';
import { MedicineAdd } from './pages/features/medicine/medicine-add/medicine-add';
import { MedicineEdit } from './pages/features/medicine/medicine-edit/medicine-edit';

// Prescription
import { PrescriptionHome } from './pages/features/prescription/prescription-home/prescription-home';
import { PrescriptionAdd } from './pages/features/prescription/prescription-add/prescription-add';
import { PrescriptionEdit } from './pages/features/prescription/prescription-edit/prescription-edit';

// Medication Schedule
import { MedicationScheduleHome } from './pages/features/medication-schedule/medication-schedule-home/medication-schedule-home';
import { MedicationScheduleAdd } from './pages/features/medication-schedule/medication-schedule-add/medication-schedule-add';
import { MedicationScheduleEdit } from './pages/features/medication-schedule/medication-schedule-edit/medication-schedule-edit';

// Appointment Status
import { AppointmentStatusHome } from './pages/features/appointment-status/appointment-status-home/appointment-status-home';
import { AppointmentStatusAdd } from './pages/features/appointment-status/appointment-status-add/appointment-status-add';
import { AppointmentStatusEdit } from './pages/features/appointment-status/appointment-status-edit/appointment-status-edit';
import { SelectRole } from './pages/features/auth/select-role/select-role';
import { ClinicEdit } from './pages/features/clinic/clinic-edit/clinic-edit';
import { AppointmentEdit } from './pages/features/appointment/appointment-edit/appointment-edit';

// Notification
import { NotificationHome } from './pages/features/notification/notification-home/notification-home';
import { NotificationAdd } from './pages/features/notification/notification-add/notification-add';
import { NotificationEdit } from './pages/features/notification/notification-edit/notification-edit';

// Medical History
import { MedicalHistoryHome } from './pages/features/medical-history/medical-history-home/medical-history-home';
import { MedicalHistoryAdd } from './pages/features/medical-history/medical-history-add/medical-history-add';
import { MedicalHistoryEdit } from './pages/features/medical-history/medical-history-edit/medical-history-edit';

export const routes: Routes = [
    { path: '', redirectTo: '/login', pathMatch: 'full' },
    { path: 'login', component: LoginComponent },
    { path: 'select-role', component: SelectRole },
    { path: 'home', component: HomeComponent },
    { path: 'register', component: RegisterComponent},
    
    // Patient
    {
        path: 'patient',
        children: [
            { path: '', component: PatientHome },
            { path: 'add', component: PatientAdd },
            { path: 'edit/:id', component: PatientAdd }
        ]
    },    
    // Doctor
    {
        path: 'doctor',
        children: [
            { path: '', component: DoctorHome },
            { path: 'add', component: DoctorAdd },
            { path: 'edit/:id', component: DoctorAdd },
            { path: 'dashboard', component: DashboardComponent },
            { path: 'patients', component: PatientsComponent },
            { path: 'prescriptions', component: PrescriptionsComponent },
            { path: 'schedule', component: ScheduleComponent },
            { path: 'settings', component: SettingsComponent }
        ]
    },    
    // Clinic
    {
        path: 'clinic',
        children: [
            { path: '', component: ClinicHome },
            { path: 'add', component: ClinicAdd },
            { path: 'edit/:id', component: ClinicEdit }
        ]
    },
    
    // Appointment
    {
        path: 'appointment',
        children: [
            { path: '', component: AppointmentHome },
            { path: 'add', component: AppointmentAdd },
            { path: 'edit/:id', component: AppointmentEdit }
        ]
    },
    
    // Consultation
    {
        path: 'consultation',
        children: [
            { path: '', component: ConsultationHome },
            { path: 'add', component: ConsultationAdd },
            { path: 'edit/:id', component: ConsultationAdd }
        ]
    },    
    // Medicine
    {
        path: 'medicine',
        children: [
            { path: '', component: MedicineHome },
            { path: 'add', component: MedicineAdd },
            { path: 'edit/:id', component: MedicineAdd }
        ]
    },    
    // Prescription
    {
        path: 'prescription',
        children: [
            { path: '', component: PrescriptionHome },
            { path: 'add', component: PrescriptionAdd },
            { path: 'edit/:id', component: PrescriptionAdd }
        ]
    },    
    // Medication Schedule
    {
        path: 'medication-schedule',
        children: [
            { path: '', component: MedicationScheduleHome },
            { path: 'add', component: MedicationScheduleAdd },
            { path: 'edit/:id', component: MedicationScheduleAdd }
        ]
    },    
    // Appointment Status
    {
        path: 'appointment-status',
        children: [
            { path: '', component: AppointmentStatusHome },
            { path: 'add', component: AppointmentStatusAdd },
            { path: 'edit/:id', component: AppointmentStatusAdd }
        ]
    },
    // Notification
    {
        path: 'notification',
        children: [
            { path: '', component: NotificationHome },
            { path: 'add', component: NotificationAdd },
            { path: 'edit/:id', component: NotificationEdit }
        ]
    },

    // Medical History
    {
        path: 'medical-history',
        children: [
            { path: '', component: MedicalHistoryHome },
            { path: 'add', component: MedicalHistoryAdd },
            { path: 'edit/:id', component: MedicalHistoryEdit }
        ]
    },
    
    { path: '**', redirectTo: '/login' }
];
