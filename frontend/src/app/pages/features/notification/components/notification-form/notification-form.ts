import { Component, inject, output, signal } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Field, form } from '@angular/forms/signals';
import { CommonModule } from '@angular/common';
import { NotificationService } from '../../services/notification-service';

@Component({
  selector: 'app-notification-form',
  imports: [CommonModule],
  templateUrl: './notification-form.html',
  styleUrl: './notification-form.scss',
})
export class NotificationForm {
  router = inject(Router);
  route = inject(ActivatedRoute);
  service = inject(NotificationService);

  id = signal(0);
  submitNotification = output<any>();

  notificationModel = signal({
    id: 0,
    medicationScheduleId: 0,
    sentAt: null,
    isSent: false
  });

  notificationForm = form(this.notificationModel);

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.id.set(Number(idParam));
      this.GetById();
    }
  }

  onSubmit(event: Event): void {
    event.preventDefault();
    const formData = this.notificationModel();
    this.submitNotification.emit(formData);
  }

  GetById(){
    this.service.GetById(this.id()).subscribe({
      next: (res) => {
        this.notificationModel.update(c => ({
          ...c,
          id: res.id,
          medicationScheduleId: res.medicationScheduleId,
          sentAt: res.sentAt,
          isSent: res.isSent
        }));
      },
      error: console.error
    });
  }
} 
