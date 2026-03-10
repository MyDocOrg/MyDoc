import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomePwa } from './home';

describe('HomePwa', () => {
  let component: HomePwa;
  let fixture: ComponentFixture<HomePwa>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomePwa]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HomePwa);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
