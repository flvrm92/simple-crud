import { Subcategory } from "./subcategory";

interface Product {
  id: string | null,
  name: string,
  subCategoryId: string,
  subCategory: Subcategory | undefined | null
}

interface ProductListResponse {
  data: Array<Product>,
  success: boolean
}

interface ProductResponse {
  data: Product,
  success: boolean
}

export {
  Product,
  ProductListResponse,
  ProductResponse
}
