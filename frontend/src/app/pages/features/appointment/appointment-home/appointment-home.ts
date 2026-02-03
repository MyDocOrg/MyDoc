import { Component, inject, signal } from '@angular/core';
import { AppointmentService } from '../services/appointment-service';
import { GenericTable } from '../../../../shared/components/generic-table/generic-table';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-appointment-home',
  imports: [GenericTable, RouterLink],
  templateUrl: './appointment-home.html',
  styleUrl: './appointment-home.scss',
})
export class AppointmentHome {
  service = inject(AppointmentService);
  appointmentList = signal<any[]>([]);
  loading = false;
  router = inject(Router);

  ngOnInit(): void {
    this.GetAll();
  }

  GetAll(): void {
    this.loading = true;
    this.service.GetTable().subscribe({
      next: (res) => {
        this.loading = false;
        this.appointmentList.set(res.data || res);
      },
      error: (error) => {
        this.loading = false;
        console.error('Error al obtener citas:', error);
      },
    });
  }

  editAppointment(event: any): void {
    this.router.navigate(['/appointment/edit', event]);
  }

  deleteAppointment(event: any): void {
    this.service.Delete(event).subscribe({
      next: () => {
        this.GetAll();
      },
      error: (error) => {
        console.error('Error al eliminar cita:', error);
      },
    });
  }

  viewAppointment(event: any): void {
    // TODO: Implementar vista de detalles
  }
}
