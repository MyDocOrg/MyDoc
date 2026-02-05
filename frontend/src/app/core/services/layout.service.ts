import { Injectable, signal } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class LayoutService {
    isSidebarCollapsed = signal(false);

    toggleSidebar(): void {
        this.isSidebarCollapsed.update(value => !value);
    }
}
