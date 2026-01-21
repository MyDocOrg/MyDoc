import { Component, inject, signal, effect } from '@angular/core';
import { Router, RouterOutlet, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs';
import { Sidebar } from "./core/layout/sidebar/sidebar";
import { Topbar } from "./core/layout/topbar/topbar";
import { LanguageService } from './core/services/language.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Sidebar, Topbar],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('Polnito rico');
  router = inject(Router);
  languageService = inject(LanguageService);
  isShowLayout = signal(true);

  constructor() {
    // Inicializar el servicio de idiomas
    this.languageService;
    
    // Verificar la URL inicial
    this.updateLayoutVisibility(this.router.url);

    // Suscribirse a los eventos de navegación
    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe((event: NavigationEnd) => {
      this.updateLayoutVisibility(event.urlAfterRedirects);
    });
  }
  
  private updateLayoutVisibility(url: string) {
    const shouldShowLayout = url !== '/login' && url !== '/register';
    this.isShowLayout.set(shouldShowLayout);
  }
}
