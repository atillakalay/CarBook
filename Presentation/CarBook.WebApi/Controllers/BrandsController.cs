using Application.Features.Commands.BrandCommands;
using Application.Features.Handlers.BrandHandlers;
using Application.Features.Queries.BrandQueries;
using Microsoft.AspNetCore.Mvc;

namespace BrandBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;

        public BrandsController(CreateBrandCommandHandler createBrandCommandHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, GetBrandQueryHandler getBrandQueryHandler, UpdateBrandCommandHandler updateBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler)
        {
            _createBrandCommandHandler = createBrandCommandHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _getBrandQueryHandler = getBrandQueryHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
        }

        [HttpGet("BrandList")]
        public async Task<IActionResult> BrandList()
        {
            var values = await _getBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("GetBrand")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var values = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
            await _createBrandCommandHandler.Handle(command);
            return Ok("Brand bilgisi başarıyla eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBrand(RemoveBrandCommand command)
        {
            await _removeBrandCommandHandler.Handle(command);
            return Ok("Brand bilgisi başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            await _updateBrandCommandHandler.Handle(command);
            return Ok("Brand bilgisi başarıyla güncellendi.");
        }
    }
}
