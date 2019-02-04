import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminSuitFrontComponent } from './admin-suit-front.component';

describe('AdminSuitFrontComponent', () => {
  let component: AdminSuitFrontComponent;
  let fixture: ComponentFixture<AdminSuitFrontComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminSuitFrontComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminSuitFrontComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
