﻿using Application.Features.Commands.CategoryCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCategoryCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            values.Name = command.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
