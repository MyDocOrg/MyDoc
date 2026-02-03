import { Component, inject, output, signal } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Field, form } from '@angular/forms/signals';
import { CommonModule } from '@angular/common';
import { MedicalHistoryService } from '../../services/medical-history-service';

@Component({
  selector: 'app-medical-history-form',
  imports: [CommonModule],
  templateUrl: './medical-history-form.html',
  styleUrl: './medical-history-form.scss',
})
export class MedicalHistoryForm {
  router = inject(Router);
  route = inject(ActivatedRoute);
  service = inject(MedicalHistoryService);

  id = signal(0);
  submitMedicalHistory = output<any>();

  medicalHistoryModel = signal({
    id: 0,
    consultationId: 0,
    notes: '',
    createdAt: null
  });

  medicalHistoryForm = form(this.medicalHistoryModel);

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.id.set(Number(idParam));
      this.GetById();
    }
  }

  onSubmit(event: Event): void {
    event.preventDefault();
    const formData = this.medicalHistoryModel();
    this.submitMedicalHistory.emit(formData);
  }

  GetById(){
    this.service.GetById(this.id()).subscribe({
      next: (res) => {
        this.medicalHistoryModel.update(c => ({
          ...c,
          id: res.id,
          consultationId: res.consultationId,
          notes: res.notes,
          createdAt: res.createdAt
        }));
      },
      error: console.error
    });
  }
} 
