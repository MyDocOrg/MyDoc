import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClinicTable } from './clinic-table';

describe('ClinicTable', () => {
  let component: ClinicTable;
  let fixture: ComponentFixture<ClinicTable>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClinicTable]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClinicTable);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
