import { Component, inject, output, signal } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Field, form } from '@angular/forms/signals';
import { CommonModule } from '@angular/common';
import { MedicationScheduleService } from '../../services/medication-schedule-service';

@Component({
  selector: 'app-medication-schedule-form',
  imports: [CommonModule, Field],
  templateUrl: './medication-schedule-form.html',
  styleUrl: './medication-schedule-form.scss',
})
export class MedicationScheduleForm {
  router = inject(Router);
  route = inject(ActivatedRoute);
  service = inject(MedicationScheduleService);

  id = signal(0);
  submitMedicationSchedule = output<any>();

  medicationScheduleModel = signal({
    id: 0,
    prescriptionId: 0,
    medicineId: 0,
    scheduledDate: '',
    scheduledTime: '',
    taken: false,
  });

  medicationScheduleForm = form(this.medicationScheduleModel);

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.id.set(Number(idParam));
      this.GetById();
    }
  }

  GetById(){
    this.service.GetById(this.id()).subscribe({
      next: (res) => {
        this.medicationScheduleModel.update(c => ({
          ...c,
          id: res.id,
          prescriptionId: res.prescriptionId,
          medicineId: res.medicineId,
          scheduledDate: res.scheduledDate,
          scheduledTime: res.scheduledTime,
          taken: res.taken,
        }));
      },
      error: (res) => { console.error(res.message) }
    });
  }

  onSubmit(event: Event): void {
    event.preventDefault();
    const formData = this.medicationScheduleModel();
    this.submitMedicationSchedule.emit(formData);
  }
}