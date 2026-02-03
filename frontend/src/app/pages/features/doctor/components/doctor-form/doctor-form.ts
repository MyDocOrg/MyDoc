import { Component, inject, output, signal } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Field, form } from '@angular/forms/signals';
import { CommonModule } from '@angular/common';
import { DoctorService } from '../../services/doctor-service';

@Component({
  selector: 'app-doctor-form',
  imports: [CommonModule, Field],
  templateUrl: './doctor-form.html',
  styleUrl: './doctor-form.scss',
})
export class DoctorForm {
  router = inject(Router);
  route = inject(ActivatedRoute);
  service = inject(DoctorService);

  id = signal(0);
  submitDoctor = output<any>();

  doctorModel = signal({
    id: 0,
    userId: null,
    fullName: '',
    specialty: '',
    professionalLicense: '',
    phone: '',
    email: '',
    isActive: true,
    createdAt: null,
    updatedAt: null,
  });

  doctorForm = form(this.doctorModel);

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.id.set(Number(idParam));
      this.GetById();
    }
  }

  onSubmit(event: Event): void {
    event.preventDefault();
    const formData = this.doctorModel();
    this.submitDoctor.emit(formData);
  }

  GetById(){
    this.service.GetById(this.id()).subscribe({
      next: (res) => {
        this.doctorModel.update(c => ({
          ...c,
          id: res.id,
          userId: res.userId,
          fullName: res.fullName,
          specialty: res.specialty,
          professionalLicense: res.professionalLicense,
          phone: res.phone,
          email: res.email,
          isActive: res.isActive,
          createdAt: res.createdAt,
          updatedAt: res.updatedAt
        }));
      },
      error: console.error
    });
  }
} 
