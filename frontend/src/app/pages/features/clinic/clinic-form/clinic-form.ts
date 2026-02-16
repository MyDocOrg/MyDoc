import { Component, inject, signal, Inject } from '@angular/core';
import { Field, form } from '@angular/forms/signals';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../../../../material.module';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ClinicService } from '../services/clinic-service';

export interface ClinicDialogData {
    clinicId?: number;
}

@Component({
    selector: 'app-clinic-form',
    imports: [CommonModule, Field, MaterialModule],
    templateUrl: './clinic-form.html',
    styleUrl: './clinic-form.scss',
})
export class ClinicForm {
    private dialogRef = inject(MatDialogRef<ClinicForm>);
    private service = inject(ClinicService);

    // Form state
    id = signal<number>(0);
    isEditMode = signal<boolean>(false);
    isLoading = signal<boolean>(false);

    // Form model
    clinicModel = signal({
        id: 0,
        name: '',
        address: '',
        phone: '',
        email: '',
        isActive: true,
    });

    clinicForm = form(this.clinicModel);

    constructor(@Inject(MAT_DIALOG_DATA) public data: ClinicDialogData) {
        if (data?.clinicId) {
            this.id.set(data.clinicId);
            this.isEditMode.set(true);
        }
    }

    ngOnInit(): void {
        if (this.isEditMode()) {
            this.loadClinic();
        }
    }

    /**
     * Load clinic data for editing
     */
    private loadClinic(): void {
        this.isLoading.set(true);
        this.service.GetById(this.id()).subscribe({
            next: (data) => {
                this.clinicModel.update(current => ({
                    ...current,
                    id: data.id,
                    name: data.name,
                    address: data.address,
                    phone: data.phone,
                    email: data.email,
                    isActive: data.isActive,
                }));
                this.isLoading.set(false);
            },
            error: (error) => {
                console.error('Error loading clinic:', error);
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

        const formData = this.clinicModel();
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
                console.error('Error saving clinic:', error);
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
