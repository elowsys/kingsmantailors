import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminSystemUserEditComponent } from './admin-system-user-edit.component';

describe('AdminSystemUserEditComponent', () => {
  let component: AdminSystemUserEditComponent;
  let fixture: ComponentFixture<AdminSystemUserEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminSystemUserEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminSystemUserEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
