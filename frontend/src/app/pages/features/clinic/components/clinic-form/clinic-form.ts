import { Component, inject, output, signal } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Field, form } from '@angular/forms/signals';
import { CommonModule } from '@angular/common';
import { ClinicService } from '../../services/clinic-service';

@Component({
  selector: 'app-clinic-form',
  imports: [CommonModule, Field],
  templateUrl: './clinic-form.html',
  styleUrl: './clinic-form.scss',
})
export class ClinicForm {
  router = inject(Router);
  route = inject(ActivatedRoute);
  service = inject(ClinicService)

  id = signal(0);
  submitClinic = output<any>();

  clinicModel = signal({
    id: 0,
    name: '',
    address: '',
    phone: '',
    email: ''
  });

  clinicForm = form(this.clinicModel);

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.id.set(Number(idParam));
      this.GetById();
    }
  }

  onSubmit(event: Event): void {
    event.preventDefault();
    const formData = this.clinicModel();
    this.submitClinic.emit(formData);
  }
  GetById(){
    this.service.GetById(this.id()).subscribe({
      next: (res) => {
        console.log(res)
        this.clinicModel.update(c => ({
          ...c,
          id : res.id,
          name : res.name,
          address : res.address,
          phone : res.phone,
          email : res.email
        }));
      },
      error: console.error
    });
  }
}
