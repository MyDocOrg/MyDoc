import { Component, inject, signal, ViewChild } from '@angular/core';
import { PrescriptionService } from '../services/prescription.service';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MaterialModule } from '../../../../material.module';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PrescriptionForm } from '../prescription-form/prescription-form';

@Component({
  selector: 'app-prescription-home',
  imports: [MaterialModule, CommonModule, FormsModule],
  templateUrl: './prescription-home.html',
  styleUrl: './prescription-home.scss',
})
export class PrescriptionHome {
  private service = inject(PrescriptionService);
  private dialog = inject(MatDialog);

  // Table configuration
  displayedColumns: string[] = ['medicalHistoryId', 'generalInstructions', 'createdAt', 'actions'];
  dataSource = new MatTableDataSource<any>([]);
  searchText = '';
  loading = signal<boolean>(false);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngOnInit(): void {
    this.loadPrescriptions();
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  /**
   * Load all prescriptions from the service
   */
  loadPrescriptions(): void {
    this.loading.set(true);
    this.service.GetAll().subscribe({
      next: (res) => {
        this.dataSource.data = res.data || res;
        this.loading.set(false);
      },
      error: (error) => {
        console.error('Error al obtener prescripciones:', error);
        this.loading.set(false);
      },
    });
  }

  /**
   * Open dialog to create a new prescription
   */
  openCreateDialog(): void {
    const dialogRef = this.dialog.open(PrescriptionForm, {
      width: '600px',
      disableClose: true,
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadPrescriptions();
      }
    });
  }

  /**
   * Open dialog to edit an existing prescription
   */
  editPrescription(id: number): void {
    const dialogRef = this.dialog.open(PrescriptionForm, {
      width: '600px',
      disableClose: true,
      data: { prescriptionId: id }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadPrescriptions();
      }
    });
  }

  /**
   * Delete a prescription
   */
  deletePrescription(id: number): void {
    if (confirm('¿Está seguro de que desea eliminar esta prescripción?')) {
      this.service.Delete(id).subscribe({
        next: () => {
          this.loadPrescriptions();
        },
        error: (error) => {
          console.error('Error al eliminar prescripción:', error);
        },
      });
    }
  }

  /**
   * View prescription details (placeholder)
   */
  viewPrescription(id: number): void {
    // TODO: Implementar vista de detalles
    console.log('View prescription:', id);
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