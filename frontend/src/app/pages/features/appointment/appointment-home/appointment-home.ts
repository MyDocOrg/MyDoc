import { Component, inject, ViewChild, AfterViewInit } from '@angular/core';
import { AppointmentService } from '../services/appointment-service';
import { Router } from '@angular/router';
import { MaterialModule } from '../../../../material.module';
import { CommonModule, registerLocaleData } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { AppointmentForm } from '../appointment-form/appointment-form';
import { CalendarModule, CalendarEvent, CalendarView } from 'angular-calendar';
import { isSameDay, isSameMonth } from 'date-fns';
import localeEs from '@angular/common/locales/es';

registerLocaleData(localeEs);

@Component({
  selector: 'app-appointment-home',
  imports: [
    MaterialModule,
    CommonModule,
    FormsModule,
    CalendarModule
  ],
  templateUrl: './appointment-home.html',
  styleUrl: './appointment-home.scss',
})
export class AppointmentHome implements AfterViewInit {
  service = inject(AppointmentService);
  dialog = inject(MatDialog);
  router = inject(Router);

  // Calendar properties
  view: CalendarView = CalendarView.Month;
  CalendarView = CalendarView;
  viewDate: Date = new Date();
  events: CalendarEvent[] = [];
  activeDayIsOpen: boolean = false;

  loading = false;

  ngOnInit(): void {
    this.GetAll();
  }

  ngAfterViewInit(): void {
  }

  GetAll(): void {
    this.loading = true;
    this.service.GetTable().subscribe({
      next: (res) => {
        this.loading = false;
        const data = res.data || res;
        this.events = data.map((item: any) => ({
          start: new Date(item.appointmentDate),
          title: `Cita: ${item.patientName} con Dr. ${item.doctorName}`,
          color: {
            primary: '#3f51b5',
            secondary: '#e8eaf6',
          },
          meta: {
            appointment: item
          }
        }));
      },
      error: (error) => {
        this.loading = false;
        console.error('Error al obtener citas:', error);
      },
    });
  }

  dayClicked({ date, events }: { date: Date; events: CalendarEvent[] }): void {
    if (isSameMonth(date, this.viewDate)) {
      if (
        (isSameDay(this.viewDate, date) && this.activeDayIsOpen === true) ||
        events.length === 0
      ) {
        this.activeDayIsOpen = false;
      } else {
        this.activeDayIsOpen = true;
      }
      this.viewDate = date;
    }
  }

  handleEvent(action: string, event: CalendarEvent): void {
    const appointmentId = event.meta?.appointment?.id;
    if (appointmentId) {
      this.editAppointment(appointmentId);
    }
  }

  setView(view: CalendarView) {
    this.view = view;
  }

  closeOpenMonthViewDay() {
    this.activeDayIsOpen = false;
  }

  /**
   * Open dialog to create a new appointment
   */
  openCreateDialog(): void {
    const dialogRef = this.dialog.open(AppointmentForm, {
      width: '600px',
      disableClose: false,
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.GetAll(); // Refresh the list
      }
    });
  }

  /**
   * Open dialog to edit an appointment
   */
  editAppointment(id: number): void {
    const dialogRef = this.dialog.open(AppointmentForm, {
      width: '600px',
      disableClose: false,
      data: { appointmentId: id }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.GetAll(); // Refresh the list
      }
    });
  }

  deleteAppointment(event: any): void {
    this.service.Delete(event).subscribe({
      next: () => {
        this.GetAll();
      },
      error: (error) => {
        console.error('Error al eliminar cita:', error);
      },
    });
  }

  viewAppointment(event: any): void {
    // TODO: Implementar vista de detalles
  }
}

