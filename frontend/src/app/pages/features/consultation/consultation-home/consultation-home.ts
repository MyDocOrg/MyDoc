import { Component, inject, signal } from '@angular/core';
import { ConsultationService } from '../services/consultation-service';
import { GenericTable } from '../../../../shared/components/generic-table/generic-table';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-consultation-home',
  imports: [GenericTable, RouterLink],
  templateUrl: './consultation-home.html',
  styleUrl: './consultation-home.scss',
})
export class ConsultationHome {
  service = inject(ConsultationService);
  consultationList = signal<any[]>([]);
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
        this.consultationList.set(res.data || res);
      },
      error: (error) => {
        this.loading = false;
        console.error('Error al obtener consultas:', error);
      },
    });
  }

  editConsultation(event: any): void {
    this.router.navigate(['/consultation/edit', event]);
  }

  deleteConsultation(event: any): void {
    this.service.Delete(event).subscribe({
      next: () => {
        this.GetAll();
      },
      error: (error) => {
        console.error('Error al eliminar consulta:', error);
      },
    });
  }

  viewConsultation(event: any): void {
    // TODO: Implementar vista de detalles
  }
}
