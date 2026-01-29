import { Component, inject } from '@angular/core';
import { ClinicForm } from "../components/clinic-form/clinic-form";
import { Router } from '@angular/router';
import { ClinicService } from '../services/clinic-service';

@Component({
  selector: 'app-clinic-add',
  imports: [ClinicForm],
  templateUrl: './clinic-add.html',
  styleUrl: './clinic-add.scss',
})
export class ClinicAdd {
  service = inject(ClinicService)
  router = inject(Router);

  onSubmitClinic(event: any) {
    this.service.Add(event).subscribe({
      next: (res) => {
        this.router.navigate(['/clinic']);
      },
      error: (err) => {
        console.error('Error adding clinic:', err);
      }
    });
  }
}
