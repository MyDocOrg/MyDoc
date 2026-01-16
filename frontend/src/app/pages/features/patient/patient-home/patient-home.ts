import { Component, inject, OnInit, signal } from '@angular/core';
import { PatientService } from '../services/patient-service';
import { toSignal } from '@angular/core/rxjs-interop';
import { PatientTable } from "../components/patient-table/patient-table";
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-patient-home',
  imports: [PatientTable, RouterLink],
  templateUrl: './patient-home.html',
  styleUrl: './patient-home.scss',
})
export class PatientHome implements OnInit {
  service = inject(PatientService);

  patientTable = signal<any[]>([]);
  loading = signal<boolean>(true);
  ngOnInit(): void {
    this.GetAll();
  }
  GetAll(){
    this.service.GetAll().subscribe({
      next:(res) => {
        this.loading.set(false);
        this.patientTable.set(res.data)
      },
      error:(res) => {
        this.loading.set(false);
        console.log(res.mensage)
      }
    })
  }
  edit(event : any){

  }
  deleteT(event : any){

  }
  view(event : any){

  }
}
