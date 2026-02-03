import { Component, inject, output, signal } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Field, form } from '@angular/forms/signals';
import { CommonModule } from '@angular/common';
import { AppointmentService } from '../../services/appointment-service';
import { toSignal } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-appointment-form',
  imports: [CommonModule, Field],
  templateUrl: './appointment-form.html',
  styleUrl: './appointment-form.scss',
})
export class AppointmentForm {
  router = inject(Router);
  route = inject(ActivatedRoute);
  service = inject(AppointmentService);
  doctors = toSignal<any[]>(this.service.GetAllDoctors());
  clinics = toSignal<any[]>(this.service.GetAllClinics());
  statuses = toSignal<any[]>(this.service.GetAllAppointmentStatuses());

  id = signal(0);
  submitAppointment = output<any>();

  appointmentModel = signal({
    id: 0,
    doctorId: '',
    clinicId: '',
    statusId: '',
    appointmentDate: ''
  });

  appointmentForm = form(this.appointmentModel);

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.id.set(Number(idParam));
      this.GetById();
    }
  }

  onSubmit(event: Event): void {
    event.preventDefault();
    const formData = this.appointmentModel();
    this.submitAppointment.emit(formData);
  }
  GetById(){
    this.service.GetById(this.id()).subscribe({
      next: (res) => {
        this.appointmentModel.update(c => ({
          ...c,
          id : res.id,
          doctorId : res.doctor_id,
          clinicId : res.clinic_id,
          statusId : res.status_id,
          appointmentDate : res.appointment_date
        }));
      },
      error: console.error
    });
  }
}
