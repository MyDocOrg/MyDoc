import { Component, inject } from '@angular/core';
import { PrescriptionForm } from "../components/prescription-form/prescription-form";
import { PrescriptionService } from '../services/prescription-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-prescription-add',
  imports: [PrescriptionForm],
  templateUrl: './prescription-add.html',
  styleUrl: './prescription-add.scss',
})
export class PrescriptionAdd {
  service = inject(PrescriptionService)
  router = inject(Router);

  onSubmit(event: any) {
    this.service.Add(event).subscribe({
      next: (res) => {
        this.router.navigate(['/prescription']);
      },
      error: (err) => {
        console.error('Error adding prescription:', err);
      }
    });
  }
} 
