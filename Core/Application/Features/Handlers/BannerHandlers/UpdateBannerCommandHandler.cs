using Application.Features.Commands.BannerCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            values.Description = command.Description;
            values.VideoDescription = command.VideoDescription;
            values.VideoUrl = command.VideoUrl;
            values.Title = command.Title;
            await _repository.UpdateAsync(values);
        }
    }
}
