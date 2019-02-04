import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminSuitDetailComponent } from './admin-suit-detail.component';

describe('AdminSuitDetailComponent', () => {
  let component: AdminSuitDetailComponent;
  let fixture: ComponentFixture<AdminSuitDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminSuitDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminSuitDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
