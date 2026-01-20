import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicalHistoryTable } from './medical-history-table';

describe('MedicalHistoryTable', () => {
  let component: MedicalHistoryTable;
  let fixture: ComponentFixture<MedicalHistoryTable>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MedicalHistoryTable]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MedicalHistoryTable);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
