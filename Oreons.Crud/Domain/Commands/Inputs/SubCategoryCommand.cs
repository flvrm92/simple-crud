using System;
using Shared.Commands;

namespace Domain.Commands.Inputs
{
    public class SubCategoryCommand : ICommand
    {
        public Guid? Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }

    }
}
