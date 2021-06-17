using System;
using Shared.Commands;

namespace Domain.Commands.Inputs
{
    public class CategoryCommand : ICommand
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
    }
}
