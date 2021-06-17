import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';

import { ApiUrl } from '../app.api'
import { Subcategory, SubcategoryListResponse, SubcategoryResponse } from "../models/subcategory";
import { Observable } from "rxjs";
import { GenericResult } from "../models/generic-result";

@Injectable()
export class SubCategoryService {
  constructor(private http: HttpClient) {

  }

  getbyid(id: string): Observable<SubcategoryResponse> {
    const url = `${ApiUrl}/v1/subcategory/getbyid/${id}`;
    return this.http.get<SubcategoryResponse>(url);
  }

  get(): Observable<SubcategoryListResponse> {
    const url = `${ApiUrl}/v1/subcategory/get`;
    return this.http.get<SubcategoryListResponse>(url);
  }

  save(data: Subcategory): Observable<GenericResult> {
    const url = `${ApiUrl}/v1/subcategory/add`;
    return this.http.post<GenericResult>(url, data);
  }

  update(data: Subcategory): Observable<GenericResult> {
    const url = `${ApiUrl}/v1/subcategory/update`;
    return this.http.put<GenericResult>(url, data);
  }

  remove(id: string): Observable<GenericResult> {
    const url = `${ApiUrl}/v1/subcategory/delete`;
    return this.http.delete<GenericResult>(url, { params: { id: id } });
  }
}

