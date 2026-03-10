import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatCard, MatCardHeader, MatCardTitle, MatCardContent, MatCardActions } from "@angular/material/card";
import { MatButton } from "@angular/material/button";
import { MatIcon } from "@angular/material/icon";
import { MatFormField, MatLabel } from "@angular/material/form-field";
import { MatInput } from "@angular/material/input";
import { MatCheckbox } from "@angular/material/checkbox";
import { MatTooltip } from "@angular/material/tooltip";
import { NotesDbService, Note } from "../../../../core/services/notes-db.service";
import { ConnectionStatusService } from "../../../../core/services/connection-status.service";

@Component({
  // make this a standalone component so the router can instantiate it directly
  standalone: true,
  // give it a unique selector to avoid colliding with the regular home component
  selector: 'app-home-pwa',
  imports: [
    CommonModule,
    FormsModule,
    MatCard,
    MatCardHeader,
    MatCardTitle,
    MatCardContent,
    MatCardActions,
    MatButton,
    MatIcon,
    MatFormField,
    MatLabel,
    MatInput,
    MatCheckbox,
    MatTooltip
  ],
  templateUrl: './home.html',
  // the property is `styleUrls` (plural) not `styleUrl`
  styleUrls: ['./home.scss'],
})
export class HomePwa implements OnInit {
  private notesDbService = inject(NotesDbService);
  private connectionStatusService = inject(ConnectionStatusService);

  notes: Note[] = [];
  isOnline = this.connectionStatusService.isOnline;

  newNote = {
    title: '',
    content: '',
    dueDate: '',
    dueTime: '',
  };

  editingNote: Note | null = null;
  editingText = '';

  constructor() {}

  ngOnInit(): void {
    this.loadNotes();
    this.connectionStatusService.getConnectionStatus$().subscribe();
  }

  /**
   * Carga todas las notas
   */
  loadNotes(): void {
    this.notesDbService.getNotes$().subscribe(notes => {
      this.notes = notes;
    });
  }

  /**
   * Añade una nueva nota
   */
  addNote(): void {
    if (this.newNote.title.trim() || this.newNote.content.trim()) {
      const note: Omit<Note, 'id'> = {
        title: this.newNote.title || 'Sin título',
        content: this.newNote.content,
        createdAt: new Date(),
        updatedAt: new Date(),
        isCompleted: false,
        dueDate: this.newNote.dueDate || undefined,
        dueTime: this.newNote.dueTime || undefined,
      };

      this.notesDbService.addNote(note);
      this.newNote = { title: '', content: '', dueDate: '', dueTime: '' };
    }
  }

  /**
   * Inicia la edición de una nota
   */
  startEdit(note: Note): void {
    this.editingNote = note;
    this.editingText = note.content;
  }

  /**
   * Guarda la edición de una nota
   */
  saveEdit(): void {
    if (this.editingNote && this.editingText.trim()) {
      this.editingNote.content = this.editingText;
      this.editingNote.updatedAt = new Date();
      this.notesDbService.updateNote(this.editingNote);
      this.editingNote = null;
      this.editingText = '';
    }
  }

  /**
   * Cancela la edición
   */
  cancelEdit(): void {
    this.editingNote = null;
    this.editingText = '';
  }

  /**
   * Elimina una nota
   */
  deleteNote(id: string | undefined): void {
    if (id && confirm('¿Estás seguro que deseas eliminar esta nota?')) {
      this.notesDbService.deleteNote(id);
    }
  }

  /**
   * Alterna el estado de completado
   */
  toggleComplete(id: string | undefined): void {
    if (id) {
      this.notesDbService.toggleNoteComplete(id);
    }
  }

  /**
   * Formatea la fecha
   */
  formatDate(date: Date): string {
    const d = new Date(date);
    return d.toLocaleDateString('es-ES', {
      year: 'numeric',
      month: 'short',
      day: 'numeric',
      hour: '2-digit',
      minute: '2-digit',
    });
  }

  /**
   * Formatea la fecha y hora de vencimiento
   */
  formatDueDateTime(dueDate?: string, dueTime?: string): string {
    if (!dueDate) return '';
    
    const date = new Date(dueDate);
    const formattedDate = date.toLocaleDateString('es-ES', {
      year: 'numeric',
      month: 'short',
      day: 'numeric',
    });
    
    const time = dueTime ? ` a las ${dueTime}` : '';
    return formattedDate + time;
  }

  /**
   * Verifica si una nota está vencida
   */
  isOverdue(dueDate?: string, dueTime?: string): boolean {
    if (!dueDate) return false;
    
    const now = new Date();
    const dueDateTime = new Date(dueDate);
    
    if (dueTime) {
      const [hours, minutes] = dueTime.split(':');
      dueDateTime.setHours(parseInt(hours), parseInt(minutes), 0);
    } else {
      dueDateTime.setHours(23, 59, 59);
    }
    
    return now > dueDateTime;
  }

  /**
   * Obtiene las notas no completadas
   */
  get activeNotes(): Note[] {
    return this.notes.filter(n => !n.isCompleted);
  }

  /**
   * Obtiene las notas completadas
   */
  get completedNotes(): Note[] {
    return this.notes.filter(n => n.isCompleted);
  }
}
