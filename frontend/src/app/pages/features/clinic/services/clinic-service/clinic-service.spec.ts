import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClinicService } from './clinic-service';

describe('ClinicService', () => {
  let component: ClinicService;
  let fixture: ComponentFixture<ClinicService>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClinicService]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClinicService);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
