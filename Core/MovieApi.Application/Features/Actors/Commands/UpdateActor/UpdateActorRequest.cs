using System.Text.Json.Serialization;
using MediatR;

namespace MovieApi.Application.Features.Actors.Commands.UpdateActor;

public class UpdateActorRequest : IRequest<int>
{
    [JsonIgnore]
    public long ActorId { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }

}