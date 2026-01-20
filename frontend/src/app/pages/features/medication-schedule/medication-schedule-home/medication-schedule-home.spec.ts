import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicationScheduleHome } from './medication-schedule-home';

describe('MedicationScheduleHome', () => {
  let component: MedicationScheduleHome;
  let fixture: ComponentFixture<MedicationScheduleHome>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MedicationScheduleHome]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MedicationScheduleHome);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
