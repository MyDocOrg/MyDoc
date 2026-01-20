import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotificationHome } from './notification-home';

describe('NotificationHome', () => {
  let component: NotificationHome;
  let fixture: ComponentFixture<NotificationHome>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NotificationHome]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NotificationHome);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
