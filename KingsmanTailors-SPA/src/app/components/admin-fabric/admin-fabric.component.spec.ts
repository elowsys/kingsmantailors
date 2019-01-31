import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminFabricComponent } from './admin-fabric.component';

describe('AdminFabricComponent', () => {
  let component: AdminFabricComponent;
  let fixture: ComponentFixture<AdminFabricComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminFabricComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminFabricComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
