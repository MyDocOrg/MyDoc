import { Component, inject } from '@angular/core';
import { MedicationScheduleForm } from "../components/medication-schedule-form/medication-schedule-form";
import { MedicationScheduleService } from '../services/medication-schedule-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-medication-schedule-add',
  imports: [MedicationScheduleForm],
  templateUrl: './medication-schedule-add.html',
  styleUrl: './medication-schedule-add.scss',
})
export class MedicationScheduleAdd {
  service = inject(MedicationScheduleService)
  router = inject(Router);

  onSubmit(event: any) {
    this.service.Add(event).subscribe({
      next: (res) => {
        this.router.navigate(['/medication-schedule']);
      },
      error: (err) => {
        console.error('Error adding medication schedule:', err);
      }
    });
  }
} 
