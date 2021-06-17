import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Toaster } from 'ngx-toast-notifications';
import { CategoryService } from 'src/app/category/category.service';
import { Category } from 'src/app/models/category';
import { Subcategory } from 'src/app/models/subcategory';
import { SubCategoryService } from '../subcategory.service';

@Component({
  selector: 'app-subcategory-craete-edit',
  templateUrl: './subcategory-craete-edit.component.html',
  styleUrls: ['./subcategory-craete-edit.component.scss'],
  providers: [SubCategoryService, CategoryService]
})
export class SubcategoryCraeteEditComponent implements OnInit {

  public form: FormGroup;
  public buttonText: string = 'Salvar';
  public subCategoryId: string | null = null;
  public categories: Array<Category> = [];

  constructor(private subCategoryService: SubCategoryService,
    private categoryService: CategoryService,
    public fb: FormBuilder,
    private toaster: Toaster,
    private router: Router,
    private route: ActivatedRoute) {
    this.form = this.fb.group({
      name: ['', Validators.compose([
        Validators.required
      ])],
      category: ['', Validators.compose([
        Validators.required
      ])]
    });

    this.getCategories();
  }

  getCategories() {
    this.categoryService.get().subscribe(result => {
      if (result.success && result.data.length > 0) {
        result.data.forEach(category => {
          this.categories.push(category);
        });
      }
    });
  }

  ngOnInit(): void {
    this.subCategoryId = this.route.snapshot.paramMap.get('id');
    if (this.subCategoryId) {
      this.buttonText = 'Atualizar';
      this.subCategoryService.getbyid(this.subCategoryId).subscribe(result => {
        if (result.success) {
          const subCategory = result.data;

          this.form.patchValue({
            name: subCategory.name,
            category: subCategory.categoryId
          });
        }
      });
    }
  }

  submit() {
    const name = this.form.get('name')?.value;
    const categoryId = this.form.get('category')?.value;
    const category = this.categories.find(i => i.id === categoryId);        

    const args: Subcategory = {
      id: !this.subCategoryId ? null : this.subCategoryId,
      name: name,
      categoryId: categoryId,
      categoryName: category?.name
    };

    const req = !this.subCategoryId
      ? this.subCategoryService.save(args)
      : this.subCategoryService.update(args)

    req.subscribe(result => {
      if (result.success) {
        this.toaster.open(result.data.message, {
          position: 'top-center',
          type: 'success',
          preventDuplicates: true
        });

        setTimeout(() => {
          this.router.navigate(['/subcategories']);
        }, 2000);

      }
    });

  }

}
