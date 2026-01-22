import { Component, effect, input, output} from '@angular/core';
import { GenericTableService } from '../../services/generic-table-service';
import { TranslatePipe } from '@ngx-translate/core';

@Component({
  selector: 'app-generic-table',
  imports: [TranslatePipe],
  templateUrl: './generic-table.html',
  styleUrl: './generic-table.scss',
})
export class GenericTable {
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
