using Application.Features.Commands.BrandCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBrandCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            values.Name = command.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
