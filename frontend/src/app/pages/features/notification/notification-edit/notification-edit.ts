import { Component, inject } from '@angular/core';
import { NotificationForm } from "../components/notification-form/notification-form";
import { Router } from '@angular/router';
import { NotificationService } from '../services/notification-service';

@Component({
  selector: 'app-notification-edit',
  imports: [NotificationForm],
  templateUrl: './notification-edit.html',
  styleUrl: './notification-edit.scss',
})
export class NotificationEdit {
  service = inject(NotificationService)
  router = inject(Router)

  onEdit(request : any){
    this.service.Edit(request).subscribe({
      next:(res) => {
        this.router.navigate(['/notification'])
      },
      error:(res) => {
        console.log(res.mensage)
      }
    })
  }
}