import { Component, inject } from '@angular/core';
import { AppointmentForm } from "../components/appointment-form/appointment-form";
import { Router } from '@angular/router';
import { ClinicService } from '../../clinic/services/clinic-service';
import { AppointmentService } from '../services/appointment-service';

@Component({
  selector: 'app-appointment-edit',
  imports: [AppointmentForm],
  templateUrl: './appointment-edit.html',
  styleUrl: './appointment-edit.scss',
})
export class AppointmentEdit {
  service = inject(AppointmentService)
  router = inject(Router)

  onEdit(request : any){
    this.service.Edit(request).subscribe({
      next:(res) => {
        this.router.navigate(['/appointment'])
      },
      error:(res) => {
        console.log(res.mensage)
      }
    })
  }
}
