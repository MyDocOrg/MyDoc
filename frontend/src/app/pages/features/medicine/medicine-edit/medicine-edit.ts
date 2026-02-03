import { Component, inject } from '@angular/core';
import { MedicineForm } from "../components/medicine-form/medicine-form";
import { Router } from '@angular/router';
import { MedicineService } from '../services/medicine-service';

@Component({
  selector: 'app-medicine-edit',
  imports: [MedicineForm],
  templateUrl: './medicine-edit.html',
  styleUrl: './medicine-edit.scss',
})
export class MedicineEdit {
  service = inject(MedicineService)
  router = inject(Router)

  onEdit(request : any){
    this.service.Edit(request).subscribe({
      next:(res) => {
        this.router.navigate(['/medicine'])
      },
      error:(res) => {
        console.log(res.mensage)
      }
    })
  }
}