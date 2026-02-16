import { inject, Injectable } from '@angular/core';
import { environment } from '../../../../../environments/environment';
import { IApiResponse } from '../../../../shared/Interfaces/IApiResponse';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root',
})
export class ConsultationService {
    http = inject(HttpClient);

    GetAll(): Observable<IApiResponse<any[]>> { return this.http.get<IApiResponse<any[]>>(`${environment.apiMyDocUrl}consultation`); }
    Add(data: any): Observable<IApiResponse<any[]>> { return this.http.post<IApiResponse<any[]>>(`${environment.apiMyDocUrl}consultation`, data); }
    Edit(data: any): Observable<IApiResponse<any[]>> { return this.http.put<IApiResponse<any[]>>(`${environment.apiMyDocUrl}consultation/${data.id}`, data); }
    Delete(id: number): Observable<IApiResponse<any[]>> { return this.http.delete<IApiResponse<any[]>>(`${environment.apiMyDocUrl}consultation/${id}`); }
    GetById(id: number): Observable<any> { return this.http.get<IApiResponse<any>>(`${environment.apiMyDocUrl}consultation/${id}`).pipe(map(res => res.data)); }
}
