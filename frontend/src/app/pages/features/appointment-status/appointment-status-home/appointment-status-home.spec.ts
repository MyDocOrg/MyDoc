import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppointmentStatusHome } from './appointment-status-home';

describe('AppointmentStatusHome', () => {
  let component: AppointmentStatusHome;
  let fixture: ComponentFixture<AppointmentStatusHome>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AppointmentStatusHome]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppointmentStatusHome);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
