import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicationScheduleForm } from './medication-schedule-form';

describe('MedicationScheduleForm', () => {
  let component: MedicationScheduleForm;
  let fixture: ComponentFixture<MedicationScheduleForm>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MedicationScheduleForm]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MedicationScheduleForm);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
