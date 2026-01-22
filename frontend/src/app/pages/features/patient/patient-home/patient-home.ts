import { Component, inject, signal } from '@angular/core';
import { PatientService } from '../services/patient-service';
import { GenericTable } from '../../../../shared/components/generic-table/generic-table';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-patient-home',
  imports: [GenericTable, RouterLink],
  templateUrl: './patient-home.html',
  styleUrl: './patient-home.scss',
})
export class PatientHome {
  service = inject(PatientService);
  patientList = signal<any[]>([]);
  loading = false;
  router = inject(Router);

  ngOnInit(): void {
    this.GetAll();
  }

  GetAll(): void {
    this.loading = true;
    this.service.GetAll().subscribe({
      next: (res) => {
        this.loading = false;
        this.patientList.set(res.data || res);
      },
      error: (error) => {
        this.loading = false;
        console.error('Error al obtener pacientes:', error);
      },
    });
  }

  editPatient(event: any): void {
    this.router.navigate(['/patient/edit', event]);
  }

  deletePatient(event: any): void {
    this.service.Delete(event).subscribe({
      next: () => {
        this.GetAll();
      },
      error: (error) => {
        console.error('Error al eliminar paciente:', error);
      },
    });
  }

  viewPatient(event: any): void {
    // TODO: Implementar vista de detalles
  }
}
