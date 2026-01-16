import { Component, inject, signal } from '@angular/core';
import { PatientService } from '../services/patient-service';
import { PatientForm } from "../components/patient-form/patient-form";

@Component({
  selector: 'app-patient-add',
  imports: [PatientForm],
  templateUrl: './patient-add.html',
  styleUrl: './patient-add.scss',
})
export class PatientAdd {
  service = inject(PatientService);

  onCreate(data: any) {
    this.service.Add(data).subscribe({
      next: (res) => {
        console.log(res);
      },
      error: (res) => {
        console.log(res);
      }
    });
  }
}