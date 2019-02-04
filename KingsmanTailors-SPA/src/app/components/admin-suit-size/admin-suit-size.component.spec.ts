import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminSuitSizeComponent } from './admin-suit-size.component';

describe('AdminSuitSizeComponent', () => {
  let component: AdminSuitSizeComponent;
  let fixture: ComponentFixture<AdminSuitSizeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminSuitSizeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminSuitSizeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
