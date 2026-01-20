import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppointmentStatusTable } from './appointment-status-table';

describe('AppointmentStatusTable', () => {
  let component: AppointmentStatusTable;
  let fixture: ComponentFixture<AppointmentStatusTable>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AppointmentStatusTable]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppointmentStatusTable);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
