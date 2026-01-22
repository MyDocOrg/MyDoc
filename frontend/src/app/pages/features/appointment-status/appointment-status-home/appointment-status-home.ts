import { Component, inject, signal } from '@angular/core';
import { AppointmentStatusService } from '../services/appointment-status-service';
import { GenericTable } from '../../../../shared/components/generic-table/generic-table';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-appointment-status-home',
  imports: [GenericTable, RouterLink],
  templateUrl: './appointment-status-home.html',
  styleUrl: './appointment-status-home.scss',
})
export class AppointmentStatusHome {
  service = inject(AppointmentStatusService);
  appointmentStatusList = signal<any[]>([]);
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
        this.appointmentStatusList.set(res.data || res);
      },
      error: (error) => {
        this.loading = false;
        console.error('Error al obtener estados de cita:', error);
      },
    });
  }

  editAppointmentStatus(event: any): void {
    this.router.navigate(['/appointment-status/edit', event]);
  }

  deleteAppointmentStatus(event: any): void {
    this.service.Delete(event).subscribe({
      next: () => {
        this.GetAll();
      },
      error: (error) => {
        console.error('Error al eliminar estado de cita:', error);
      },
    });
  }

  viewAppointmentStatus(event: any): void {
    // TODO: Implementar vista de detalles
  }
}