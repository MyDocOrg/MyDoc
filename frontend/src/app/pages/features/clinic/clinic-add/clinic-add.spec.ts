import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClinicAdd } from './clinic-add';

describe('ClinicAdd', () => {
  let component: ClinicAdd;
  let fixture: ComponentFixture<ClinicAdd>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClinicAdd]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClinicAdd);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
