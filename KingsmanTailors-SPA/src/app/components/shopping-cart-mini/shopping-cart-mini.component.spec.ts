import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoppingCartMiniComponent } from './shopping-cart-mini.component';

describe('ShoppingCartMiniComponent', () => {
  let component: ShoppingCartMiniComponent;
  let fixture: ComponentFixture<ShoppingCartMiniComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShoppingCartMiniComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShoppingCartMiniComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
