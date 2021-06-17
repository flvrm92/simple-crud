using Domain.Commands.Inputs;
using Domain.Commands.Results;
using Domain.Entities;
using Domain.Repositories;
using Shared.Commands;
using System;

namespace Domain.Commands.Handlers
{
    public class AddUpdateCategoryCommandHandler : ICommandHandler<CategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        public AddUpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ICommandResult Handle(CategoryCommand command)
        {
            string msg;

            if (command.Id != null && command.Id != Guid.Empty)
            {
                var category = _categoryRepository.GetById(command.Id.Value);
                if (category != null)
                    category.Update(command.Name);

                msg = "Category atualizada com sucesso";
            }
            else
            {
                var newCategory = new Category(command.Name);
                _categoryRepository.Save(newCategory);

                msg = "Categoria salva com sucesso";
            }

            return new GenericCommandResult
            {
                Message = msg
            };
        }
    }
}
