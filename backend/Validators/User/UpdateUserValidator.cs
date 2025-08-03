using FluentValidation;
using System.Globalization;

using backend.Dtos.User;
namespace FactoryPulse_Core.Users.Validators;

internal sealed class UpdateUserValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .NotEqual(0).WithMessage("Incorrect UserId.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("FirstName is required.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("LastName is required.");

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Username is required.")
            .MinimumLength(3).WithMessage("Username must be at least 3 characters long.");

        RuleFor(x => x.UserEmail)
            .NotEmpty().WithMessage("UserEmail is required.")
            .EmailAddress().WithMessage("UserEmail must be a valid email address.");

        RuleFor(x => x.Nic)
            .NotEmpty().WithMessage("Nic is required.");

        RuleFor(x => x.Dob)
            .NotEmpty().WithMessage("Dob is required.");

        RuleFor(x => x.ContactNo)
            .NotEmpty().WithMessage("ContactNo is required.");
    }
}