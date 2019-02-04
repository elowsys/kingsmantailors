import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminSuitTypeComponent } from './admin-suit-type.component';

describe('AdminSuitTypeComponent', () => {
  let component: AdminSuitTypeComponent;
  let fixture: ComponentFixture<AdminSuitTypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminSuitTypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminSuitTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
