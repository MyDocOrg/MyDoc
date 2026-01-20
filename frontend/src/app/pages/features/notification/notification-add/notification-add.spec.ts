import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotificationAdd } from './notification-add';

describe('NotificationAdd', () => {
  let component: NotificationAdd;
  let fixture: ComponentFixture<NotificationAdd>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NotificationAdd]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NotificationAdd);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
