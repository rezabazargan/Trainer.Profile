using Trainer.Profile.Application.Contracts.Ports.Registration.Models;

namespace Trainer.Profile.Application.Contracts.Ports.Registration;

public interface IUserRegistration
{
    Task<TrainerRegistrationResponseModel> RegisterTrainerAsync(TrainerRegistrationRequestModel request,
        CancellationToken cancellationToken);
}