import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminSuitComponent } from './admin-suit.component';

describe('AdminSuitComponent', () => {
  let component: AdminSuitComponent;
  let fixture: ComponentFixture<AdminSuitComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminSuitComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminSuitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
