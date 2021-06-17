interface Subcategory {
  id: string | null,
  name: string,
  categoryId: string
  categoryName: string | undefined
}

interface SubcategoryListResponse {
  data: Array<Subcategory>,
  success: boolean
}

interface SubcategoryResponse {
  data: Subcategory,
  success: boolean
}

export {
  Subcategory,
  SubcategoryResponse,
  SubcategoryListResponse
}
