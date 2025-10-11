using MediatR;

namespace MovieApi.Application.Features.Actors.Commands.CreateActor;

public class CreateActorRequest : IRequest<int>
{
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }

}