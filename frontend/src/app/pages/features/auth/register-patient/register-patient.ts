import { Component, inject, signal } from '@angular/core';
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

  patientModel = signal({
    email: '',
    password: '',
    birthDate: '',
    gender: '', 
    phone: '',
    address:'',
    firstName: '',
    lastName: ''
  })

  patientForm = form(this.patientModel);

  onSubmitPatient(event: Event) {
    event.preventDefault();
    this.router.navigate(['/appointment']);
  }
}
