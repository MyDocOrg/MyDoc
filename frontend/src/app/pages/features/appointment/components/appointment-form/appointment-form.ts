import { Component, inject, output, signal } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Field, form } from '@angular/forms/signals';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-appointment-form',
  imports: [CommonModule, Field],
  templateUrl: './appointment-form.html',
  styleUrl: './appointment-form.scss',
})
export class AppointmentForm {
  router = inject(Router);
  route = inject(ActivatedRoute);

  id = signal(0);
  submitAppointment = output<any>();

  appointmentModel = signal({
    id: 0,
    doctorId: 0,
    clinicId: 0,
    patientId: 0,
    statusId: 0,
    appointmentDate: '',
    createdAt: null,
  });

  appointmentForm = form(this.appointmentModel);

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.id.set(Number(idParam));
      // TODO: Llamar al servicio para obtener datos
    }
  }

  onSubmit(event: Event): void {
    event.preventDefault();
    const formData = this.appointmentModel();
    this.submitAppointment.emit(formData);
  }
}
