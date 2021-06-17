import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductListComponent } from './product/product-list/product-list.component';
import { ProductCreateEditComponent } from './product/product-create-edit/product-create-edit.component';
import { CategoryListComponent } from './category/category-list/category-list.component';
import { CategoryCraeteEditComponent } from './category/category-craete-edit/category-craete-edit.component';
import { SubcategoryListComponent } from './subCategory/subcategory-list/subcategory-list.component';
import { SubcategoryCraeteEditComponent } from './subCategory/subcategory-craete-edit/subcategory-craete-edit.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule, HttpHandler } from '@angular/common/http';
import { ToastNotificationsModule } from 'ngx-toast-notifications';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'

@NgModule({
  declarations: [
    AppComponent,
    ProductListComponent,
    ProductCreateEditComponent,
    CategoryListComponent,
    CategoryCraeteEditComponent,
    SubcategoryListComponent,
    SubcategoryCraeteEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    ToastNotificationsModule,
    BrowserAnimationsModule
  ],
  providers: [HttpClient],
  bootstrap: [AppComponent],
  exports: [
    BrowserModule
  ]
})
export class AppModule { }
