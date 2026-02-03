import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClinicEdit } from './clinic-edit';

describe('ClinicEdit', () => {
  let component: ClinicEdit;
  let fixture: ComponentFixture<ClinicEdit>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClinicEdit]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClinicEdit);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
