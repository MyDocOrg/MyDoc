import { Component, inject } from '@angular/core';
import { MedicalHistoryForm } from "../components/medical-history-form/medical-history-form";
import { Router } from '@angular/router';
import { MedicalHistoryService } from '../services/medical-history-service';

@Component({
  selector: 'app-medical-history-edit',
  imports: [MedicalHistoryForm],
  templateUrl: './medical-history-edit.html',
  styleUrl: './medical-history-edit.scss',
})
export class MedicalHistoryEdit {
  service = inject(MedicalHistoryService)
  router = inject(Router)

  onEdit(request : any){
    this.service.Edit(request).subscribe({
      next:(res) => {
        this.router.navigate(['/medical-history'])
      },
      error:(res) => {
        console.log(res.mensage)
      }
    })
  }
}