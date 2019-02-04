import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminSystemUserDetailComponent } from './admin-system-user-detail.component';

describe('AdminSystemUserDetailComponent', () => {
  let component: AdminSystemUserDetailComponent;
  let fixture: ComponentFixture<AdminSystemUserDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminSystemUserDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminSystemUserDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
