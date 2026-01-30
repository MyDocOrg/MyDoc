import { Component, inject } from '@angular/core';
import { AppointmentForm } from "../components/appointment-form/appointment-form";
import { AppointmentService } from '../services/appointment-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-appointment-add',
  imports: [AppointmentForm],
  templateUrl: './appointment-add.html',
  styleUrl: './appointment-add.scss',
})
export class AppointmentAdd {
  service = inject(AppointmentService)
  router = inject(Router);

  onSubmit(event: any) {
    this.service.Add(event).subscribe({
      next: (res) => {
        this.router.navigate(['/appointment']);
      },
      error: (err) => {
        console.error('Error adding clinic:', err);
      }
    });
  }
}
