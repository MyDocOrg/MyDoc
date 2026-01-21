import { Injectable, signal, PLATFORM_ID, inject } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class ThemeService {
  private readonly THEME_KEY = 'app_theme';
  currentTheme = signal<'light' | 'dark'>('light');
  private platformId = inject(PLATFORM_ID);
  private isBrowser: boolean;

  constructor() {
    this.isBrowser = isPlatformBrowser(this.platformId);
    this.loadTheme();
  }

  /**
   * Alterna entre tema claro y oscuro
   */
  toggleTheme(): void {
    const newTheme = this.currentTheme() === 'light' ? 'dark' : 'light';
    this.setTheme(newTheme);
  }

  /**
   * Establece un tema específico
   * @param theme El tema a aplicar ('light' o 'dark')
   */
  setTheme(theme: 'light' | 'dark'): void {
    this.currentTheme.set(theme);
    
    if (this.isBrowser) {
      localStorage.setItem(this.THEME_KEY, theme);
      document.body.setAttribute('data-theme', theme);
    }
  }

  /**
   * Obtiene el tema actual
   * @returns El tema actual ('light' o 'dark')
   */
  getTheme(): 'light' | 'dark' {
    return this.currentTheme();
  }

  /**
   * Verifica si el tema actual es oscuro
   * @returns true si el tema es oscuro
   */
  isDarkMode(): boolean {
    return this.currentTheme() === 'dark';
  }

  /**
   * Carga el tema guardado desde localStorage
   */
  private loadTheme(): void {
    if (!this.isBrowser) {
      // En el servidor, usar tema claro por defecto
      this.currentTheme.set('light');
      return;
    }

    const savedTheme = localStorage.getItem(this.THEME_KEY) as 'light' | 'dark';
    if (savedTheme && (savedTheme === 'light' || savedTheme === 'dark')) {
      this.setTheme(savedTheme);
    } else {
      // Detectar preferencia del sistema
      const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
      this.setTheme(prefersDark ? 'dark' : 'light');
    }
  }
}
