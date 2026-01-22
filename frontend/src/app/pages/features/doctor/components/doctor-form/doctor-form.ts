import { Component, inject, output, signal } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Field, form } from '@angular/forms/signals';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-doctor-form',
  imports: [CommonModule, Field],
  templateUrl: './doctor-form.html',
  styleUrl: './doctor-form.scss',
})
export class DoctorForm {
  router = inject(Router);
  route = inject(ActivatedRoute);

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
      // TODO: Llamar al servicio para obtener datos
    }
  }

  onSubmit(event: Event): void {
    event.preventDefault();
    const formData = this.doctorModel();
    this.submitDoctor.emit(formData);
  }
}
