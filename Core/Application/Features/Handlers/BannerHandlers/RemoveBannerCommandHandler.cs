using Application.Features.Commands.BannerCommands;
using Application.Interfaces;
using Domain.Entities;


namespace Application.Features.Handlers.BannerHandlers
{
    public class RemoveBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;
        public RemoveBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBannerCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
