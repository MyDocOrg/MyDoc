import { Component, inject } from '@angular/core';
import { DoctorForm } from "../components/doctor-form/doctor-form";
import { Router } from '@angular/router';
import { DoctorService } from '../services/doctor-service';

@Component({
  selector: 'app-doctor-edit',
  imports: [DoctorForm],
  templateUrl: './doctor-edit.html',
  styleUrl: './doctor-edit.scss',
})
export class DoctorEdit {
  service = inject(DoctorService)
  router = inject(Router)

  onEdit(request : any){
    this.service.Edit(request).subscribe({
      next:(res) => {
        this.router.navigate(['/doctor'])
      },
      error:(res) => {
        console.log(res.mensage)
      }
    })
  }
}