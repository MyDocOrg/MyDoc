import { Component, inject, signal, ViewChild, AfterViewInit } from '@angular/core';
import { AppointmentService } from '../services/appointment-service';
import { Router } from '@angular/router';
import { MaterialModule } from '../../../../material.module';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { AppointmentForm } from '../appointment-form/appointment-form';

@Component({
  selector: 'app-appointment-home',
  imports: [MaterialModule, CommonModule, FormsModule],
  templateUrl: './appointment-home.html',
  styleUrl: './appointment-home.scss',
})
export class AppointmentHome implements AfterViewInit {
  service = inject(AppointmentService);
  dialog = inject(MatDialog);
  router = inject(Router);

  dataSource = new MatTableDataSource<any>([]);
  displayedColumns: string[] = ['assigned', 'patient', 'date', 'actions'];
  loading = false;
  searchText = '';

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngOnInit(): void {
    this.GetAll();
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;

    // Configure custom filter predicate to search across multiple fields
    this.dataSource.filterPredicate = (data: any, filter: string) => {
      const searchStr = filter.toLowerCase();
      return data.doctorName?.toLowerCase().includes(searchStr) ||
        data.patientName?.toLowerCase().includes(searchStr) ||
        data.appointmentDate?.toLowerCase().includes(searchStr);
    };
  }

  GetAll(): void {
    this.loading = true;
    this.service.GetTable().subscribe({
      next: (res) => {
        this.loading = false;
        this.dataSource.data = res.data || res;
      },
      error: (error) => {
        this.loading = false;
        console.error('Error al obtener citas:', error);
      },
    });
  }

  /**
   * Apply filter to the table
   */
  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    // Reset to first page when filtering
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  /**
   * Clear search filter
   */
  clearSearch(): void {
    this.searchText = '';
    this.dataSource.filter = '';
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

