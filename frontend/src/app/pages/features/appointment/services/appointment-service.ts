import { inject, Injectable } from '@angular/core';
import { environment } from '../../../../../environments/environment';
import { IApiResponse } from '../../../../shared/Interfaces/IApiResponse';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/internal/operators/map';

@Injectable({
  providedIn: 'root',
})
export class AppointmentService {
   http = inject(HttpClient);

  GetAll() : Observable<IApiResponse<any[]>> { return this.http.get<IApiResponse<any[]>>(`${environment.apiMyDocUrl}appointment`); }
  GetTable() : Observable<IApiResponse<any[]>> { return this.http.get<IApiResponse<any[]>>(`${environment.apiMyDocUrl}appointment/table`); }
  GetById(id : number) : Observable<any> { return this.http.get<IApiResponse<any>>(`${environment.apiMyDocUrl}appointment/${id}`).pipe(map(res => res.data))}
  Add(data : any) : Observable<IApiResponse<any[]>> { return this.http.post<IApiResponse<any[]>>(`${environment.apiMyDocUrl}appointment`, data); }
  Edit(data : any) : Observable<IApiResponse<any[]>> { return this.http.put<IApiResponse<any[]>>(`${environment.apiMyDocUrl}appointment/${data.id}`, data); }
  Delete(id : number) : Observable<IApiResponse<any[]>> { return this.http.delete<IApiResponse<any[]>>(`${environment.apiMyDocUrl}appointment/${id}`); }

  GetAllDoctors() : Observable<any[]> { return this.http.get<IApiResponse<any[]>>(`${environment.apiMyDocUrl}doctor`).pipe(map(res => res.data)); }
  GetAllClinics() : Observable<any[]> { return this.http.get<IApiResponse<any[]>>(`${environment.apiMyDocUrl}clinic`).pipe(map(res => res.data)); }
  GetAllAppointmentStatuses() : Observable<any[]> { return this.http.get<IApiResponse<any[]>>(`${environment.apiMyDocUrl}appointmentstatus`).pipe(map(res => res.data)); }
}
