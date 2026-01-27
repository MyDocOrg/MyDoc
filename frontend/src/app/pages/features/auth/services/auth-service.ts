import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IApiResponse } from '../../../../shared/Interfaces/IApiResponse';
import { environment } from '../../../../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  http = inject(HttpClient);

  RegisterPatient(data : any) : Observable<IApiResponse<any>> { return this.http.post<IApiResponse<any>>(`${environment.apiUrl}auth/register/patient`, data);  }
  RegisterDoctor(data : any) : Observable<IApiResponse<any>> { return this.http.post<IApiResponse<any>>(`${environment.apiUrl}auth/register/doctor`, data);  }
}
