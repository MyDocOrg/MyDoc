import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrescriptionTable } from './prescription-table';

describe('PrescriptionTable', () => {
  let component: PrescriptionTable;
  let fixture: ComponentFixture<PrescriptionTable>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PrescriptionTable]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrescriptionTable);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
