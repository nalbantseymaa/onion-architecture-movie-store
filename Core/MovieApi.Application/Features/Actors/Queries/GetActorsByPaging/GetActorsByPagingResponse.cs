using MovieApi.Application.DTOs;

namespace MovieApi.Application.Features.Actors.Queries.GetActorsByPaging;

public class GetActorsByPagingResponse
{
    public IList<ActorDto>? Actors { get; set; }

}