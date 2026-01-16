import { Component, computed, effect, inject, input, output } from '@angular/core';
import { GenericTableService } from '../../../../../shared/services/generic-table-service';

@Component({
  selector: 'app-patient-table',
  imports: [],
  templateUrl: './patient-table.html',
  styleUrl: './patient-table.scss',
})
export class PatientTable {
  tableData = input.required<any[]>();
  columsData = input.required<string[]>();
  headersTable = input.required<string[]>();
  loading = input<boolean>(false);

  edit = output<string | number>();
  delete = output<string | number>();
  detail = output<string | number>();

  constructor(public tableState: GenericTableService) {
    effect(() => {
      this.tableState.setData(
        this.tableData(),
        this.columsData()
      );
    });
  }
  ngOnDestroy() {
    this.tableState.resetState();
  }

  onEdit(id: string | number) {
    this.edit.emit(id);
  }

  onDelete(id: string | number) {
    this.delete.emit(id);
  }

  onDetail(id: string | number) {
    this.detail.emit(id);
  }
}
