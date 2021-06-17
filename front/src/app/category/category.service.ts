import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';

import { ApiUrl } from '../app.api'
import { Category, CategoryListResponse, CategoryResponse } from "../models/category";
import { Observable } from "rxjs";
import { GenericResult } from "../models/generic-result";

@Injectable()
export class CategoryService {
  constructor(private http: HttpClient) {
  }

  getbyid(id: string): Observable<CategoryResponse> {
    const url = `${ApiUrl}/v1/category/getbyid/${id}`;
    return this.http.get<CategoryResponse>(url);
  }

  get(): Observable<CategoryListResponse> {
    const url = `${ApiUrl}/v1/category/get`;
    return this.http.get<CategoryListResponse>(url);
  }

  save(data: Category): Observable<GenericResult> {
    const url = `${ApiUrl}/v1/category/add`;
    return this.http.post<GenericResult>(url, data);
  }

  update(data: Category): Observable<GenericResult> {
    const url = `${ApiUrl}/v1/category/update`;
    return this.http.put<GenericResult>(url, data);
  }

  remove(id: string): Observable<GenericResult> {
    const url = `${ApiUrl}/v1/category/delete`;
    return this.http.delete<GenericResult>(url, { params: { id: id } });
  }

}