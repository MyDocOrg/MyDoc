import { Component, inject } from '@angular/core';
import { ConsultationForm } from "../components/consultation-form/consultation-form";
import { ConsultationService } from '../services/consultation-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-consultation-add',
  imports: [ConsultationForm],
  templateUrl: './consultation-add.html',
  styleUrl: './consultation-add.scss',
})
export class ConsultationAdd {
  service = inject(ConsultationService)
  router = inject(Router);

  onSubmitClinic(event: any) {
    this.service.Add(event).subscribe({
      next: (res) => {
        this.router.navigate(['/consultation']);
      },
      error: (err) => {
        console.error('Error adding clinic:', err);
      }
    });
  }
}
