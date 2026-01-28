import { Component, computed, inject, output, signal } from '@angular/core';
import { Field, form } from '@angular/forms/signals';
import { Router } from '@angular/router';
import { MatCardTitle, MatCardHeader, MatCard } from "@angular/material/card";
import { MatIcon } from "@angular/material/icon";

@Component({
  selector: 'app-register-doctor',
  imports: [Field, MatCardTitle, MatCardHeader, MatCard, MatIcon],
  templateUrl: './register-doctor.html',
  styleUrl: './register-doctor.scss',
})
export class RegisterDoctor {
  router = inject(Router);
  doctorData = output<null | any>();
  fullName = computed(() =>
    `${this.doctorModel().firstName} ${this.doctorModel().lastName}`.trim()
  );

  doctorModel = signal({
    email: '',
    password: '',
    specialty: '',
    professional_license: '',
    phone: '',
    address:'',
    firstName: '',
    lastName: ''
  })

  doctorForm = form(this.doctorModel);

  onSubmitDoctor(event: Event) {
    event.preventDefault();
    this.doctorData.emit({
      ...this.doctorModel(),
      full_name: this.fullName()
    });
  }
}
