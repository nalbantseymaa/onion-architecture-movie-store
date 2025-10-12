using FluentValidation;

namespace MovieApi.Application.Features.Actors.Commands.UpdateActor;

public class UpdateActorCommandValidator : AbstractValidator<UpdateActorRequest>
{
    public UpdateActorCommandValidator()
    {
        RuleFor(x => x.ActorId).GreaterThan(0).WithMessage("Id must be greater than zero.");

        RuleFor(x => x.FirstName).NotEmpty().
        WithName("FirstName").
        WithMessage("FirstName is required.")
                                 .MaximumLength(50).WithMessage("FirstName cannot exceed 50 characters.");

        RuleFor(x => x.LastName).NotEmpty()
        .WithName("LastName").WithMessage("LastName is required.")
                                .MaximumLength(50).WithMessage("LastName cannot exceed 50 characters.");
    }
}