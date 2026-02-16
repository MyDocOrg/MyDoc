import { Component, inject, signal, ViewChild } from '@angular/core';
import { PatientService } from '../services/patient-service';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MaterialModule } from '../../../../material.module';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PatientForm } from '../patient-form/patient-form';

@Component({
  selector: 'app-patient-home',
  imports: [MaterialModule, CommonModule, FormsModule],
  templateUrl: './patient-home.html',
  styleUrl: './patient-home.scss',
})
export class PatientHome {
  private service = inject(PatientService);
  private dialog = inject(MatDialog);

  // Table configuration
  displayedColumns: string[] = ['fullName', 'birthDate', 'gender', 'phone', 'email', 'isActive', 'actions'];
  dataSource = new MatTableDataSource<any>([]);
  searchText = '';
  loading = signal<boolean>(false);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngOnInit(): void {
    this.loadPatients();
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  /**
   * Load all patients from the service
   */
  loadPatients(): void {
    this.loading.set(true);
    this.service.GetAll().subscribe({
      next: (res) => {
        this.dataSource.data = res.data || res;
        this.loading.set(false);
      },
      error: (error) => {
        console.error('Error al obtener pacientes:', error);
        this.loading.set(false);
      },
    });
  }

  /**
   * Open dialog to create a new patient
   */
  openCreateDialog(): void {
    const dialogRef = this.dialog.open(PatientForm, {
      width: '600px',
      disableClose: true,
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadPatients(); // Reload the list if changes were made
      }
    });
  }

  /**
   * Open dialog to edit an existing patient
   */
  editPatient(id: number): void {
    const dialogRef = this.dialog.open(PatientForm, {
      width: '600px',
      disableClose: true,
      data: { patientId: id }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadPatients(); // Reload the list if changes were made
      }
    });
  }

  /**
   * Delete a patient
   */
  deletePatient(id: number): void {
    if (confirm('¿Está seguro de que desea eliminar este paciente?')) {
      this.service.Delete(id).subscribe({
        next: () => {
          this.loadPatients();
        },
        error: (error) => {
          console.error('Error al eliminar paciente:', error);
        },
      });
    }
  }

  /**
   * View patient details (placeholder)
   */
  viewPatient(id: number): void {
    // TODO: Implementar vista de detalles
    console.log('View patient:', id);
  }

  /**
   * Apply search filter to the table
   */
  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

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
}
