import { Component, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ThemeService } from '../../services/theme.service';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatDividerModule } from '@angular/material/divider';

interface Language {
  language: string;
  code: string;
  type: string;
  icon: string;
}

@Component({
  selector: 'app-topbar',
  imports: [CommonModule, MatButtonModule, MatIconModule, MatMenuModule, MatToolbarModule, MatTooltipModule, MatDividerModule],
  templateUrl: './topbar.html',
  styleUrl: './topbar.scss',
})
export class Topbar {
  themeService = inject(ThemeService);
  currentLanguage = signal<string>('es');
  
  public languages: Language[] = [
    {
      language: 'English',
      code: 'en',
      type: 'US',
      icon: 'assets/images/language/icon-flag-english.png',
    },
    {
      language: 'Español',
      code: 'es',
      type: 'ES',
      icon: 'assets/images/language/icon-flag-spanish.png',
    },
  ];
  
  get isDarkMode(): boolean {
    return this.themeService.isDarkMode();
  }

  get currentLanguageObj(): Language {
    return this.languages.find(lang => lang.code === this.currentLanguage()) || this.languages[1];
  }

  toggleTheme(): void {
    this.themeService.toggleTheme();
  }

  changeLanguage(lang: Language): void {
    this.currentLanguage.set(lang.code);
    // Funcionalidad de i18n suspendida temporalmente
  }
}
