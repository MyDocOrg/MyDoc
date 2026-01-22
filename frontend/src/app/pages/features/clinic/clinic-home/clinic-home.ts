import { Component, inject, signal } from '@angular/core';
import { ClinicService } from '../services/clinic-service';
import { GenericTable } from '../../../../shared/components/generic-table/generic-table';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-clinic-home',
  imports: [GenericTable, RouterLink],
  templateUrl: './clinic-home.html',
  styleUrl: './clinic-home.scss',
})
export class ClinicHome {
  service = inject(ClinicService);
  clinicList = signal<any[]>([]);
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
        this.clinicList.set(res.data || res);
      },
      error: (error) => {
        this.loading = false;
        console.error('Error al obtener clínicas:', error);
      },
    });
  }

  editClinic(event: any): void {
    this.router.navigate(['/clinic/edit', event]);
  }

  deleteClinic(event: any): void {
    this.service.Delete(event).subscribe({
      next: () => {
        this.GetAll();
      },
      error: (error) => {
        console.error('Error al eliminar clínica:', error);
      },
    });
  }

  viewClinic(event: any): void {
    // TODO: Implementar vista de detalles
  }
}
