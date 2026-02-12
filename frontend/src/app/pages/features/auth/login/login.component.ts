import { Component, OnInit, signal } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../../../../material.module';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login-component',
  imports: [RouterModule, MaterialModule, FormsModule, ReactiveFormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent implements OnInit {
  isLoading = signal(false);
  errorMessage = signal('');
  returnUrl: string = '/appointment';

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthService
  ) { }

  ngOnInit() {
    // Obtener la URL de retorno si existe
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/appointment';
  }

  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.minLength(6)]),
    rememberMe: new FormControl(false)
  });

  get f() {
    return this.loginForm.controls;
  }

  get isFormValid(): boolean {
    return this.loginForm.valid;
  }

  submit() {
    if (this.loginForm.valid) {
      this.isLoading.set(true);
      this.errorMessage.set('');

      const loginData = {
        email: this.loginForm.value.email!,
        password: this.loginForm.value.password!
      };

      this.authService.Login(loginData).subscribe({
        next: (response: any) => {
          this.isLoading.set(false);
          if (response.status === 200) {
            // Login exitoso, navegar a la página de retorno o a appointment
            this.router.navigate([this.returnUrl]);
          } else {
            // Manejar respuestas no exitosas del backend
            this.errorMessage.set(response.mensaje || 'Error al iniciar sesión');
          }
        },
        error: (error: any) => {
          this.isLoading.set(false);

          // console.log('Error capturado:', error);
          // console.log('Status code:', error.status);

          // Manejar diferentes tipos de errores
          if (error.status === 404 || error.status === 401) {
            // Usuario no encontrado o credenciales inválidas
            this.errorMessage.set('Usuario o contraseña incorrectos');
          } else if (error.status === 0) {
            this.errorMessage.set('No se pudo conectar con el servidor');
          } else {
            this.errorMessage.set(error.error?.mensaje || 'Error al iniciar sesión');
          }

          console.log('Error message set to:', this.errorMessage());
        }
      });
    }
  }
}
