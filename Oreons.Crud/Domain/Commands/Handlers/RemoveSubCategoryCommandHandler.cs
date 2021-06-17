using Domain.Commands.Results;
using Domain.Repositories;
using Shared.Commands;
using System;

namespace Domain.Commands.Handlers
{
    public class RemoveSubCategoryCommandHandler : ICommandHandler<Guid>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        public RemoveSubCategoryCommandHandler(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public ICommandResult Handle(Guid id)
        {
            _subCategoryRepository.Delete(id);
            return new GenericCommandResult
            {
                Message = "Sub categoria removida com sucesso."
            };
        }
    }
}
