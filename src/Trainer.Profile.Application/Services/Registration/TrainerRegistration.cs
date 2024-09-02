using Trainer.Profile.Application.Contracts.Adaptors.Communication.Registration.Models;
using Trainer.Profile.Application.Contracts.Adaptors.DataHandlers.Registration.Models;
using Trainer.Profile.Application.Contracts.Ports.Registration;
using Trainer.Profile.Application.Contracts.Ports.Registration.Models;

namespace Trainer.Profile.Application.Services.Registration;

internal class TrainerRegistration()
    : ITrainerRegistration
{
    public async Task<TrainerRegistrationResponseModel> RegisterTrainerAsync(TrainerRegistrationRequestModel request,
        CancellationToken cancellationToken)
    {
        // Validation

        // Register User to the IdentityService
        // Store to the DB
        // response
        //var userRegistrationResult = await userRegistrationAdaptor.RegisterUserAsync(new UserRegistrationRequestModel()
        //{
        //    Password = request.Password,
        //    Username = request.Email ?? request.Phone
        //}, cancellationToken);

        //var dbResult = await registrationDataHandler.StoreAsync(new TrainerStoreRequestModel()
        //{
        //    Name = request.Name,
        //    UserId = userRegistrationResult.UserId,
        //    Email = request.Email,
        //    PhoneNumber = request.Phone
        //}, cancellationToken);

        return new TrainerRegistrationResponseModel()
        {
            Name = request.Name,
            Id = string.Empty,
            Email = request.Email,
            Phone = request.Phone
        };
    }
}