import { Component, inject, signal } from '@angular/core';
import { PrescriptionService } from '../services/prescription-service';
import { GenericTable } from '../../../../shared/components/generic-table/generic-table';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-prescription-home',
  imports: [GenericTable, RouterLink],
  templateUrl: './prescription-home.html',
  styleUrl: './prescription-home.scss',
})
export class PrescriptionHome {
  service = inject(PrescriptionService);
  prescriptionList = signal<any[]>([]);
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
        this.prescriptionList.set(res.data || res);
      },
      error: (error) => {
        this.loading = false;
        console.error('Error al obtener prescripciones:', error);
      },
    });
  }

  editPrescription(event: any): void {
    this.router.navigate(['/prescription/edit', event]);
  }

  deletePrescription(event: any): void {
    this.service.Delete(event).subscribe({
      next: () => {
        this.GetAll();
      },
      error: (error) => {
        console.error('Error al eliminar prescripción:', error);
      },
    });
  }

  viewPrescription(event: any): void {
    // TODO: Implementar vista de detalles
  }
}