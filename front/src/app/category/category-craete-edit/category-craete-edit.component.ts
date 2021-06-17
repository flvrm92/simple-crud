import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Category } from 'src/app/models/category';
import { CategoryService } from '../category.service';
import { Toaster } from 'ngx-toast-notifications';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-category-craete-edit',
  templateUrl: './category-craete-edit.component.html',
  styleUrls: ['./category-craete-edit.component.scss'],
  providers: [CategoryService],
})
export class CategoryCraeteEditComponent implements OnInit {

  public form: FormGroup;
  public buttonText: string = 'Salvar';
  public categoryId: string | null = null;

  constructor(private categoryService: CategoryService,
    public fb: FormBuilder,
    private toaster: Toaster,
    private router: Router,
    private route: ActivatedRoute) {
    this.form = this.fb.group({
      name: ['', Validators.compose([
        Validators.required
      ])]
    });
  }

  ngOnInit(): void {
    this.categoryId = this.route.snapshot.paramMap.get('id');
    if (this.categoryId) {
      this.buttonText = 'Atualizar';
      this.categoryService.getbyid(this.categoryId).subscribe(result => {
        if (result.success) {
          const category = result.data;

          this.form.patchValue({
            name: category.name
          });
        }
      });
    }
  }

  submit() {
    const name = this.form.get('name')?.value;

    const args: Category = {
      id: !this.categoryId ? null : this.categoryId,
      name: name
    };

    const req = !this.categoryId
      ? this.categoryService.save(args)
      : this.categoryService.update(args)

    req.subscribe(result => {
      if (result.success) {
        this.toaster.open(result.data.message, {
          position: 'top-center',
          type: 'success',
          preventDuplicates: true
        });

        setTimeout(() => {
          this.router.navigate(['/categories']);
        }, 2000);

      }
    });

  }

}
