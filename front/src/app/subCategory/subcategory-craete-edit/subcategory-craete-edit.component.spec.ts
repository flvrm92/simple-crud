import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubcategoryCraeteEditComponent } from './subcategory-craete-edit.component';

describe('SubcategoryCraeteEditComponent', () => {
  let component: SubcategoryCraeteEditComponent;
  let fixture: ComponentFixture<SubcategoryCraeteEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubcategoryCraeteEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubcategoryCraeteEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
