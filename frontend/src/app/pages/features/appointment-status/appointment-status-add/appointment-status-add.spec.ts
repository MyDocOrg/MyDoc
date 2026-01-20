import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppointmentStatusAdd } from './appointment-status-add';

describe('AppointmentStatusAdd', () => {
  let component: AppointmentStatusAdd;
  let fixture: ComponentFixture<AppointmentStatusAdd>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AppointmentStatusAdd]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppointmentStatusAdd);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
