import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

export interface Note {
  id?: string;
  title: string;
  content: string;
  createdAt: Date;
  updatedAt: Date;
  isCompleted: boolean;
  dueDate?: string; // formato YYYY-MM-DD
  dueTime?: string; // formato HH:mm
}

@Injectable({
  providedIn: 'root'
})
export class NotesDbService {
  private dbName = 'DoctorNotesDB';
  private storeName = 'notes';
  private db: IDBDatabase | null = null;
  private notes = new BehaviorSubject<Note[]>([]);

  constructor() {
    this.initDB();
  }

  /**
   * Inicializa la base de datos IndexedDB
   */
  private initDB(): void {
    const request = indexedDB.open(this.dbName, 1);

    request.onerror = () => {
      console.error('Error opening IndexedDB:', request.error);
    };

    request.onsuccess = () => {
      this.db = request.result;
      this.loadAllNotes();
    };

    request.onupgradeneeded = (event: any) => {
      const db = event.target.result;
      if (!db.objectStoreNames.contains(this.storeName)) {
        db.createObjectStore(this.storeName, { keyPath: 'id' });
      }
    };
  }

  /**
   * Carga todas las notas de la base de datos
   */
  private loadAllNotes(): void {
    if (!this.db) return;

    const transaction = this.db.transaction([this.storeName], 'readonly');
    const store = transaction.objectStore(this.storeName);
    const request = store.getAll();

    request.onsuccess = () => {
      const loadedNotes = request.result.sort(
        (a, b) => new Date(b.updatedAt).getTime() - new Date(a.updatedAt).getTime()
      );
      this.notes.next(loadedNotes);
    };
  }

  /**
   * Obtiene todas las notas como observable
   */
  getNotes$(): Observable<Note[]> {
    return this.notes.asObservable();
  }

  /**
   * Obtiene las notas actuales
   */
  getNotes(): Note[] {
    return this.notes.getValue();
  }

  /**
   * Añade una nueva nota
   */
  addNote(note: Omit<Note, 'id'>): void {
    if (!this.db) return;

    const newNote: Note = {
      ...note,
      id: this.generateId(),
    };

    const transaction = this.db.transaction([this.storeName], 'readwrite');
    const store = transaction.objectStore(this.storeName);
    const request = store.add(newNote);

    request.onsuccess = () => {
      this.loadAllNotes();
    };

    request.onerror = () => {
      console.error('Error adding note:', request.error);
    };
  }

  /**
   * Actualiza una nota existente
   */
  updateNote(note: Note): void {
    if (!this.db || !note.id) return;

    const updatedNote = {
      ...note,
      updatedAt: new Date(),
    };

    const transaction = this.db.transaction([this.storeName], 'readwrite');
    const store = transaction.objectStore(this.storeName);
    const request = store.put(updatedNote);

    request.onsuccess = () => {
      this.loadAllNotes();
    };

    request.onerror = () => {
      console.error('Error updating note:', request.error);
    };
  }

  /**
   * Elimina una nota
   */
  deleteNote(id: string): void {
    if (!this.db) return;

    const transaction = this.db.transaction([this.storeName], 'readwrite');
    const store = transaction.objectStore(this.storeName);
    const request = store.delete(id);

    request.onsuccess = () => {
      this.loadAllNotes();
    };

    request.onerror = () => {
      console.error('Error deleting note:', request.error);
    };
  }

  /**
   * Alterna el estado de completado de una nota
   */
  toggleNoteComplete(id: string): void {
    if (!this.db) return;

    const transaction = this.db.transaction([this.storeName], 'readonly');
    const store = transaction.objectStore(this.storeName);
    const request = store.get(id);

    request.onsuccess = () => {
      const note = request.result;
      if (note) {
        const updateTransaction = this.db!.transaction([this.storeName], 'readwrite');
        const updateStore = updateTransaction.objectStore(this.storeName);
        note.isCompleted = !note.isCompleted;
        note.updatedAt = new Date();
        updateStore.put(note);
        updateTransaction.oncomplete = () => {
          this.loadAllNotes();
        };
      }
    };
  }

  /**
   * Genera un ID único
   */
  private generateId(): string {
    return `${Date.now()}_${Math.random().toString(36).substr(2, 9)}`;
  }
}
