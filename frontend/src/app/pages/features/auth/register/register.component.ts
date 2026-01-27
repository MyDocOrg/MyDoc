import { Component, inject, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RegisterDoctor } from "../register-doctor/register-doctor";
import { RegisterPatient } from "../register-patient/register-patient";

@Component({
  selector: 'app-register-component',
  imports: [RegisterDoctor, RegisterPatient],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
})
export class RegisterComponent {
  route = inject(ActivatedRoute);
  role = signal<'DOCTOR' | 'PATIENT' | ''>('');
  
  ngOnInit() {
    const roleP = this.route.snapshot.paramMap.get('role') as any;
    if (roleP === 'DOCTOR' || roleP === 'PATIENT') {
      console.log("Role param:", roleP);
      this.role.set(roleP);
    }
  }
}
