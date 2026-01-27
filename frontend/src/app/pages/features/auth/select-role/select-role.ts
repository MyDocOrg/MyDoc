import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-select-role',
  imports: [],
  templateUrl: './select-role.html',
  styleUrl: './select-role.scss',
})
export class SelectRole {
  router = inject(Router);
  selectRole(role: 'DOCTOR' | 'PATIENT') {
    this.router.navigate(['/register', role]);
  }
}
