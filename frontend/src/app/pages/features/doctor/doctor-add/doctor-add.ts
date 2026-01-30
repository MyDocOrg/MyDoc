import { Component, inject } from '@angular/core';
import { DoctorForm } from "../components/doctor-form/doctor-form";
import { DoctorService } from '../services/doctor-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-doctor-add',
  imports: [DoctorForm],
  templateUrl: './doctor-add.html',
  styleUrl: './doctor-add.scss',
})
export class DoctorAdd {
  service = inject(DoctorService)
  router = inject(Router);

  onSubmit(event: any) {
    this.service.Add(event).subscribe({
      next: (res) => {
        this.router.navigate(['/doctor']);
      },
      error: (err) => {
        console.error('Error adding doctor:', err);
      }
    });
  }
} 
