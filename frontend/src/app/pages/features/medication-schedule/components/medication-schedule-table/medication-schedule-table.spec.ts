import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicationScheduleTable } from './medication-schedule-table';

describe('MedicationScheduleTable', () => {
  let component: MedicationScheduleTable;
  let fixture: ComponentFixture<MedicationScheduleTable>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MedicationScheduleTable]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MedicationScheduleTable);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
