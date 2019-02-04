import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminAppointmentDetailComponent } from './admin-appointment-detail.component';

describe('AdminAppointmentDetailComponent', () => {
  let component: AdminAppointmentDetailComponent;
  let fixture: ComponentFixture<AdminAppointmentDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminAppointmentDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminAppointmentDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
