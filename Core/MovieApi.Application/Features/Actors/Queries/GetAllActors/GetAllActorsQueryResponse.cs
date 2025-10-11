using MovieApi.Application.DTOs;

namespace MovieApi.Application.Features.Actors.Queries.GetAllActors;

public class GetAllActorsQueryResponse
{
    public IList<ActorDto>? Actors { get; set; }

}