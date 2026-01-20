import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { environment } from '../../../../../../environments/environment';
import { IApiResponse } from '../../../../../shared/Interfaces/IApiResponse';
import { Observable } from 'rxjs/internal/Observable';

@Component({
  selector: 'app-clinic-service',
  imports: [],
  templateUrl: './clinic-service.html',
  styleUrl: './clinic-service.scss',
})
export class ClinicService {
  http = inject(HttpClient);

  GetAll() : Observable<IApiResponse<any[]>> { return this.http.get<IApiResponse<any[]>>(`${environment.apiUrl}/clinic`); }
  Add(data : any) : Observable<IApiResponse<any[]>> { return this.http.post<IApiResponse<any[]>>(`${environment.apiUrl}/clinic`, data); }
  Edit(data : any) : Observable<IApiResponse<any[]>> { return this.http.put<IApiResponse<any[]>>(`${environment.apiUrl}/clinic/${data.id}`, data); }
  Delete(id : number) : Observable<IApiResponse<any[]>> { return this.http.delete<IApiResponse<any[]>>(`${environment.apiUrl}/clinic/${id}`); }
}
