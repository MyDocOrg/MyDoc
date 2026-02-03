import { Component, inject } from '@angular/core';
import { ClinicForm } from "../components/clinic-form/clinic-form";
import { Router } from '@angular/router';
import { ClinicService } from '../services/clinic-service';

@Component({
  selector: 'app-clinic-edit',
  imports: [ClinicForm],
  templateUrl: './clinic-edit.html',
  styleUrl: './clinic-edit.scss',
})
export class ClinicEdit {
  service = inject(ClinicService)
  router = inject(Router)

  onEdit(clinic : any){
    this.service.Edit(clinic).subscribe({
      next:(res) => {
        this.router.navigate(['/clinic'])
      },
      error:(res) => {
        console.log(res.mensage)
      }
    })
  }
}
