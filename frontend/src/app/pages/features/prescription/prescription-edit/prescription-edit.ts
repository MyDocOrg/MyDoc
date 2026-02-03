import { Component, inject } from '@angular/core';
import { PrescriptionForm } from "../components/prescription-form/prescription-form";
import { Router } from '@angular/router';
import { PrescriptionService } from '../services/prescription-service';

@Component({
  selector: 'app-prescription-edit',
  imports: [PrescriptionForm],
  templateUrl: './prescription-edit.html',
  styleUrl: './prescription-edit.scss',
})
export class PrescriptionEdit {
  service = inject(PrescriptionService)
  router = inject(Router)

  onEdit(request : any){
    this.service.Edit(request).subscribe({
      next:(res) => {
        this.router.navigate(['/prescription'])
      },
      error:(res) => {
        console.log(res.mensage)
      }
    })
  }
}