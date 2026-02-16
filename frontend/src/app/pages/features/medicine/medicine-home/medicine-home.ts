import { Component, inject, signal, ViewChild } from '@angular/core';
import { MedicineService } from '../services/medicine.service';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MaterialModule } from '../../../../material.module';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MedicineForm } from '../medicine-form/medicine-form';

@Component({
  selector: 'app-medicine-home',
  imports: [MaterialModule, CommonModule, FormsModule],
  templateUrl: './medicine-home.html',
  styleUrl: './medicine-home.scss',
})
export class MedicineHome {
  private service = inject(MedicineService);
  private dialog = inject(MatDialog);

  // Table configuration
  displayedColumns: string[] = ['name', 'description', 'presentation', 'isActive', 'actions'];
  dataSource = new MatTableDataSource<any>([]);
  searchText = '';
  loading = signal<boolean>(false);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngOnInit(): void {
    this.loadMedicines();
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  /**
   * Load all medicines from the service
   */
  loadMedicines(): void {
    this.loading.set(true);
    this.service.GetAll().subscribe({
      next: (res) => {
        this.dataSource.data = res.data || res;
        this.loading.set(false);
      },
      error: (error) => {
        console.error('Error al obtener medicamentos:', error);
        this.loading.set(false);
      },
    });
  }

  /**
   * Open dialog to create a new medicine
   */
  openCreateDialog(): void {
    const dialogRef = this.dialog.open(MedicineForm, {
      width: '600px',
      disableClose: true,
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadMedicines(); // Reload the list if changes were made
      }
    });
  }

  /**
   * Open dialog to edit an existing medicine
   */
  editMedicine(id: number): void {
    const dialogRef = this.dialog.open(MedicineForm, {
      width: '600px',
      disableClose: true,
      data: { medicineId: id }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadMedicines(); // Reload the list if changes were made
      }
    });
  }

  /**
   * Delete a medicine
   */
  deleteMedicine(id: number): void {
    if (confirm('¿Está seguro de que desea eliminar este medicamento?')) {
      this.service.Delete(id).subscribe({
        next: () => {
          this.loadMedicines();
        },
        error: (error) => {
          console.error('Error al eliminar medicamento:', error);
        },
      });
    }
  }

  /**
   * View medicine details (placeholder)
   */
  viewMedicine(id: number): void {
    // TODO: Implementar vista de detalles
    console.log('View medicine:', id);
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