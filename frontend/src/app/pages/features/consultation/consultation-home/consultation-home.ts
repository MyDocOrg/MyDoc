import { Component, inject, signal, ViewChild } from '@angular/core';
import { ConsultationService } from '../services/consultation.service';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MaterialModule } from '../../../../material.module';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ConsultationForm } from '../consultation-form/consultation-form';

@Component({
  selector: 'app-consultation-home',
  imports: [MaterialModule, CommonModule, FormsModule],
  templateUrl: './consultation-home.html',
  styleUrl: './consultation-home.scss',
})
export class ConsultationHome {
  private service = inject(ConsultationService);
  private dialog = inject(MatDialog);

  // Table configuration
  displayedColumns: string[] = ['appointmentId', 'reason', 'diagnosis', 'consultationDate', 'weightKg', 'heightCm', 'actions'];
  dataSource = new MatTableDataSource<any>([]);
  searchText = '';
  loading = signal<boolean>(false);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngOnInit(): void {
    this.loadConsultations();
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  /**
   * Load all consultations from the service
   */
  loadConsultations(): void {
    this.loading.set(true);
    this.service.GetAll().subscribe({
      next: (res) => {
        this.dataSource.data = res.data || res;
        this.loading.set(false);
      },
      error: (error) => {
        console.error('Error al obtener consultas:', error);
        this.loading.set(false);
      },
    });
  }

  /**
   * Open dialog to create a new consultation
   */
  openCreateDialog(): void {
    const dialogRef = this.dialog.open(ConsultationForm, {
      width: '600px',
      disableClose: true,
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadConsultations();
      }
    });
  }

  /**
   * Open dialog to edit an existing consultation
   */
  editConsultation(id: number): void {
    const dialogRef = this.dialog.open(ConsultationForm, {
      width: '600px',
      disableClose: true,
      data: { consultationId: id }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadConsultations();
      }
    });
  }

  /**
   * Delete a consultation
   */
  deleteConsultation(id: number): void {
    if (confirm('¿Está seguro de que desea eliminar esta consulta?')) {
      this.service.Delete(id).subscribe({
        next: () => {
          this.loadConsultations();
        },
        error: (error) => {
          console.error('Error al eliminar consulta:', error);
        },
      });
    }
  }

  /**
   * View consultation details (placeholder)
   */
  viewConsultation(id: number): void {
    // TODO: Implementar vista de detalles
    console.log('View consultation:', id);
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
