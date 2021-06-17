interface Category {
  id: string | null,
  name: string
}

interface CategoryListResponse {
  data: Array<Category>,
  success: boolean
}

interface CategoryResponse {
  data: Category,
  success: boolean
}

export {
  Category,
  CategoryListResponse,
  CategoryResponse
}
