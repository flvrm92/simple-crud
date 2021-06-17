import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Toaster } from 'ngx-toast-notifications';
import { CategoryService } from 'src/app/category/category.service';
import { Category } from 'src/app/models/category';
import { Product } from 'src/app/models/product';
import { Subcategory } from 'src/app/models/subcategory';
import { SubCategoryService } from 'src/app/subCategory/subcategory.service';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-create-edit',
  templateUrl: './product-create-edit.component.html',
  styleUrls: ['./product-create-edit.component.scss'],
  providers: [ProductService, SubCategoryService, CategoryService]
})
export class ProductCreateEditComponent implements OnInit {

  public form: FormGroup;
  public buttonText: string = 'Salvar';
  public productId: string | null = null;
  public subCategoriesArray: Array<Subcategory> = [];
  public subcategories: Array<Subcategory> = [];
  public categories: Array<Category> = [];

  constructor(private productService: ProductService,
    private subCategoryService: SubCategoryService,
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
      ])],
      subcategory: ['', Validators.compose([
        Validators.required
      ])]
    });

    this.getCategories();
    this.getSubCategories();

    this.form.get('category')?.valueChanges.subscribe(val => {
      this.subcategories = [];
      console.log(this.form)
      const subcategories = this.subCategoriesArray.filter(d => d.categoryId === val);
      if (subcategories) {
        subcategories.forEach(sub => {
          this.subcategories.push(sub);
        });

        const firstValue = subcategories[0];
        this.form.patchValue({
          subcategory: firstValue?.id
        });
      }
    });

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

  getSubCategories() {
    this.subCategoryService.get().subscribe(result => {
      if (result.success && result.data.length > 0) {
        result.data.forEach(subCategory => {
          this.subCategoriesArray.push(subCategory);
        });
      }
    });
  }

  ngOnInit(): void {
    this.productId = this.route.snapshot.paramMap.get('id');
    if (this.productId) {
      this.buttonText = 'Atualizar';
      this.productService.getbyid(this.productId).subscribe(result => {
        if (result.success) {
          const product = result.data;

          this.form.patchValue({
            name: product.name,
            category: product.subCategory?.categoryId,
            subcategory: product.subCategory?.id
          });
        }
      });
    }
  }

  submit() {
    const name = this.form.get('name')?.value;
    const subcategoryId = this.form.get('subcategory')?.value;
    const subcategory = this.subcategories.find(i => i.id === subcategoryId);

    const args: Product = {
      id: !this.productId ? null : this.productId,
      name: name,
      subCategoryId: subcategoryId,
      subCategory: subcategory
    };

    const req = !this.productId
      ? this.productService.save(args)
      : this.productService.update(args)

    req.subscribe(result => {
      if (result.success) {
        this.toaster.open(result.data.message, {
          position: 'top-center',
          type: 'success',
          preventDuplicates: true
        });

        setTimeout(() => {
          this.router.navigate(['/products']);
        }, 2000);

      }
    });

  }

}
