import { Injectable, PLATFORM_ID, inject } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root'
})
export class LanguageService {
  private currentLanguage: string = 'es';
  private readonly STORAGE_KEY = 'selectedLanguage';
  private platformId = inject(PLATFORM_ID);
  private isBrowser: boolean;

  constructor(private translate: TranslateService) {
    this.isBrowser = isPlatformBrowser(this.platformId);
    // Solo inicializar en el navegador
    if (this.isBrowser) {
      setTimeout(() => this.initializeLanguage(), 0);
    } else {
      this.translate.setDefaultLang('es');
    }
  }

  /**
   * Inicializa el idioma de la aplicación
   * Primero verifica si hay un idioma guardado en localStorage
   * Si no, usa el idioma por defecto (español)
   */
  private initializeLanguage(): void {
    const savedLanguage = localStorage.getItem(this.STORAGE_KEY);
    const languageToUse = savedLanguage || 'es';
    
    this.translate.setDefaultLang('es');
    this.translate.use(languageToUse);
    this.currentLanguage = languageToUse;
  }

  /**
   * Cambia el idioma de la aplicación
   * @param language Código del idioma (es, en)
   */
  changeLanguage(language: string): void {
    if (language !== this.currentLanguage) {
      this.translate.use(language);
      this.currentLanguage = language;
      
      if (this.isBrowser) {
        localStorage.setItem(this.STORAGE_KEY, language);
      }
    }
  }

  /**
   * Obtiene el idioma actual
   * @returns Código del idioma actual
   */
  getCurrentLanguage(): string {
    return this.currentLanguage;
  }

  /**
   * Obtiene la traducción de una clave
   * @param key Clave de traducción
   * @param params Parámetros opcionales para interpolación
   * @returns Observable con la traducción
   */
  getTranslation(key: string, params?: any) {
    return this.translate.get(key, params);
  }

  /**
   * Obtiene la traducción instantánea de una clave
   * @param key Clave de traducción
   * @param params Parámetros opcionales para interpolación
   * @returns String con la traducción
   */
  getInstantTranslation(key: string, params?: any): string {
    return this.translate.instant(key, params);
  }

  /**
   * Obtiene todos los idiomas disponibles
   * @returns Array con los códigos de idiomas disponibles
   */
  getAvailableLanguages(): { code: string; name: string }[] {
    return [
      { code: 'es', name: 'Español' },
      { code: 'en', name: 'English' }
    ];
  }
}
