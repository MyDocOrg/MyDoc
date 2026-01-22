import { Component, inject, output, signal } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Field, form } from '@angular/forms/signals';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-patient-form',
  imports: [CommonModule, Field],
  templateUrl: './patient-form.html',
  styleUrl: './patient-form.scss',
})
export class PatientForm {
  router = inject(Router);
  route = inject(ActivatedRoute);

  id = signal(0);
  submitPatient = output<any>();

  patientModel = signal({
    id: 0,
    userId: null,
    fullName: '',
    birthDate: '',
    gender: '',
    phone: '',
    email: '',
    address: '',
    isActive: true,
    createdAt: null,
    updatedAt: null,
  });

  patientForm = form(this.patientModel);

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.id.set(Number(idParam));
      // TODO: Llamar al servicio para obtener datos
    }
  }

  onSubmit(event: Event): void {
    event.preventDefault();
    const formData = this.patientModel();
    this.submitPatient.emit(formData);
  }
}
