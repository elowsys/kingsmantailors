import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminSuitVentComponent } from './admin-suit-vent.component';

describe('AdminSuitVentComponent', () => {
  let component: AdminSuitVentComponent;
  let fixture: ComponentFixture<AdminSuitVentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminSuitVentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminSuitVentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
