import { Component, inject, output, signal } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Field, form } from '@angular/forms/signals';
import { CommonModule } from '@angular/common';
import { AppointmentStatusService } from '../../services/appointment-status-service';

@Component({
  selector: 'app-appointment-status-form',
  imports: [CommonModule, Field],
  templateUrl: './appointment-status-form.html',
  styleUrl: './appointment-status-form.scss',
})
export class AppointmentStatusForm {
  router = inject(Router);
  route = inject(ActivatedRoute);
  service = inject(AppointmentStatusService);

  id = signal(0);
  submitAppointmentStatus = output<any>();

  appointmentStatusModel = signal({
    id: 0,
    name: '',
    description: '',
    isActive: true,
  });

  appointmentStatusForm = form(this.appointmentStatusModel);

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.id.set(Number(idParam));
      this.GetById();
    }
  }

  onSubmit(event: Event): void {
    event.preventDefault();
    const formData = this.appointmentStatusModel();
    this.submitAppointmentStatus.emit(formData);
  }

  GetById(){
    this.service.GetById(this.id()).subscribe({
      next: (res) => {
        this.appointmentStatusModel.update(c => ({
          ...c,
          id: res.id,
          name: res.name,
          description: res.description,
          isActive: res.isActive
        }));
      },
      error: console.error
    });
  }
} 