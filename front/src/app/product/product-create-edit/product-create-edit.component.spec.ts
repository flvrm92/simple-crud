import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductCreateEditComponent } from './product-create-edit.component';

describe('ProductCreateEditComponent', () => {
  let component: ProductCreateEditComponent;
  let fixture: ComponentFixture<ProductCreateEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductCreateEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductCreateEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
