import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IApiResponse } from '../../../../shared/Interfaces/IApiResponse';
import { environment } from '../../../../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  http = inject(HttpClient);

  Login(data: any): Observable<IApiResponse<any>> { const headers = new HttpHeaders({ 'X-Application-Name': 'MyDoc' }); return this.http.post<IApiResponse<any>>(`${environment.apiAuthUrl}auth/login`, data, { headers });  }
  GetSuscriptionsMyDoc(): Observable<IApiResponse<any[]>> {return this.http.get<IApiResponse<any[]>>(`${environment.apiAuthUrl}suscription/mydoc`);  }
  GetRolesMyDoc(): Observable<IApiResponse<any[]>> {return this.http.get<IApiResponse<any[]>>(`${environment.apiAuthUrl}role/mydoc`);  }
  RegisterPatient(data : any) : Observable<IApiResponse<any>> { return this.http.post<IApiResponse<any>>(`${environment.apiAuthUrl}auth/mydoc/register/patient`, data);  }
  RegisterDoctor(data : any) : Observable<IApiResponse<any>> { return this.http.post<IApiResponse<any>>(`${environment.apiAuthUrl}auth/mydoc/register/doctor`, data);  }
}
