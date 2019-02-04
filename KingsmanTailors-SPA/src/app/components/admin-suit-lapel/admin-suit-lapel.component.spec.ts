import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminSuitLapelComponent } from './admin-suit-lapel.component';

describe('AdminSuitLapelComponent', () => {
  let component: AdminSuitLapelComponent;
  let fixture: ComponentFixture<AdminSuitLapelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminSuitLapelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminSuitLapelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
