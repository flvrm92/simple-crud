using Domain.Commands.Inputs;
using Domain.Commands.Results;
using Domain.Entities;
using Domain.Repositories;
using Shared.Commands;
using System;

namespace Domain.Commands.Handlers
{
    public class AddUpdateProductCommandHandler : ICommandHandler<ProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public AddUpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ICommandResult Handle(ProductCommand command)
        {
            string msg;

            if (command.Id != null && command.Id != Guid.Empty)
            {
                var product = _productRepository.GetById(command.Id.Value);
                if (product != null)
                    product.Update(command.Name, command.SubCategoryId);

                msg = "Produto atualizado com sucesso";
            }
            else
            {
                var newProduct = new Product(command.Name, command.SubCategoryId);
                _productRepository.Save(newProduct);

                msg = "Produto salvo com sucesso";
            }

            return new GenericCommandResult
            {
                Message = msg
            };
        }
    }
}
