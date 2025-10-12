using FluentValidation;

namespace MovieApi.Application.Features.Actors.Commands.DeleteActor;

public class DeleteActorCommandValidator : AbstractValidator<DeleteActorRequest>
{
    public DeleteActorCommandValidator()
    {
        RuleFor(x => x.ActorId).GreaterThan(0).WithMessage("Id must be greater than zero.");
    }
}