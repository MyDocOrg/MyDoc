import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppointmentStatusForm } from './appointment-status-form';

describe('AppointmentStatusForm', () => {
  let component: AppointmentStatusForm;
  let fixture: ComponentFixture<AppointmentStatusForm>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AppointmentStatusForm]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppointmentStatusForm);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
