import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Toaster } from 'ngx-toast-notifications';
import { Category } from 'src/app/models/category';
import { CategoryService } from '../category.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.scss'],
  providers: [CategoryService]
})
export class CategoryListComponent implements OnInit {

  categories: Array<Category> = [];

  constructor(private categoryService: CategoryService,
    private router: Router,
    private toaster: Toaster) {
  }

  ngOnInit(): void {
    this.getData();
  }

  getData() {
    this.categories = [];
    this.categoryService.get().subscribe(result => {
      if (result.success) {
        const data = result.data;

        if (data.length > 0) {
          data.forEach(category => {
            this.categories.push(category);
          });
        }
      }
    });
  }

  edit(id: string | null) {
    if (!id)
      return;

    this.router.navigate(['/category', id]);
  }

  remove(id: string | null) {
    if (!id)
      return;

    this.categoryService.remove(id).subscribe(result => {
      if (result.success) {
        this.toaster.open(result.data.message, {
          position: 'top-center',
          type: 'danger',
          preventDuplicates: true
        });

        this.getData();
      }
    });
  }

}
