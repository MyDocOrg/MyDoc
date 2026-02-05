import { Component, signal, inject } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ThemeService } from '../../services/theme.service';
import { LayoutService } from '../../services/layout.service';

@Component({
  selector: 'app-sidebar',
  imports: [RouterLink, RouterLinkActive, MatListModule, MatIconModule, MatButtonModule, MatTooltipModule],
  templateUrl: './sidebar.html',
})
export class Sidebar {
  private themeService = inject(ThemeService);
  private layoutService = inject(LayoutService);

  isCollapsed = this.layoutService.isSidebarCollapsed;
  currentTheme = this.themeService.currentTheme;

  toggleSidebar(): void {
    this.layoutService.toggleSidebar();
  }
}
