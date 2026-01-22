import { Component, inject, signal } from '@angular/core';
import { DoctorService } from '../services/doctor-service';
import { GenericTable } from '../../../../shared/components/generic-table/generic-table';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-doctor-home',
  imports: [GenericTable, RouterLink],
  templateUrl: './doctor-home.html',
  styleUrl: './doctor-home.scss',
})
export class DoctorHome {
  service = inject(DoctorService);
  doctorList = signal<any[]>([]);
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
        this.doctorList.set(res.data || res);
      },
      error: (error) => {
        this.loading = false;
        console.error('Error al obtener doctores:', error);
      },
    });
  }

  editDoctor(event: any): void {
    this.router.navigate(['/doctor/edit', event]);
  }

  deleteDoctor(event: any): void {
    this.service.Delete(event).subscribe({
      next: () => {
        this.GetAll();
      },
      error: (error) => {
        console.error('Error al eliminar doctor:', error);
      },
    });
  }

  viewDoctor(event: any): void {
    // TODO: Implementar vista de detalles
  }
}
