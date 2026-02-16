import { Component, inject, signal, Inject } from '@angular/core';
import { Field, form } from '@angular/forms/signals';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../../../../material.module';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PrescriptionService } from '../services/prescription.service';

export interface PrescriptionDialogData {
    prescriptionId?: number;
}

@Component({
    selector: 'app-prescription-form',
    imports: [CommonModule, Field, MaterialModule],
    templateUrl: './prescription-form.html',
    styleUrl: './prescription-form.scss',
})
export class PrescriptionForm {
    private dialogRef = inject(MatDialogRef<PrescriptionForm>);
    private service = inject(PrescriptionService);

    // Form state
    id = signal<number>(0);
    isEditMode = signal<boolean>(false);
    isLoading = signal<boolean>(false);

    // Form model
    prescriptionModel = signal({
        id: 0,
        generalInstructions: '',
        medicalHistoryId: 0,
        createdAt: null,
    });

    prescriptionForm = form(this.prescriptionModel);

    constructor(@Inject(MAT_DIALOG_DATA) public data: PrescriptionDialogData) {
        if (data?.prescriptionId) {
            this.id.set(data.prescriptionId);
            this.isEditMode.set(true);
        }
    }

    ngOnInit(): void {
        if (this.isEditMode()) {
            this.loadPrescription();
        }
    }

    /**
     * Load prescription data for editing
     */
    private loadPrescription(): void {
        this.isLoading.set(true);
        this.service.GetById(this.id()).subscribe({
            next: (data) => {
                this.prescriptionModel.update(current => ({
                    ...current,
                    id: data.id,
                    generalInstructions: data.generalInstructions,
                    medicalHistoryId: data.medicalHistoryId,
                    createdAt: data.createdAt,
                }));
                this.isLoading.set(false);
            },
            error: (error) => {
                console.error('Error loading prescription:', error);
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

        const formData = this.prescriptionModel();
        this.isLoading.set(true);

        const request$ = this.isEditMode()
            ? this.service.Edit(formData)
            : this.service.Add(formData);

        request$.subscribe({
            next: (response) => {
                this.isLoading.set(false);
                this.dialogRef.close(response);
            },
            error: (error) => {
                console.error('Error saving prescription:', error);
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
