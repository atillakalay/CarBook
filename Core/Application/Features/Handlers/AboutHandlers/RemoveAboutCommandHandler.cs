using Application.Features.Commands.AboutCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Handlers.AboutHandlers
{
    public class RemoveAboutCommandHandler
    {
        private readonly IRepository<About> _repository;
        public RemoveAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAboutCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
