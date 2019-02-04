import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminSystemUsersComponent } from './admin-system-users.component';

describe('AdminSystemUsersComponent', () => {
  let component: AdminSystemUsersComponent;
  let fixture: ComponentFixture<AdminSystemUsersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminSystemUsersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminSystemUsersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
