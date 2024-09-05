using FluentValidation;
using Trainer.Profile.Application.Contracts.Adaptors.Communication.Registration;
using Trainer.Profile.Application.Contracts.Adaptors.Communication.Registration.Models;
using Trainer.Profile.Application.Contracts.Adaptors.DataHandlers;
using Trainer.Profile.Application.Contracts.Adaptors.DataHandlers.Registration;
using Trainer.Profile.Application.Contracts.Adaptors.DataHandlers.Registration.Models;
using Trainer.Profile.Application.Contracts.Ports.Registration;
using Trainer.Profile.Application.Contracts.Ports.Registration.Models;
using ValidationException = Trainer.Profile.Application.Contracts.Exceptions.ValidationException;

namespace Trainer.Profile.Application.Services.Registration;

internal class TrainerRegistration(
    IValidator<TrainerRegistrationRequestModel> validator,
    IUserRegistrationAdaptor registrationAdaptor,
    ITrainerRegistrationDataHandler registrationDataHandler,
    IUnitOfWork unitOfWork)
    : ITrainerRegistration
{
    public async Task<TrainerRegistrationResponseModel> RegisterTrainerAsync(TrainerRegistrationRequestModel request,
        CancellationToken cancellationToken)
    {
        // Validation
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(
                validationResult.Errors.ToDictionary(e => e.PropertyName, e => e.ErrorMessage));
        }

        var userRegistrationResult = await registrationAdaptor.RegisterUserAsync(new UserRegistrationRequestModel()
        {
            Password = request.Password,
            Username = request.Email,
            Name = request.Name
        }, cancellationToken);

        var dbResult = await registrationDataHandler.StoreAsync(new TrainerStoreRequestModel()
        {
            Name = request.Name,
            UserId = userRegistrationResult.UserId,
            Email = request.Email,
            PhoneNumber = request.Phone
        }, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new TrainerRegistrationResponseModel()
        {
            Name = request.Name,
            Id = dbResult.Id,
            Email = request.Email,
            Phone = request.Phone
        };
    }
}