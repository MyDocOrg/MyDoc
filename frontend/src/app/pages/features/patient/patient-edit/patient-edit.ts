import { Component, inject } from '@angular/core';
import { PatientForm } from "../components/patient-form/patient-form";
import { Router } from '@angular/router';
import { PatientService } from '../services/patient-service';

@Component({
  selector: 'app-patient-edit',
  imports: [PatientForm],
  templateUrl: './patient-edit.html',
  styleUrl: './patient-edit.scss',
})
export class PatientEdit {
  service = inject(PatientService)
  router = inject(Router)

  onEdit(request : any){
    this.service.Edit(request).subscribe({
      next:(res) => {
        this.router.navigate(['/patient'])
      },
      error:(res) => {
        console.log(res.mensage)
      }
    })
  }
}