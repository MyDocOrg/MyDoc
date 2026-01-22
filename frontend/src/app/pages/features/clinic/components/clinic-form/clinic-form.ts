import { Component, inject, output, signal } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Field, form } from '@angular/forms/signals';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-clinic-form',
  imports: [CommonModule, Field],
  templateUrl: './clinic-form.html',
  styleUrl: './clinic-form.scss',
})
export class ClinicForm {
  router = inject(Router);
  route = inject(ActivatedRoute);

  id = signal(0);
  submitClinic = output<any>();

  clinicModel = signal({
    id: 0,
    name: '',
    address: '',
    phone: '',
    email: '',
    isActive: true,
    createdAt: null,
    updatedAt: null,
  });

  clinicForm = form(this.clinicModel);

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.id.set(Number(idParam));
      // TODO: Llamar al servicio para obtener datos
    }
  }

  onSubmit(event: Event): void {
    event.preventDefault();
    const formData = this.clinicModel();
    this.submitClinic.emit(formData);
  }
}
