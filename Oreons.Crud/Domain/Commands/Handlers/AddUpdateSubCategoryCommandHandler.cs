using Domain.Commands.Inputs;
using Domain.Commands.Results;
using Domain.Entities;
using Domain.Repositories;
using Shared.Commands;
using System;

namespace Domain.Commands.Handlers
{
    public class AddUpdateSubCategoryCommandHandler : ICommandHandler<SubCategoryCommand>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        public AddUpdateSubCategoryCommandHandler(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public ICommandResult Handle(SubCategoryCommand command)
        {
            string msg;

            if (command.Id != null && command.Id != Guid.Empty)
            {
                var subCategory = _subCategoryRepository.GetById(command.Id.Value);
                if (subCategory != null)
                    subCategory.Update(command.Name, command.CategoryId);

                msg = "Subcategoria atualizada com sucesso";
            }
            else
            {
                var newSubCategory = new SubCategory(command.Name, command.CategoryId);
                _subCategoryRepository.Save(newSubCategory);

                msg = "Subcategoria salva com sucesso";
            }

            return new GenericCommandResult
            {
                Message = msg
            };
        }
    }
}
