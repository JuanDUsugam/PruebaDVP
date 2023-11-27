import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonaNuevaComponent } from './persona-nueva.component';

describe('PersonaNuevaComponent', () => {
  let component: PersonaNuevaComponent;
  let fixture: ComponentFixture<PersonaNuevaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PersonaNuevaComponent]
    });
    fixture = TestBed.createComponent(PersonaNuevaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
