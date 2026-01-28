import { isPlatformBrowser } from '@angular/common';
import { Inject, Injectable, PLATFORM_ID } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TokenService {
  private readonly TOKEN_KEY = 'auth_token';
  private isBrowser: boolean;

  constructor(@Inject(PLATFORM_ID) platformId: Object) {
    this.isBrowser = isPlatformBrowser(platformId);
  }

  setToken(token: string): void {
    if (!this.isBrowser) return;
    localStorage.setItem(this.TOKEN_KEY,token);
  }

  getToken(): string | null {
    if (!this.isBrowser) return null;
    return localStorage.getItem(this.TOKEN_KEY);
  }
  getDecodedToken(): any | null {
    const token = this.getToken();
    if (!token) return null;

    return JSON.parse(atob(token.split('.')[1]));
  }

  getModules(): any {
    const decoded = this.getDecodedToken();
    if (!decoded?.modules) return {};

    return JSON.parse(decoded.modules);
  }

  removeToken(): void {
    console.log("this.isBrowser: ",this.isBrowser);
    if (!this.isBrowser) return;
    localStorage.removeItem(this.TOKEN_KEY);
  }

  hasToken(): boolean {
    if (!this.isBrowser) return false;
    return !!localStorage.getItem(this.TOKEN_KEY);
  }

  isLoggedIn(): boolean {
    const token = this.getToken();
    if (!token) return false;

    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      const exp = payload.exp * 1000;
      return Date.now() < exp;
    } catch {
      return false;
    }
  }  
}
