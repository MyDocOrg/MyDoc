import { Component, inject, output, signal } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Field, form } from '@angular/forms/signals';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-prescription-form',
  imports: [CommonModule, Field],
  templateUrl: './prescription-form.html',
  styleUrl: './prescription-form.scss',
})
export class PrescriptionForm {
  router = inject(Router);
  route = inject(ActivatedRoute);

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
      // TODO: Llamar al servicio para obtener datos
    }
  }

  onSubmit(event: Event): void {
    event.preventDefault();
    const formData = this.prescriptionModel();
    this.submitPrescription.emit(formData);
  }
}