using Domain.Commands.Results;
using Domain.Repositories;
using Shared.Commands;
using System;

namespace Domain.Commands.Handlers
{
    public class RemoveCategoryCommandHandler : ICommandHandler<Guid>
    {
        private readonly ICategoryRepository _categoryRepository;

        public RemoveCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ICommandResult Handle(Guid id)
        {
            _categoryRepository.Delete(id);

            return new GenericCommandResult
            {
                Message = "Categoria removida com sucesso"
            };
        }
    }
}
