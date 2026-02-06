import { Component, inject, signal, Inject } from '@angular/core';
import { Field, form } from '@angular/forms/signals';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../../../../material.module';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AppointmentService } from '../services/appointment-service';
import { toSignal } from '@angular/core/rxjs-interop';

export interface AppointmentDialogData {
    appointmentId?: number;
}

@Component({
    selector: 'app-appointment-form',
    imports: [CommonModule, Field, MaterialModule],
    templateUrl: './appointment-form.html',
    styleUrl: './appointment-form.scss',
})
export class AppointmentForm {
    private dialogRef = inject(MatDialogRef<AppointmentForm>);
    private service = inject(AppointmentService);

    // Signals for dropdown data
    doctors = toSignal(this.service.GetAllDoctors(), { initialValue: [] as any[] });
    clinics = toSignal(this.service.GetAllClinics(), { initialValue: [] as any[] });
    statuses = toSignal(this.service.GetAllAppointmentStatuses(), { initialValue: [] as any[] });

    // Form state
    id = signal<number>(0);
    isEditMode = signal<boolean>(false);
    isLoading = signal<boolean>(false);

    // Form model
    appointmentModel = signal({
        id: 0,
        doctorId: '',
        clinicId: '',
        statusId: '',
        appointmentDate: ''
    });

    appointmentForm = form(this.appointmentModel);

    constructor(@Inject(MAT_DIALOG_DATA) public data: AppointmentDialogData) {
        if (data?.appointmentId) {
            this.id.set(data.appointmentId);
            this.isEditMode.set(true);
        }
    }

    ngOnInit(): void {
        if (this.isEditMode()) {
            this.loadAppointment();
        }
    }

    /**
     * Load appointment data for editing
     */
    private loadAppointment(): void {
        this.isLoading.set(true);
        this.service.GetById(this.id()).subscribe({
            next: (data) => {
                this.appointmentModel.update(current => ({
                    ...current,
                    id: data.id,
                    doctorId: data.doctor_id,
                    clinicId: data.clinic_id,
                    statusId: data.status_id,
                    appointmentDate: data.appointment_date
                }));
                this.isLoading.set(false);
            },
            error: (error) => {
                console.error('Error loading appointment:', error);
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

        const formData = this.appointmentModel();
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
                console.error('Error saving appointment:', error);
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
