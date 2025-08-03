using FluentValidation;
using System.Globalization;

using backend.Dtos.Game;
namespace FactoryPulse_Core.Users.Validators;

internal sealed class UpdateGameValidator : AbstractValidator<UpdateGameDto>
{
    public UpdateGameValidator()
    {
        RuleFor(x => x.GameId)
            .NotEmpty().WithMessage("GameId is required.")
            .NotEqual(0).WithMessage("Incorrect GameId.");

        RuleFor(x => x.GameName)
            .NotEmpty().WithMessage("GameName is required.");
    }
}