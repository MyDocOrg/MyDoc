import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicalHistoryAdd } from './medical-history-add';

describe('MedicalHistoryAdd', () => {
  let component: MedicalHistoryAdd;
  let fixture: ComponentFixture<MedicalHistoryAdd>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MedicalHistoryAdd]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MedicalHistoryAdd);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
