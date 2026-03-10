import { Injectable, signal } from '@angular/core';
import { Observable, fromEvent, merge, of } from 'rxjs';
import { map, startWith, debounceTime } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ConnectionStatusService {
  isOnline = signal(navigator.onLine);

  constructor() {
    this.initializeConnectionMonitoring();
  }

  /**
   * Inicializa el monitoreo de conexión
   */
  private initializeConnectionMonitoring(): void {
    merge(
      of(navigator.onLine),
      fromEvent(window, 'online').pipe(map(() => true)),
      fromEvent(window, 'offline').pipe(map(() => false))
    )
      .pipe(debounceTime(100))
      .subscribe(status => {
        this.isOnline.set(status);
      });
  }

  /**
   * Obtiene el estado actual de conexión
   */
  getIsOnline(): boolean {
    return this.isOnline();
  }

  /**
   * Observable del estado de conexión
   */
  getConnectionStatus$(): Observable<boolean> {
    return new Observable(observer => {
      observer.next(this.isOnline());
      const unsub1 = fromEvent(window, 'online').subscribe(() => {
        this.isOnline.set(true);
        observer.next(true);
      });
      const unsub2 = fromEvent(window, 'offline').subscribe(() => {
        this.isOnline.set(false);
        observer.next(false);
      });
      return () => {
        unsub1.unsubscribe();
        unsub2.unsubscribe();
      };
    });
  }
}
