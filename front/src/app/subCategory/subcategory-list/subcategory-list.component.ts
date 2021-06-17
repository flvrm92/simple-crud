import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Toaster } from 'ngx-toast-notifications';
import { Subcategory } from 'src/app/models/subcategory';
import { SubCategoryService } from '../subcategory.service';

@Component({
  selector: 'app-subcategory-list',
  templateUrl: './subcategory-list.component.html',
  styleUrls: ['./subcategory-list.component.scss'],
  providers: [SubCategoryService]
})
export class SubcategoryListComponent implements OnInit {

  subCategories: Array<Subcategory> = [];

  constructor(private subCategoryService: SubCategoryService,
    private router: Router,
    private toaster: Toaster) { }

  ngOnInit(): void {
    this.getData();
  }

  getData() {
    this.subCategories = [];
    this.subCategoryService.get().subscribe(result => {
      if (result.success) {
        const data = result.data;

        if (data.length > 0) {
          data.forEach(subCategory => {
            this.subCategories.push(subCategory);
          });
        }
      }
    });
  }

  edit(id: string | null) {
    if (!id)
      return;

    this.router.navigate(['/subcategory', id]);
  }

  remove(id: string | null) {
    if (!id)
      return;

    this.subCategoryService.remove(id).subscribe(result => {
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
