using Trainer.Profile.Application.Contracts.Adaptors.DataHandlers;
using Trainer.Profile.Application.Contracts.Adaptors.DataHandlers.Settings;
using Trainer.Profile.Application.Contracts.Adaptors.DataHandlers.Settings.Models;
using Trainer.Profile.Application.Contracts.Ports.Settings;
using Trainer.Profile.Application.Contracts.Ports.Settings.Models;

namespace Trainer.Profile.Application.Services.Settings;

internal class TrainerSettingsService(
    ITrainerSettingsDataHandler trainerSettingsDataHandler,
    IUnitOfWork unitOfWork) : ITrainerSettings
{
    public async Task<TrainerSettingsModel> CreateSettingsAsync(Guid trainerId, CancellationToken cancellationToken)
    {
        var result =
            await trainerSettingsDataHandler.StoreAsync(new TrainerSettingsStoreRequestModel()
            {
                ClientCount = 3,
                TrainerId = trainerId
            }, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new TrainerSettingsModel()
        {
            TrainerId = trainerId,
            ClientAmount = result.ClientCount
        };
    }
}