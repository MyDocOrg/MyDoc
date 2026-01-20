import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicineHome } from './medicine-home';

describe('MedicineHome', () => {
  let component: MedicineHome;
  let fixture: ComponentFixture<MedicineHome>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MedicineHome]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MedicineHome);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
