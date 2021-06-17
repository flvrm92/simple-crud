using Domain.Commands.Results;
using Domain.Repositories;
using Shared.Commands;
using System;

namespace Domain.Commands.Handlers
{
    public class RemoveProductCommandHandler : ICommandHandler<Guid>
    {
        private readonly IProductRepository _productRepository;
        public RemoveProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public ICommandResult Handle(Guid id)
        {
            _productRepository.Delete(id);

            return new GenericCommandResult
            {
                Message = "Produto removido com sucesso!"
            };
        }
    }
}
