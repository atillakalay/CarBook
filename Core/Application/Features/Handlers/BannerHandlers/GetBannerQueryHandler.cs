using Application.Features.Results.BannerResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBannerQueryResult
            {
                Id = x.Id,
                Description = x.Description,
                Title = x.Title,
                VideoDescription = x.VideoDescription,
                VideoUrl = x.VideoUrl
            }).ToList();
        }
    }
}
