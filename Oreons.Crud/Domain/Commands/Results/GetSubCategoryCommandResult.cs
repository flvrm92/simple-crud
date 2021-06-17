using Domain.Entities;
using System;
using Shared.Commands;

namespace Domain.Commands.Results
{
    public class GetSubCategoryCommandResult : ICommandResult
    {
        public static GetSubCategoryCommandResult Map(SubCategory subCategory)
        {
            if (subCategory != null)
                return new GetSubCategoryCommandResult
                {
                    Id = subCategory.Id,
                    Name = subCategory.Name,
                    CategoryId = subCategory.CategoryId,
                    CategoryName = subCategory.Category?.Name
                };

            return null;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
