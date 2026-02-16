import { Component, inject, signal, ViewChild } from '@angular/core';
import { ClinicService } from '../services/clinic-service';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MaterialModule } from '../../../../material.module';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ClinicForm } from '../clinic-form/clinic-form';

@Component({
  selector: 'app-clinic-home',
  imports: [MaterialModule, CommonModule, FormsModule],
  templateUrl: './clinic-home.html',
  styleUrl: './clinic-home.scss',
})
export class ClinicHome {
  private service = inject(ClinicService);
  private dialog = inject(MatDialog);

  // Table configuration
  displayedColumns: string[] = ['name', 'address', 'phone', 'email', 'isActive', 'actions'];
  dataSource = new MatTableDataSource<any>([]);
  searchText = '';
  loading = signal<boolean>(false);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngOnInit(): void {
    this.loadClinics();
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  /**
   * Load all clinics from the service
   */
  loadClinics(): void {
    this.service.GetAll().subscribe({
      next: (res) => {
        this.dataSource.data = res.data || res;
      },
      error: (error) => {
        console.error('Error al obtener clínicas:', error);
      },
    });
  }

  /**
   * Open dialog to create a new clinic
   */
  openCreateDialog(): void {
    const dialogRef = this.dialog.open(ClinicForm, {
      width: '600px',
      disableClose: true,
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadClinics(); // Reload the list if changes were made
      }
    });
  }

  /**
   * Open dialog to edit an existing clinic
   */
  editClinic(id: number): void {
    const dialogRef = this.dialog.open(ClinicForm, {
      width: '600px',
      disableClose: true,
      data: { clinicId: id }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadClinics(); // Reload the list if changes were made
      }
    });
  }

  /**
   * Delete a clinic
   */
  deleteClinic(id: number): void {
    if (confirm('¿Está seguro de que desea eliminar esta clínica?')) {
      this.service.Delete(id).subscribe({
        next: () => {
          this.loadClinics();
        },
        error: (error) => {
          console.error('Error al eliminar clínica:', error);
        },
      });
    }
  }

  /**
   * View clinic details (placeholder)
   */
  viewClinic(id: number): void {
    // TODO: Implementar vista de detalles
    console.log('View clinic:', id);
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
