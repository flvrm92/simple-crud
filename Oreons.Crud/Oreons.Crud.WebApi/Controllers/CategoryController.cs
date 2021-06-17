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
    public class CategoryController : BaseController
    {
        private readonly AddUpdateCategoryCommandHandler _addUpdateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(IUow uow,
            AddUpdateCategoryCommandHandler addUpdateCategoryCommandHandler,
            RemoveCategoryCommandHandler removeCategoryCommandHandler,
            ICategoryRepository categoryRepository)
            : base(uow)
        {
            _categoryRepository = categoryRepository;
            _addUpdateCategoryCommandHandler = addUpdateCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("v1/category/getbyid/{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            return ApiResponse(GetCategoryCommandResult.Map(_categoryRepository.GetById(id)));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("v1/category/get")]
        public IActionResult Get()
        {
            return ApiResponse(_categoryRepository.Get().Select(GetCategoryCommandResult.Map));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("v1/category/add")]
        public IActionResult Add([FromBody] CategoryCommand command)
        {
            var result = _addUpdateCategoryCommandHandler.Handle(command);
            return ApiResponse(result);
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("v1/category/update")]
        public IActionResult Update([FromBody] CategoryCommand command)
        {
            var result = _addUpdateCategoryCommandHandler.Handle(command);
            return ApiResponse(result);
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("v1/category/delete")]
        public IActionResult Delete([FromQuery] Guid id)
        {
            var result = _removeCategoryCommandHandler.Handle(id);
            return ApiResponse(result);
        }
    }
}
