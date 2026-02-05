import { Component, Output, EventEmitter, Input, ViewEncapsulation, inject } from '@angular/core';
import { ThemeService } from '../../services/theme.service';
import { LanguageService } from '../../services/language.service';
import { LayoutService } from '../../services/layout.service';
import { RouterModule } from '@angular/router';

import { MaterialModule } from '../../../material.module';
import { MatBadgeModule } from '@angular/material/badge';

@Component({
  selector: 'app-topbar',
  standalone: true,
  imports: [
    RouterModule,
    MaterialModule,
    MatBadgeModule
  ],
  templateUrl: './topbar.html',
  encapsulation: ViewEncapsulation.None,
})
export class Topbar {
  @Input() showToggle = true;
  @Input() toggleChecked = false;
  @Output() toggleMobileNav = new EventEmitter<void>();

  private themeService = inject(ThemeService);
  private languageService = inject(LanguageService);
  private layoutService = inject(LayoutService);

  currentTheme = this.themeService.currentTheme;
  isCollapsed = this.layoutService.isSidebarCollapsed;

  toggleSidebar(): void {
    this.layoutService.toggleSidebar();
  }

  toggleTheme(): void {
    this.themeService.toggleTheme();
  }

  toggleLanguage(): void {
    const current = this.languageService.getCurrentLanguage();
    const next = current === 'es' ? 'en' : 'es';
    this.languageService.changeLanguage(next);
  }

  get currentLang() {
    return this.languageService.getCurrentLanguage();
  }
}

