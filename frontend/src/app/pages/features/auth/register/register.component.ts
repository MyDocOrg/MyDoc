import { Component, inject, signal } from '@angular/core';
import { Router } from '@angular/router';
import { RegisterDoctor } from "../register-doctor/register-doctor";
import { RegisterPatient } from "../register-patient/register-patient";
import { AuthService } from '../services/auth.service';
import { MatStepperModule } from '@angular/material/stepper';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register-component',
  imports: [RegisterDoctor, RegisterPatient, MatStepperModule, MatButtonModule, MatCardModule, CommonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
})
export class RegisterComponent {
  service = inject(AuthService);
  roles = signal<any[]>([]);
  subscriptions = signal<any[]>([]);
  router = inject(Router);

  selectedRole = signal<any>(null);
  selectedSubscription = signal<any>(null);

  ngOnInit() {
    // Carga inicial de datos
    this.service.GetRolesMyDoc().subscribe(res => this.roles.set(res.data));
    this.service.GetSuscriptionsMyDoc().subscribe(res => this.subscriptions.set(res.data));
  }

  selectRole(role: any) {
    this.selectedRole.set(role);
  }

  selectSubscription(sub: any) {
    this.selectedSubscription.set(sub);
  }

  onSubmitPatient(data: any) {
    const payload = {
      ...data,
      suscriptionId: this.selectedSubscription()?.id,
      roleId: this.selectedRole()?.id,
      applicationId: this.selectedRole()?.applicationId
    }
    console.log("Payload para paciente:", payload);
    console.log(data);
    this.service.RegisterPatient(payload).subscribe({
      next: (res) => {
        this.router.navigate(['/login']);
      },
      error: (err) => {
        console.log(err);
      }
    })
  }

  onSubmitDoctor(data: any) {
    const payload = {
      ...data,
      suscriptionId: this.selectedSubscription()?.id,
      roleId: this.selectedRole()?.id,
      applicationId: this.selectedRole()?.applicationId
    }
    console.log("Payload para doctor:", payload);
    console.log(data);
    this.service.RegisterDoctor(payload).subscribe({
      next: (res) => {
        this.router.navigate(['/login']);
      },
      error: (err) => {
        console.log(err);
      }
    })
  }
}
