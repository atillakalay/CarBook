using Application.Features.Commands.CategoryCommands;
using Application.Features.Handlers.CategoryHandlers;
using Application.Features.Queries.CategoryQueries;
using Microsoft.AspNetCore.Mvc;

namespace CategoryBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

        public CategoriesController(CreateCategoryCommandHandler createCategoryCommandHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler)
        {
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
        }

        [HttpGet("CategoryList")]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _getCategoryQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var values = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handle(command);
            return Ok("Category bilgisi başarıyla eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCategory(RemoveCategoryCommand command)
        {
            await _removeCategoryCommandHandler.Handle(command);
            return Ok("Category bilgisi başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _updateCategoryCommandHandler.Handle(command);
            return Ok("Category bilgisi başarıyla güncellendi.");
        }
    }
}
