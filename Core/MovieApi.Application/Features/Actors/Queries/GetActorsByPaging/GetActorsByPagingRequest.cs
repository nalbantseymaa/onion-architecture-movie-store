using MediatR;

namespace MovieApi.Application.Features.Actors.Queries.GetActorsByPaging;

public class GetActorsByPagingRequest : IRequest<GetActorsByPagingResponse>
{
    public int? CurrentPage { get; set; } = 1;
    public int? PageSize { get; set; } = 3;
}