using FluentValidation;
using Trainer.Profile.Application.Contracts.Ports.Registration.Models;

namespace Trainer.Profile.Application.Validations.Registrations;

public class TrainerRegistrationRequestValidator : AbstractValidator<TrainerRegistrationRequestModel>
{
    public TrainerRegistrationRequestValidator()
    {
        RuleFor(x => x.Email).NotNull().NotEmpty()
            .EmailAddress();
        RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(3);
    }
}