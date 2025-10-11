using MediatR;

namespace MovieApi.Application.Features.Actors.Commands.AddActors;

public class AddActorsRequest : IRequest<int>
{
    public IList<AddActorItem> Actors { get; set; } = new List<AddActorItem>();
}

public class AddActorItem
{
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
}