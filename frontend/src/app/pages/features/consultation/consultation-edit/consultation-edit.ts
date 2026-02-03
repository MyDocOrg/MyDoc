import { Component, inject } from '@angular/core';
import { ConsultationForm } from "../components/consultation-form/consultation-form";
import { Router } from '@angular/router';
import { ConsultationService } from '../services/consultation-service';

@Component({
  selector: 'app-consultation-edit',
  imports: [ConsultationForm],
  templateUrl: './consultation-edit.html',
  styleUrl: './consultation-edit.scss',
})
export class ConsultationEdit {
  service = inject(ConsultationService)
  router = inject(Router)

  onEdit(request : any){
    this.service.Edit(request).subscribe({
      next:(res) => {
        this.router.navigate(['/consultation'])
      },
      error:(res) => {
        console.log(res.mensage)
      }
    })
  }
}