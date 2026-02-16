import { Component, inject, signal, Inject } from '@angular/core';
import { Field, form } from '@angular/forms/signals';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../../../../material.module';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ConsultationService } from '../services/consultation.service';

export interface ConsultationDialogData {
    consultationId?: number;
}

@Component({
    selector: 'app-consultation-form',
    imports: [CommonModule, Field, MaterialModule],
    templateUrl: './consultation-form.html',
    styleUrl: './consultation-form.scss',
})
export class ConsultationForm {
    private dialogRef = inject(MatDialogRef<ConsultationForm>);
    private service = inject(ConsultationService);

    // Form state
    id = signal<number>(0);
    isEditMode = signal<boolean>(false);
    isLoading = signal<boolean>(false);

    // Form model
    consultationModel = signal({
        id: 0,
        appointmentId: 0,
        reason: '',
        diagnosis: '',
        consultationDate: '',
        weightKg: '',
        heightCm: '',
    });

    consultationForm = form(this.consultationModel);

    constructor(@Inject(MAT_DIALOG_DATA) public data: ConsultationDialogData) {
        if (data?.consultationId) {
            this.id.set(data.consultationId);
            this.isEditMode.set(true);
        }
    }

    ngOnInit(): void {
        if (this.isEditMode()) {
            this.loadConsultation();
        }
    }

    /**
     * Load consultation data for editing
     */
    private loadConsultation(): void {
        this.isLoading.set(true);
        this.service.GetById(this.id()).subscribe({
            next: (data) => {
                this.consultationModel.update(current => ({
                    ...current,
                    id: data.id,
                    appointmentId: data.appointmentId,
                    reason: data.reason,
                    diagnosis: data.diagnosis,
                    consultationDate: data.consultationDate,
                    weightKg: data.weightKg,
                    heightCm: data.heightCm,
                }));
                this.isLoading.set(false);
            },
            error: (error) => {
                console.error('Error loading consultation:', error);
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

        const formData = this.consultationModel();
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
                console.error('Error saving consultation:', error);
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
