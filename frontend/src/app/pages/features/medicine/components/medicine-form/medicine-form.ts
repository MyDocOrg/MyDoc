import { Component, inject, output, signal } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Field, form } from '@angular/forms/signals';
import { CommonModule } from '@angular/common';
import { MedicineService } from '../../services/medicine-service';

@Component({
  selector: 'app-medicine-form',
  imports: [CommonModule, Field],
  templateUrl: './medicine-form.html',
  styleUrl: './medicine-form.scss',
})
export class MedicineForm {
  router = inject(Router);
  route = inject(ActivatedRoute);
  service = inject(MedicineService);

  id = signal(0);
  submitMedicine = output<any>();

  medicineModel = signal({
    id: 0,
    name: '',
    description: '',
    presentation: '',
    isActive: true,
  });

  medicineForm = form(this.medicineModel);

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.id.set(Number(idParam));
      this.GetById();
    }
  }

  onSubmit(event: Event): void {
    event.preventDefault();
    const formData = this.medicineModel();
    this.submitMedicine.emit(formData);
  }

  GetById(){
    this.service.GetById(this.id()).subscribe({
      next: (res) => {
        this.medicineModel.update(c => ({
          ...c,
          id: res.id,
          name: res.name,
          description: res.description,
          presentation: res.presentation,
          isActive: res.isActive
        }));
      },
      error: console.error
    });
  }
} 