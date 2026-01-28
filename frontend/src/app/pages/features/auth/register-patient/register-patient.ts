import { Component, computed, inject, output, signal } from '@angular/core';
import { email, Field, form } from '@angular/forms/signals';
import { Router } from '@angular/router';
import { MatCardHeader, MatCard, MatCardTitle } from "@angular/material/card";
import { MatIcon } from "@angular/material/icon";

@Component({
  selector: 'app-register-patient',
  imports: [Field, MatCardHeader, MatCard, MatCardTitle, MatIcon],
  templateUrl: './register-patient.html',
  styleUrl: './register-patient.scss',
})
export class RegisterPatient {
  router = inject(Router);
  patientData = output<null | any>(); 
  fullName = computed(() =>
    `${this.patientModel().firstName} ${this.patientModel().lastName}`.trim()
  );

  patientModel = signal({
    email: '',
    password: '',
    birth_date: '',
    gender: '', 
    phone: '',
    address:'',
    firstName: '',
    lastName: ''
  })

  patientForm = form(this.patientModel);

  onSubmitPatient(event: Event) {
    event.preventDefault();
    this.patientData.emit({
      ...this.patientModel(),
      full_name: this.fullName()
    });
  }

}
