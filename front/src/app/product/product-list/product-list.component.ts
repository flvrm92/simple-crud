import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Toaster } from 'ngx-toast-notifications';
import { Product } from 'src/app/models/product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss'],
  providers: [ProductService]
})
export class ProductListComponent implements OnInit {

  products: Array<Product> = [];

  constructor(private productService: ProductService,
    private router: Router,
    private toaster: Toaster) { }

  ngOnInit(): void {
    this.getData();
  }

  getData() {
    this.products = [];
    this.productService.get().subscribe(result => {
      if (result.success) {
        const data = result.data;

        if (data.length > 0) {
          data.forEach(product => {
            this.products.push(product);
          });
        }
      }
    });
  }

  edit(id: string | null) {
    if (!id)
      return;

    this.router.navigate(['/product', id]);
  }

  remove(id: string | null) {
    if (!id)
      return;

    this.productService.remove(id).subscribe(result => {
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
