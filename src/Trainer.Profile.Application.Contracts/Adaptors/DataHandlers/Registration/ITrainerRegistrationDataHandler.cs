using Trainer.Profile.Application.Contracts.Adaptors.DataHandlers.Registration.Models;

namespace Trainer.Profile.Application.Contracts.Adaptors.DataHandlers.Registration;

public interface ITrainerRegistrationDataHandler
{
    Task<TrainerStoreResponseModel> StoreAsync(TrainerStoreRequestModel request, CancellationToken cancellationToken);
}