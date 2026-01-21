import { Component, inject } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { LanguageService } from '../../../core/services/language.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  imports: [TranslateModule, CommonModule],
  templateUrl: './home.html',
  styleUrl: './home.scss',
})
export class HomeComponent {
  languageService = inject(LanguageService);

  get currentLanguage(): string {
    return this.languageService.getCurrentLanguage();
  }
}
