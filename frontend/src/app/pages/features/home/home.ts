import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCard, MatCardHeader, MatCardTitle, MatCardContent, MatCardActions } from "@angular/material/card";
import { MatIcon } from "@angular/material/icon";
import { MatToolbar } from "@angular/material/toolbar";
import { RouterLink } from "@angular/router";

@Component({
  selector: 'app-home',
  imports: [CommonModule, MatCard, MatCardHeader, MatIcon, MatCardTitle, MatCardContent, MatCardActions, MatToolbar, RouterLink],
  templateUrl: './home.html',
  styleUrl: './home.scss',
})
export class HomeComponent {
  features = [
    { 
      title: 'Expediente Único', 
      description: 'Accede a la historia clínica completa de tus pacientes en segundos.',
      icon: 'assignment_ind'
    },
    { 
      title: 'Agenda Médica', 
      description: 'Control de citas sincronizado con recordatorios automáticos.',
      icon: 'event_available'
    },
    { 
      title: 'Receta Electrónica', 
      description: 'Genera recetas profesionales y envíalas directamente por email.',
      icon: 'medication'
    }
  ];
}
