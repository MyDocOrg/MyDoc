import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  http = inject(HttpClient);

  Login(data : any) : Observable<any> {return this.http.post('http://localhost:3000/api/auth/login', data);} 
}
