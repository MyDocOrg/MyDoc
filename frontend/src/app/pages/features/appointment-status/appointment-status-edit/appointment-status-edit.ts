import { Component, inject } from '@angular/core';
import { AppointmentStatusForm } from "../components/appointment-status-form/appointment-status-form";
import { Router } from '@angular/router';
import { AppointmentStatusService } from '../services/appointment-status-service';

@Component({
  selector: 'app-appointment-status-edit',
  imports: [AppointmentStatusForm],
  templateUrl: './appointment-status-edit.html',
  styleUrl: './appointment-status-edit.scss',
})
export class AppointmentStatusEdit {
  service = inject(AppointmentStatusService)
  router = inject(Router)

  onEdit(request : any){
    this.service.Edit(request).subscribe({
      next:(res) => {
        this.router.navigate(['/appointment-status'])
      },
      error:(res) => {
        console.log(res.mensage)
      }
    })
  }
}