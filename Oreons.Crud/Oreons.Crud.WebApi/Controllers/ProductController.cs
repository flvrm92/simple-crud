using Domain.Commands.Handlers;
using Domain.Commands.Inputs;
using Domain.Commands.Results;
using Domain.Repositories;
using Infra.Transiction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace WebApi.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly AddUpdateProductCommandHandler _addUpdateProductCommandHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;

        public ProductController(IUow uow,
            IProductRepository productRepository,
            AddUpdateProductCommandHandler addUpdateProductCommandHandler,
            RemoveProductCommandHandler removeProductCommandHandler)
            : base(uow)
        {
            _productRepository = productRepository;
            _addUpdateProductCommandHandler = addUpdateProductCommandHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("v1/product/getbyid/{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            return ApiResponse(GetProductCommandResult.Map(_productRepository.GetById(id)));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("v1/product/get")]
        public IActionResult Get()
        {
            return ApiResponse(_productRepository.Get().Select(GetProductCommandResult.Map));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("v1/product/add")]
        public IActionResult Add([FromBody] ProductCommand command)
        {
            var result = _addUpdateProductCommandHandler.Handle(command);
            return ApiResponse(result);
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("v1/product/update")]
        public IActionResult Update([FromBody] ProductCommand command)
        {
            var result = _addUpdateProductCommandHandler.Handle(command);
            return ApiResponse(result);
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("v1/product/delete")]
        public IActionResult Delete([FromQuery] Guid id)
        {
            var result = _removeProductCommandHandler.Handle(id);
            return ApiResponse(result);
        }
    }
}
