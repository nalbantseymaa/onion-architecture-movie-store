using MediatR;

namespace MovieApi.Application.Features.Actors.Queries.GetActorCount;

public class GetActorCountRequest : IRequest<GetActorCountResponse>
{
    public bool? IsActive { get; set; }
}