using Trainer.Profile.Application.Contracts.Adaptors.DataHandlers.Registration.Models;

namespace Trainer.Profile.Application.Contracts.Adaptors.DataHandlers.Registration;

public interface IRegistrationDataHandler
{
    Task<TrainerStoreResponseModel> StoreAsync(TrainerStoreRequestModel request, CancellationToken cancellationToken);
}