using Domain.Entities;
using System;
using Shared.Commands;

namespace Domain.Commands.Results
{
    public class GetCategoryCommandResult : ICommandResult
    {
        public static GetCategoryCommandResult Map(Category category)
        {
            if (category != null)
                return new GetCategoryCommandResult
                {
                    Id = category.Id,
                    Name = category.Name,
                };

            return null;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
