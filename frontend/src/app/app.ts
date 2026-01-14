import { Component, inject, signal, computed } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { Sidebar } from "./core/layout/sidebar/sidebar";
import { Topbar } from "./core/layout/topbar/topbar";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Sidebar, Topbar],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('Polnito rico');
  router = inject(Router);

  isShowLayout = computed(() => {
    return this.router.url !== '/login' && this.router.url !== '/register';
  })
}
