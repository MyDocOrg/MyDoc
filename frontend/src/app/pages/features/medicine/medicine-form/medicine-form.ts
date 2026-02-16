import { Component, inject, signal, Inject } from '@angular/core';
import { Field, form } from '@angular/forms/signals';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../../../../material.module';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MedicineService } from '../services/medicine.service';

export interface MedicineDialogData {
    medicineId?: number;
}

@Component({
    selector: 'app-medicine-form',
    imports: [CommonModule, Field, MaterialModule],
    templateUrl: './medicine-form.html',
    styleUrl: './medicine-form.scss',
})
export class MedicineForm {
    private dialogRef = inject(MatDialogRef<MedicineForm>);
    private service = inject(MedicineService);

    // Form state
    id = signal<number>(0);
    isEditMode = signal<boolean>(false);
    isLoading = signal<boolean>(false);

    // Form model
    medicineModel = signal({
        id: 0,
        name: '',
        description: '',
        presentation: '',
        isActive: true,
    });

    medicineForm = form(this.medicineModel);

    constructor(@Inject(MAT_DIALOG_DATA) public data: MedicineDialogData) {
        if (data?.medicineId) {
            this.id.set(data.medicineId);
            this.isEditMode.set(true);
        }
    }

    ngOnInit(): void {
        if (this.isEditMode()) {
            this.loadMedicine();
        }
    }

    /**
     * Load medicine data for editing
     */
    private loadMedicine(): void {
        this.isLoading.set(true);
        this.service.GetById(this.id()).subscribe({
            next: (data) => {
                this.medicineModel.update(current => ({
                    ...current,
                    id: data.id,
                    name: data.name,
                    description: data.description,
                    presentation: data.presentation,
                    isActive: data.isActive,
                }));
                this.isLoading.set(false);
            },
            error: (error) => {
                console.error('Error loading medicine:', error);
                this.isLoading.set(false);
                this.dialogRef.close(null);
            }
        });
    }

    /**
     * Handle form submission (create or update)
     */
    onSubmit(event: Event): void {
        event.preventDefault();

        const formData = this.medicineModel();
        this.isLoading.set(true);

        const request$ = this.isEditMode()
            ? this.service.Edit(formData)
            : this.service.Add(formData);

        request$.subscribe({
            next: (response) => {
                this.isLoading.set(false);
                this.dialogRef.close(response); // Close dialog and return response
            },
            error: (error) => {
                console.error('Error saving medicine:', error);
                this.isLoading.set(false);
            }
        });
    }

    /**
     * Cancel and close dialog
     */
    onCancel(): void {
        this.dialogRef.close(null);
    }
}
