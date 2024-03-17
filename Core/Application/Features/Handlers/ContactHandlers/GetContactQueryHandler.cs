using Application.Features.Results.ContactResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetContactQueryResult
            {
                Email = x.Email,
                Id = x.Id,
                Message = x.Message,
                Name = x.Name,
                Subject = x.Subject,
                SendDate = x.SendDate,
            }).ToList();
        }
    }
}
