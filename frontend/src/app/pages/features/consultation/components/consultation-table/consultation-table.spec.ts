import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultationTable } from './consultation-table';

describe('ConsultationTable', () => {
  let component: ConsultationTable;
  let fixture: ComponentFixture<ConsultationTable>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ConsultationTable]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ConsultationTable);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
