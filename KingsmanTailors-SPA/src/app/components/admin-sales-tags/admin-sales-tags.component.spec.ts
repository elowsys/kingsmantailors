import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminSalesTagsComponent } from './admin-sales-tags.component';

describe('AdminSalesTagsComponent', () => {
  let component: AdminSalesTagsComponent;
  let fixture: ComponentFixture<AdminSalesTagsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminSalesTagsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminSalesTagsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
