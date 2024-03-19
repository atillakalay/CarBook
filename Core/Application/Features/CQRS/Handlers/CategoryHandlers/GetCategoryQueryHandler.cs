using Application.Features.Results.CategoryResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCategoryQueryResult
            {
                Id = x.CategoryId,
                Name = x.Name
            }).ToList();
        }
    }
}
