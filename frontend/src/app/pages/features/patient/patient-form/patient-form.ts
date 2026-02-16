import { Component, inject, signal, Inject } from '@angular/core';
import { Field, form } from '@angular/forms/signals';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../../../../material.module';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PatientService } from '../services/patient-service';

export interface PatientDialogData {
    patientId?: number;
}

@Component({
    selector: 'app-patient-form',
    imports: [CommonModule, Field, MaterialModule],
    templateUrl: './patient-form.html',
    styleUrl: './patient-form.scss',
})
export class PatientForm {
    private dialogRef = inject(MatDialogRef<PatientForm>);
    private service = inject(PatientService);

    // Form state
    id = signal<number>(0);
    isEditMode = signal<boolean>(false);
    isLoading = signal<boolean>(false);

    // Form model
    patientModel = signal({
        id: 0,
        userId: null,
        fullName: '',
        birthDate: '',
        gender: '',
        phone: '',
        email: '',
        address: '',
        isActive: true,
        createdAt: null,
        updatedAt: null,
    });

    patientForm = form(this.patientModel);

    constructor(@Inject(MAT_DIALOG_DATA) public data: PatientDialogData) {
        if (data?.patientId) {
            this.id.set(data.patientId);
            this.isEditMode.set(true);
        }
    }

    ngOnInit(): void {
        if (this.isEditMode()) {
            this.loadPatient();
        }
    }

    /**
     * Load patient data for editing
     */
    private loadPatient(): void {
        this.isLoading.set(true);
        this.service.GetById(this.id()).subscribe({
            next: (data) => {
                this.patientModel.update(current => ({
                    ...current,
                    id: data.id,
                    userId: data.userId,
                    fullName: data.fullName,
                    birthDate: data.birthDate,
                    gender: data.gender,
                    phone: data.phone,
                    email: data.email,
                    address: data.address,
                    isActive: data.isActive,
                    createdAt: data.createdAt,
                    updatedAt: data.updatedAt
                }));
                this.isLoading.set(false);
            },
            error: (error) => {
                console.error('Error loading patient:', error);
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

        const formData = this.patientModel();
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
                console.error('Error saving patient:', error);
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
