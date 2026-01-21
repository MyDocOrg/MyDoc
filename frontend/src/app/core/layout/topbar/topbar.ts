import { Component, inject } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { LanguageService } from '../../services/language.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-topbar',
  imports: [TranslateModule, CommonModule],
  templateUrl: './topbar.html',
  styleUrl: './topbar.scss',
})
export class Topbar {
  languageService = inject(LanguageService);
  
  get currentLanguage(): string {
    return this.languageService.getCurrentLanguage();
  }

  get availableLanguages() {
    return this.languageService.getAvailableLanguages();
  }

  changeLanguage(languageCode: string): void {
    this.languageService.changeLanguage(languageCode);
  }
}
