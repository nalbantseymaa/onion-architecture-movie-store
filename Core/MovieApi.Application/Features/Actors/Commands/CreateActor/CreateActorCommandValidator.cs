using FluentValidation;

namespace MovieApi.Application.Features.Actors.Commands.CreateActor;

public class CreateActorCommandValidator : AbstractValidator<CreateActorRequest>
{
    public CreateActorCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().
        WithName("FirstName").
        WithMessage("FirstName is required.")
                                 .MaximumLength(50).WithMessage("FirstName cannot exceed 50 characters.");

        RuleFor(x => x.LastName).NotEmpty()
        .WithName("LastName").WithMessage("LastName is required.")
                                .MaximumLength(50).WithMessage("LastName cannot exceed 50 characters.");

    }
}