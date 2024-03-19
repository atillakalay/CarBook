using Application.Features.Mediator.Results.FooterAddressResults;
using MediatR;

namespace Application.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressQuery : IRequest<List<GetFooterAddressQueryResult>>
    {
    }
}
