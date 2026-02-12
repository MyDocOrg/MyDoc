import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';
import { AuthService } from '../../pages/features/auth/services/auth.service';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
    const authService = inject(AuthService);
    const router = inject(Router);

    // Obtener el token
    const token = authService.getToken();

    // Clonar la request y agregar el token si existe
    let authReq = req;
    if (token) {
        authReq = req.clone({
            setHeaders: {
                Authorization: `Bearer ${token}`
            }
        });
    }

    // Continuar con la request y manejar errores
    return next(authReq).pipe(
        catchError((error) => {
            // Si recibimos un 401 (no autorizado), redirigir al login
            if (error.status === 401) {
                authService.logout();
            }

            // Si recibimos un 403 (prohibido), mostrar mensaje
            if (error.status === 403) {
                console.error('Acceso prohibido: no tienes permisos para esta acción');
            }

            return throwError(() => error);
        })
    );
};
