using FluentValidation;
using MovieApi.Application.Features.Actors.Commands.AddActors;

namespace MovieApi.Application.Features.Actors.Commands.AddActorsActor;

public class AddActorsCommandValidator : AbstractValidator<AddActorsRequest>
{
    public AddActorsCommandValidator()
    {
        RuleFor(x => x.Actors).NotEmpty().WithMessage("At least one actor must be added.");
    }
}