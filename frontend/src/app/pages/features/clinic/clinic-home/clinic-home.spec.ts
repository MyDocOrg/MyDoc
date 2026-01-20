import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClinicHome } from './clinic-home';

describe('ClinicHome', () => {
  let component: ClinicHome;
  let fixture: ComponentFixture<ClinicHome>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClinicHome]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClinicHome);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
