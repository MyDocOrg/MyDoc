import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Router } from '@angular/router';
import { IApiResponse } from '../../../../shared/Interfaces/IApiResponse';
import { environment } from '../../../../../environments/environment';

export interface User {
  id: string;
  email: string;
  roleId: string;
  roleName: string;
  applicationId: string;
  applicationName: string;
  patientId?: string;
}

export interface DecodedToken {
  id: string;
  email: string;
  roleId: string;
  roleName: string;
  applicationId: string;
  applicationName: string;
  patientId?: string;
  exp: number;
  iss: string;
  aud: string;
}

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly TOKEN_KEY = 'auth_token';
  private readonly USER_KEY = 'auth_user';
  private currentUserSubject = new BehaviorSubject<User | null>(this.getUserFromStorage());

  public currentUser$ = this.currentUserSubject.asObservable();

  http = inject(HttpClient);
  router = inject(Router);

  // Método de login mejorado con manejo de tokens
  Login(data: any): Observable<IApiResponse<any>> {
    const headers = new HttpHeaders({ 'X-Application-Name': 'MyDoc' });
    return this.http.post<IApiResponse<any>>(`${environment.apiAuthUrl}/api/Auth/Login`, data, { headers }).pipe(
      tap(response => {
        if (response.status === 200 && response.data) {
          // Guardar el token
          this.setToken(response.data);

          // Decodificar y guardar el usuario
          const user = this.decodeToken(response.data);
          if (user) {
            this.setUser(user);
            this.currentUserSubject.next(user);
          }
        }
      })
    );
  }

  // Métodos existentes
  GetSuscriptionsMyDoc(): Observable<IApiResponse<any[]>> {
    return this.http.get<IApiResponse<any[]>>(`${environment.apiAuthUrl}/suscription/mydoc`);
  }

  GetRolesMyDoc(): Observable<IApiResponse<any[]>> {
    return this.http.get<IApiResponse<any[]>>(`${environment.apiAuthUrl}/role/mydoc`);
  }

  RegisterPatient(data: any): Observable<IApiResponse<any>> {
    return this.http.post<IApiResponse<any>>(`${environment.apiAuthUrl}/auth/mydoc/register/patient`, data);
  }

  RegisterDoctor(data: any): Observable<IApiResponse<any>> {
    return this.http.post<IApiResponse<any>>(`${environment.apiAuthUrl}/auth/mydoc/register/doctor`, data);
  }

  // Métodos de autenticación
  logout(): void {
    localStorage.removeItem(this.TOKEN_KEY);
    localStorage.removeItem(this.USER_KEY);
    this.currentUserSubject.next(null);
    this.router.navigate(['/auth/login']);
  }

  isAuthenticated(): boolean {
    const token = this.getToken();
    if (!token) {
      return false;
    }

    const decodedToken = this.decodeToken(token);
    if (!decodedToken) {
      return false;
    }

    const currentTime = Math.floor(Date.now() / 1000);
    return decodedToken.exp > currentTime;
  }

  getToken(): string | null {
    return localStorage.getItem(this.TOKEN_KEY);
  }

  getCurrentUser(): User | null {
    return this.currentUserSubject.value;
  }

  private setToken(token: string): void {
    localStorage.setItem(this.TOKEN_KEY, token);
  }

  private setUser(user: User): void {
    localStorage.setItem(this.USER_KEY, JSON.stringify(user));
  }

  private getUserFromStorage(): User | null {
    const userJson = localStorage.getItem(this.USER_KEY);
    if (userJson) {
      try {
        return JSON.parse(userJson);
      } catch (e) {
        return null;
      }
    }
    return null;
  }

  private decodeToken(token: string): DecodedToken | null {
    try {
      const payload = token.split('.')[1];
      const decodedPayload = atob(payload);
      return JSON.parse(decodedPayload) as DecodedToken;
    } catch (e) {
      console.error('Error decodificando token:', e);
      return null;
    }
  }
}
