import { Component, inject } from '@angular/core';
import { AppointmentStatusForm } from "../components/appointment-status-form/appointment-status-form";
import { AppointmentStatusService } from '../services/appointment-status-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-appointment-status-add',
  imports: [AppointmentStatusForm],
  templateUrl: './appointment-status-add.html',
  styleUrl: './appointment-status-add.scss',
})
export class AppointmentStatusAdd {
  service = inject(AppointmentStatusService)
  router = inject(Router);

  onSubmit(event: any) {
    this.service.Add(event).subscribe({
      next: (res) => {
        this.router.navigate(['/appointment-status']);
      },
      error: (err) => {
        console.error('Error adding appointment status:', err);
      }
    });
  }
} 
