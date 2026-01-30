import { Component, inject } from '@angular/core';
import { MedicineForm } from "../components/medicine-form/medicine-form";
import { MedicineService } from '../services/medicine-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-medicine-add',
  imports: [MedicineForm],
  templateUrl: './medicine-add.html',
  styleUrl: './medicine-add.scss',
})
export class MedicineAdd {
  service = inject(MedicineService)
  router = inject(Router);

  onSubmit(event: any) {
    this.service.Add(event).subscribe({
      next: (res) => {
        this.router.navigate(['/medicine']);
      },
      error: (err) => {
        console.error('Error adding medicine:', err);
      }
    });
  }
} 
