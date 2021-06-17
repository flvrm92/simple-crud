using Shared.Commands;
using System;

namespace Domain.Commands.Inputs
{
    public class ProductCommand : ICommand
    {
        public Guid? Id { get; set; }
        public Guid SubCategoryId { get; set; }
        public string Name { get; set; }
    }
}
