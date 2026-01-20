import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicationScheduleAdd } from './medication-schedule-add';

describe('MedicationScheduleAdd', () => {
  let component: MedicationScheduleAdd;
  let fixture: ComponentFixture<MedicationScheduleAdd>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MedicationScheduleAdd]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MedicationScheduleAdd);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
