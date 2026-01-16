import { Component, inject, OnInit, output, signal } from '@angular/core';
import { PatientService } from '../../services/patient-service';
import { IPatient } from '../../interfaces/IPatient';
import { Field, form, required } from '@angular/forms/signals';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-patient-form',
  imports: [Field],
  templateUrl: './patient-form.html',
  styleUrl: './patient-form.scss',
})
export class PatientForm implements OnInit {
  id = signal<number | null>(null);
  route = inject(ActivatedRoute);
  router = inject(Router);  
  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.id.set(Number(idParam));
    }
  }
  service = inject(PatientService);
  formData = output<IPatient>();
  patientModel = signal<IPatient>({
    id: 0,
    firstName: '',
    lastName: '',
  })

  patientForm = form(this.patientModel, (patient) => {
    required(patient.firstName, { message: 'First name is required' });
    required(patient.lastName, { message: 'Last name is required' });
  })

  onSubmit(event: Event) {
    event.preventDefault();
    this.formData.emit(this.patientModel());
  }
}
