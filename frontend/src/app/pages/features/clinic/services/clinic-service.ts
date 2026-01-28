import { inject, Injectable } from '@angular/core';
import { environment } from '../../../../../environments/environment';
import { IApiResponse } from '../../../../shared/Interfaces/IApiResponse';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ClinicService {
   http = inject(HttpClient);

  GetAll() : Observable<IApiResponse<any[]>> { return this.http.get<IApiResponse<any[]>>(`${environment.apiMyDocUrl}/clinic`); }
  Add(data : any) : Observable<IApiResponse<any[]>> { return this.http.post<IApiResponse<any[]>>(`${environment.apiMyDocUrl}/clinic`, data); }
  Edit(data : any) : Observable<IApiResponse<any[]>> { return this.http.put<IApiResponse<any[]>>(`${environment.apiMyDocUrl}/clinic/${data.id}`, data); }
  Delete(id : number) : Observable<IApiResponse<any[]>> { return this.http.delete<IApiResponse<any[]>>(`${environment.apiMyDocUrl}/clinic/${id}`); }
}
