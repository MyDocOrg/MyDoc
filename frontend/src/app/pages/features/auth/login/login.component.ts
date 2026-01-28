import { Component, inject, signal } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { AuthService } from '../services/auth-service';
import { TokenService } from '../../../../core/services/token-service';

@Component({
  selector: 'app-login-component',
  imports: [
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatCheckboxModule,
    RouterLink
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent {
  loginForm: FormGroup;
  tokenService = inject(TokenService);  
  hidePassword = signal(true);
  service = inject(AuthService); 

  constructor(private fb: FormBuilder, private router: Router) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  togglePasswordVisibility() {
    this.hidePassword.set(!this.hidePassword());
  }

  onSubmit() {
    // Navegar al home sin validaciones (como solicitó el usuario)
    if (this.loginForm.valid) {
      this.service.Login(this.loginForm.value).subscribe({
        next: (response) => {
          this.tokenService.setToken(response.data);
          this.router.navigate(['/appointment']);
        },
        error:(response) =>{
          console.log('Error en login', response);
        }
      })  
    }
  }
}
