import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MessageBroadcastComponent } from './message-broadcast.component';

describe('MessageBroadcastComponent', () => {
  let component: MessageBroadcastComponent;
  let fixture: ComponentFixture<MessageBroadcastComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MessageBroadcastComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MessageBroadcastComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
