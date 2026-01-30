import { Component, inject } from '@angular/core';
import { PatientForm } from "../components/patient-form/patient-form";
import { PatientService } from '../services/patient-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-patient-add',
  imports: [PatientForm],
  templateUrl: './patient-add.html',
  styleUrl: './patient-add.scss',
})
export class PatientAdd {
  service = inject(PatientService)
  router = inject(Router);

  onSubmit(event: any) {
    this.service.Add(event).subscribe({
      next: (res) => {
        this.router.navigate(['/patient']);
      },
      error: (err) => {
        console.error('Error adding patient:', err);
      }
    });
  }
} 
