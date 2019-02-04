import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminSuitFabricComponent } from './admin-suit-fabric.component';

describe('AdminSuitFabricComponent', () => {
  let component: AdminSuitFabricComponent;
  let fixture: ComponentFixture<AdminSuitFabricComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminSuitFabricComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminSuitFabricComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
