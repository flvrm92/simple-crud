import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryCraeteEditComponent } from './category-craete-edit.component';

describe('CategoryCraeteEditComponent', () => {
  let component: CategoryCraeteEditComponent;
  let fixture: ComponentFixture<CategoryCraeteEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryCraeteEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryCraeteEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
