import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';

import { ApiUrl } from '../app.api'
import { Observable } from "rxjs";
import { GenericResult } from "../models/generic-result";
import { Product, ProductListResponse, ProductResponse } from "../models/product";

@Injectable()
export class ProductService {
  constructor(private http: HttpClient) {

  }

  getbyid(id: string): Observable<ProductResponse> {
    const url = `${ApiUrl}/v1/product/getbyid/${id}`;
    return this.http.get<ProductResponse>(url);
  }

  get(): Observable<ProductListResponse> {
    const url = `${ApiUrl}/v1/product/get`;
    return this.http.get<ProductListResponse>(url);
  }

  save(data: Product): Observable<GenericResult> {
    const url = `${ApiUrl}/v1/product/add`;
    return this.http.post<GenericResult>(url, data);
  }

  update(data: Product): Observable<GenericResult> {
    const url = `${ApiUrl}/v1/product/update`;
    return this.http.put<GenericResult>(url, data);
  }

  remove(id: string): Observable<GenericResult> {
    const url = `${ApiUrl}/v1/product/delete`;
    return this.http.delete<GenericResult>(url, { params: { id: id } });
  }
}

