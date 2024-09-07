using Trainer.Profile.Application.Contracts.Adaptors.DataHandlers.Settings.Models;

namespace Trainer.Profile.Application.Contracts.Adaptors.DataHandlers.Settings;

public interface ITrainerSettingsDataHandler
{
    Task<TrainerSettingsStoreResponseModel> StoreAsync(TrainerSettingsStoreRequestModel request,
        CancellationToken cancellationToken);
}