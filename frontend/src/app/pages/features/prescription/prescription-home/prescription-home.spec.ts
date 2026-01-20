import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrescriptionHome } from './prescription-home';

describe('PrescriptionHome', () => {
  let component: PrescriptionHome;
  let fixture: ComponentFixture<PrescriptionHome>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PrescriptionHome]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrescriptionHome);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
