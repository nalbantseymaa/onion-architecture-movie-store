using MovieApi.Application.DTOs;

namespace MovieApi.Application.Features.Actors.Queries.GetActorByCondition;

public class GetActorByConditionResponse
{
    public ActorDto? Actor { get; set; }
    public IList<MovieDto>? ActedMovies { get; set; }
}