import { computed, Injectable, signal } from '@angular/core';
import { IDictionary } from '../Interfaces/IDictionary';

@Injectable({
  providedIn: 'root',
})
export class GenericTableService<T = any> {
  /* INPUTS */
  tableData = signal<T[]>([]);
  columnsData = signal<string[]>([]);

  /* CONFIG */
  pageSizeOptions = signal<number[]>([5, 10, 25, 50]);
  pageSize = signal<number>(10);

  /* STATE */
  search = signal('');
  page = signal(1);
  searchByField = signal<IDictionary<any>>({});

  /* COMPUTED */
  filteredData = computed(() => {
    let data = this.tableData();

    /* SEARCH GLOBAL */
    const q = this.search().toLowerCase();
    if (q) {
      data = data.filter(row =>
        this.columnsData().some(col =>
          String((row as any)[col] ?? '')
            .toLowerCase()
            .includes(q)
        )
      );
    }

    /* SEARCH BY FIELD */
    const filters = this.searchByField();

    Object.entries(filters).forEach(([field, value]) => {
      if (!value) return;

      // FECHAS (from / to)
      if (field.endsWith('From')) {
        const realField = field.replace('From', '');
        const from = new Date(value).setHours(0, 0, 0, 0);

        data = data.filter(row =>
          new Date((row as any)[realField]).getTime() >= from
        );
        return;
      }

      if (field.endsWith('To')) {
        const realField = field.replace('To', '');
        const to = new Date(value).setHours(23, 59, 59, 999);

        data = data.filter(row =>
          new Date((row as any)[realField]).getTime() <= to
        );
        return;
      }

      // TEXTO / SELECT / NUMBER
      data = data.filter(row =>
        String((row as any)[field] ?? '')
          .toLowerCase()
          .includes(String(value).toLowerCase())
      );
    });

    return data;
  });

  onSearchByField(field: string, value: any) {
    const current = { ...this.searchByField() };

    if (value === null || value === '' || value === undefined) {
      delete current[field];
    } else {
      current[field] = value;
    }

    this.searchByField.set(current);
    this.page.set(1);
  }

  clearField(field: string) {
    const current = { ...this.searchByField() };
    delete current[field];
    this.searchByField.set(current);
  }

  totalPages = computed(() =>
    Math.ceil(this.filteredData().length / this.pageSize())
  );

  paginatedData = computed(() => {
    const start = (this.page() - 1) * this.pageSize();
    return this.filteredData().slice(start, start + this.pageSize());
  });

  /* METHODS */
  setData(data: T[], columns: string[]) {
    this.tableData.set(data);
    this.columnsData.set(columns);
    this.page.set(1);
  }

  onSearch(value: string) {
    this.search.set(value);
    this.page.set(1);
  }

  onPageSizeChange(value: number) {
    if (value < 1) return;
    this.pageSize.set(value);
    this.page.set(1);
  }

  goToPage(p: number) {
    if (p >= 1 && p <= this.totalPages()) {
      this.page.set(p);
    }
  }
  resetState() {
    this.searchByField.set({})
    this.search.set('');
    this.page.set(1);
    this.pageSize.set(10);
  }
}
