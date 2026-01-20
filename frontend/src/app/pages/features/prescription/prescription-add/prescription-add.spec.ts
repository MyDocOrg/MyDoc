import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrescriptionAdd } from './prescription-add';

describe('PrescriptionAdd', () => {
  let component: PrescriptionAdd;
  let fixture: ComponentFixture<PrescriptionAdd>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PrescriptionAdd]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrescriptionAdd);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
