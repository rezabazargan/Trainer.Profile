using Trainer.Profile.Application.Contracts.Ports.Registration.Models;

namespace Trainer.Profile.Application.Contracts.Ports.Registration;

public interface ITrainerRegistration
{
    Task<TrainerRegistrationResponseModel> RegisterTrainerAsync(TrainerRegistrationRequestModel request,
        CancellationToken cancellationToken);
}