using MediatR;

namespace MovieApi.Application.Features.Actors.Commands.DeleteActor;

public class DeleteActorRequest : IRequest<int>
{
    public long ActorId { get; set; }
}