import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminSuitFitComponent } from './admin-suit-fit.component';

describe('AdminSuitFitComponent', () => {
  let component: AdminSuitFitComponent;
  let fixture: ComponentFixture<AdminSuitFitComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminSuitFitComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminSuitFitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
