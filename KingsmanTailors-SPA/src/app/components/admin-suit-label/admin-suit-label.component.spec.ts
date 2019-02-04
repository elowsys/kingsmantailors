import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminSuitLabelComponent } from './admin-suit-label.component';

describe('AdminSuitLabelComponent', () => {
  let component: AdminSuitLabelComponent;
  let fixture: ComponentFixture<AdminSuitLabelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminSuitLabelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminSuitLabelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
