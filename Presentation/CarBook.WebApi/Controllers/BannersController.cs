using Application.Features.Commands.BannerCommands;
using Application.Features.Handlers.BannerHandlers;
using Application.Features.Queries.BannerQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly CreateBannerCommandHandler _createBannerCommandHandler;
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
        private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;

        public BannersController(CreateBannerCommandHandler createBannerCommandHandler, GetBannerByIdQueryHandler getBannerByIdQueryHandler, GetBannerQueryHandler getBannerQueryHandler, UpdateBannerCommandHandler updateBannerCommandHandler, RemoveBannerCommandHandler removeBannerCommandHandler)
        {
            _createBannerCommandHandler = createBannerCommandHandler;
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            _getBannerQueryHandler = getBannerQueryHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
            _removeBannerCommandHandler = removeBannerCommandHandler;
        }

        [HttpGet("BannerList")]
        public async Task<IActionResult> BannerList()
        {
            var values = await _getBannerQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("GetBanner")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var values = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _createBannerCommandHandler.Handle(command);
            return Ok("Banner bilgisi başarıyla eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBanner(RemoveBannerCommand command)
        {
            await _removeBannerCommandHandler.Handle(command);
            return Ok("Banner bilgisi başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _updateBannerCommandHandler.Handle(command);
            return Ok("Banner bilgisi başarıyla güncellendi.");
        }
    }
}
