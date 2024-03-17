using Application.Features.Queries.ContactQueries;
using Application.Features.Results.ContactResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;
        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetContactByIdQueryResult
            {
                Email = values.Email,
                Id = values.Id,
                Message = values.Message,
                Name = values.Name,
                SendDate = values.SendDate,
                Subject = values.Subject,
            };
        }
    }
}
