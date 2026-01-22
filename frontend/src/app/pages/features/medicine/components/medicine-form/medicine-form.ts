import { Component, inject, output, signal } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Field, form } from '@angular/forms/signals';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-medicine-form',
  imports: [CommonModule, Field],
  templateUrl: './medicine-form.html',
  styleUrl: './medicine-form.scss',
})
export class MedicineForm {
  router = inject(Router);
  route = inject(ActivatedRoute);

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
      // TODO: Llamar al servicio para obtener datos
    }
  }

  onSubmit(event: Event): void {
    event.preventDefault();
    const formData = this.medicineModel();
    this.submitMedicine.emit(formData);
  }
}