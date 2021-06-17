import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryCraeteEditComponent } from './category/category-craete-edit/category-craete-edit.component';
import { CategoryListComponent } from './category/category-list/category-list.component';
import { ProductCreateEditComponent } from './product/product-create-edit/product-create-edit.component';
import { ProductListComponent } from './product/product-list/product-list.component';
import { SubcategoryCraeteEditComponent } from './subCategory/subcategory-craete-edit/subcategory-craete-edit.component';
import { SubcategoryListComponent } from './subCategory/subcategory-list/subcategory-list.component';

const routes: Routes = [
  { path: '', redirectTo: '/products', pathMatch: 'full' },
  { path: 'products', component: ProductListComponent },
  { path: 'product', redirectTo: 'product/', pathMatch: 'full' },
  { path: 'product/:id', component: ProductCreateEditComponent },
  { path: 'categories', component: CategoryListComponent },
  { path: 'category', redirectTo: 'category/', pathMatch: 'full' },
  { path: 'category/:id', component: CategoryCraeteEditComponent },
  { path: 'subcategories', component: SubcategoryListComponent },
  { path: 'subcategory', redirectTo: 'subcategory/', pathMatch: 'full' },
  { path: 'subcategory/:id', component: SubcategoryCraeteEditComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
