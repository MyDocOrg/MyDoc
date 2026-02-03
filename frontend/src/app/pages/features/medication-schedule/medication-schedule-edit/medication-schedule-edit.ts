import { Component, inject } from '@angular/core';
import { MedicationScheduleForm } from "../components/medication-schedule-form/medication-schedule-form";
import { Router } from '@angular/router';
import { MedicationScheduleService } from '../services/medication-schedule-service';

@Component({
  selector: 'app-medication-schedule-edit',
  imports: [MedicationScheduleForm],
  templateUrl: './medication-schedule-edit.html',
  styleUrl: './medication-schedule-edit.scss',
})
export class MedicationScheduleEdit {
  service = inject(MedicationScheduleService)
  router = inject(Router)

  onEdit(request : any){
    this.service.Edit(request).subscribe({
      next:(res) => {
        this.router.navigate(['/medication-schedule'])
      },
      error:(res) => {
        console.log(res.mensage)
      }
    })
  }
}