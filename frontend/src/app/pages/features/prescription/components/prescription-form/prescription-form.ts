import { Component, inject, output, signal } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Field, form } from '@angular/forms/signals';
import { CommonModule } from '@angular/common';
import { PrescriptionService } from '../../services/prescription-service';

@Component({
  selector: 'app-prescription-form',
  imports: [CommonModule, Field],
  templateUrl: './prescription-form.html',
  styleUrl: './prescription-form.scss',
})
export class PrescriptionForm {
  router = inject(Router);
  route = inject(ActivatedRoute);
  service = inject(PrescriptionService);

  id = signal(0);
  submitPrescription = output<any>();

  prescriptionModel = signal({
    id: 0,
    generalInstructions: '',
    medicalHistoryId: 0,
    createdAt: null,
  });

  prescriptionForm = form(this.prescriptionModel);

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.id.set(Number(idParam));
      this.GetById();
    }
  }

  onSubmit(event: Event): void {
    event.preventDefault();
    const formData = this.prescriptionModel();
    this.submitPrescription.emit(formData);
  }

  GetById(){
    this.service.GetById(this.id()).subscribe({
      next: (res) => {
        this.prescriptionModel.update(c => ({
          ...c,
          id: res.id,
          generalInstructions: res.generalInstructions,
          medicalHistoryId: res.medicalHistoryId,
          createdAt: res.createdAt
        }));
      },
      error: console.error
    });
  }
} 