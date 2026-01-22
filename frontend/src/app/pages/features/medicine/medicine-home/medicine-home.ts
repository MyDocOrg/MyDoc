import { Component, inject, signal } from '@angular/core';
import { MedicineService } from '../services/medicine-service';
import { GenericTable } from '../../../../shared/components/generic-table/generic-table';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-medicine-home',
  imports: [GenericTable, RouterLink],
  templateUrl: './medicine-home.html',
  styleUrl: './medicine-home.scss',
})
export class MedicineHome {
  service = inject(MedicineService);
  medicineList = signal<any[]>([]);
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
        this.medicineList.set(res.data || res);
      },
      error: (error) => {
        this.loading = false;
        console.error('Error al obtener medicamentos:', error);
      },
    });
  }

  editMedicine(event: any): void {
    this.router.navigate(['/medicine/edit', event]);
  }

  deleteMedicine(event: any): void {
    this.service.Delete(event).subscribe({
      next: () => {
        this.GetAll();
      },
      error: (error) => {
        console.error('Error al eliminar medicamento:', error);
      },
    });
  }

  viewMedicine(event: any): void {
    // TODO: Implementar vista de detalles
  }
}