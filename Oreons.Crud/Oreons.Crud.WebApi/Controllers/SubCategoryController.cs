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
    public class SubCategoryController : BaseController
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly AddUpdateSubCategoryCommandHandler _addUpdateSubCategoryCommandHandler;
        private readonly RemoveSubCategoryCommandHandler _removeSubCategoryCommandHandler;

        public SubCategoryController(IUow uow,
            ISubCategoryRepository subCategoryRepository,
            AddUpdateSubCategoryCommandHandler addUpdateSubCategoryCommandHandler,
            RemoveSubCategoryCommandHandler removeSubCategoryCommandHandler)
            : base(uow)
        {
            _subCategoryRepository = subCategoryRepository;
            _addUpdateSubCategoryCommandHandler = addUpdateSubCategoryCommandHandler;
            _removeSubCategoryCommandHandler = removeSubCategoryCommandHandler;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("v1/subcategory/getbyid/{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            return ApiResponse(GetSubCategoryCommandResult.Map(_subCategoryRepository.GetById(id)));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("v1/subcategory/get")]
        public IActionResult Get()
        {
            return ApiResponse(_subCategoryRepository.Get().Select(GetSubCategoryCommandResult.Map));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("v1/subcategory/add")]
        public IActionResult Add([FromBody] SubCategoryCommand command)
        {
            var result = _addUpdateSubCategoryCommandHandler.Handle(command);
            return ApiResponse(result);
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("v1/subcategory/update")]
        public IActionResult Update([FromBody] SubCategoryCommand command)
        {
            var result = _addUpdateSubCategoryCommandHandler.Handle(command);
            return ApiResponse(result);
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("v1/subcategory/delete")]
        public IActionResult Delete([FromQuery] Guid id)
        {
            var result = _removeSubCategoryCommandHandler.Handle(id);
            return ApiResponse(result);
        }
    }
}
