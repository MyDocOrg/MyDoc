import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultationHome } from './consultation-home';

describe('ConsultationHome', () => {
  let component: ConsultationHome;
  let fixture: ComponentFixture<ConsultationHome>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ConsultationHome]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ConsultationHome);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
