import { Component, inject, signal } from '@angular/core';
import { MedicationScheduleService } from '../services/medication-schedule-service';
import { GenericTable } from '../../../../shared/components/generic-table/generic-table';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-medication-schedule-home',
  imports: [GenericTable, RouterLink],
  templateUrl: './medication-schedule-home.html',
  styleUrl: './medication-schedule-home.scss',
})
export class MedicationScheduleHome {
  service = inject(MedicationScheduleService);
  medicationScheduleList = signal<any[]>([]);
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
        this.medicationScheduleList.set(res.data || res);
      },
      error: (error) => {
        this.loading = false;
        console.error('Error al obtener horarios de medicación:', error);
      },
    });
  }

  editMedicationSchedule(event: any): void {
    this.router.navigate(['/medication-schedule/edit', event]);
  }

  deleteMedicationSchedule(event: any): void {
    this.service.Delete(event).subscribe({
      next: () => {
        this.GetAll();
      },
      error: (error) => {
        console.error('Error al eliminar horario de medicación:', error);
      },
    });
  }

  viewMedicationSchedule(event: any): void {
    // TODO: Implementar vista de detalles
  }
}