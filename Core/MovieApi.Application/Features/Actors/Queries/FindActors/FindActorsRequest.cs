using MediatR;

namespace MovieApi.Application.Features.Actors.Queries.FindActors;

public class FindActorsRequest : IRequest<IList<FindActorsResponse>>
{
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }

}