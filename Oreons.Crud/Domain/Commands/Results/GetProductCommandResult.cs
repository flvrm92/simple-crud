using System;
using Domain.Entities;
using Shared.Commands;

namespace Domain.Commands.Results
{
    public class GetProductCommandResult : ICommandResult
    {
        internal static GetSubCategoryCommandResult GetSubCategory(SubCategory subCategory)
        {
            return new GetSubCategoryCommandResult
            {
                Id = subCategory.Id,
                Name = subCategory.Name,
                CategoryId = subCategory.CategoryId,
                CategoryName = subCategory.Category?.Name
            };
        }

        public static GetProductCommandResult Map(Product product)
        {
            if (product != null)
                return new GetProductCommandResult
                {
                    Id = product.Id,
                    Name = product.Name,
                    SubCategory = GetSubCategory(product.SubCategory)
                };

            return null;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public GetSubCategoryCommandResult SubCategory { get; set; }
    }
}
