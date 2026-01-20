import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppointmentHome } from './appointment-home';

describe('AppointmentHome', () => {
  let component: AppointmentHome;
  let fixture: ComponentFixture<AppointmentHome>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AppointmentHome]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppointmentHome);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
