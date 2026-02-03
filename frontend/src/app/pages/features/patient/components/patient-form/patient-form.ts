import { Component, inject, output, signal } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Field, form } from '@angular/forms/signals';
import { CommonModule } from '@angular/common';
import { PatientService } from '../../services/patient-service';

@Component({
  selector: 'app-patient-form',
  imports: [CommonModule, Field],
  templateUrl: './patient-form.html',
  styleUrl: './patient-form.scss',
})
export class PatientForm {
  router = inject(Router);
  route = inject(ActivatedRoute);
  service = inject(PatientService);

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
      this.GetById();
    }
  }

  onSubmit(event: Event): void {
    event.preventDefault();
    const formData = this.patientModel();
    this.submitPatient.emit(formData);
  }

  GetById(){
    this.service.GetById(this.id()).subscribe({
      next: (res) => {
        this.patientModel.update(c => ({
          ...c,
          id: res.id,
          userId: res.userId,
          fullName: res.fullName,
          birthDate: res.birthDate,
          gender: res.gender,
          phone: res.phone,
          email: res.email,
          address: res.address,
          isActive: res.isActive,
          createdAt: res.createdAt,
          updatedAt: res.updatedAt
        }));
      },
      error: console.error
    });
  }
} 
