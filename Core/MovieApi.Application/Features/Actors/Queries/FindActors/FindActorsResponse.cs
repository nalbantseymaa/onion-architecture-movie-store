using MovieApi.Application.DTOs;

namespace MovieApi.Application.Features.Actors.Queries.FindActors;

public class FindActorsResponse
{
    public ActorDto Actor { get; set; }
}