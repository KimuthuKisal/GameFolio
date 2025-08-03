using FluentValidation;
using System.Globalization;

using backend.Dtos.Game;
namespace FactoryPulse_Core.Users.Validators;

internal sealed class CreateGameValidator : AbstractValidator<CreateGameDto>
{
    public CreateGameValidator()
    {
        RuleFor(x => x.GameName)
            .NotEmpty().WithMessage("GameName is required.");
    }
}