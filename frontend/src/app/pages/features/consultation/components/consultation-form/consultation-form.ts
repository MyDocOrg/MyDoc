import { Component, inject, output, signal } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Field, form } from '@angular/forms/signals';
import { CommonModule } from '@angular/common';
import { ConsultationService } from '../../services/consultation-service';

@Component({
  selector: 'app-consultation-form',
  imports: [CommonModule, Field],
  templateUrl: './consultation-form.html',
  styleUrl: './consultation-form.scss',
})
export class ConsultationForm {
  router = inject(Router);
  route = inject(ActivatedRoute);
  service = inject(ConsultationService);

  id = signal(0);
  submitConsultation = output<any>();

  consultationModel = signal({
    id: 0,
    appointmentId: 0,
    reason: '',
    diagnosis: '',
    consultationDate: '',
    weightKg: '',
    heightCm: '',
  });

  consultationForm = form(this.consultationModel);

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.id.set(Number(idParam));
      this.GetById();
    }
  }

  onSubmit(event: Event): void {
    event.preventDefault();
    const formData = this.consultationModel();
    this.submitConsultation.emit(formData);
  }

  GetById(){
    this.service.GetById(this.id()).subscribe({
      next: (res) => {
        this.consultationModel.update(c => ({
          ...c,
          id: res.id,
          appointmentId: res.appointmentId,
          reason: res.reason,
          diagnosis: res.diagnosis,
          consultationDate: res.consultationDate,
          weightKg: res.weightKg,
          heightCm: res.heightCm
        }));
      },
      error: console.error
    });
  }
} 
