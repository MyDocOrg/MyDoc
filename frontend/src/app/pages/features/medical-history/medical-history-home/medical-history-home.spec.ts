import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicalHistoryHome } from './medical-history-home';

describe('MedicalHistoryHome', () => {
  let component: MedicalHistoryHome;
  let fixture: ComponentFixture<MedicalHistoryHome>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MedicalHistoryHome]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MedicalHistoryHome);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
