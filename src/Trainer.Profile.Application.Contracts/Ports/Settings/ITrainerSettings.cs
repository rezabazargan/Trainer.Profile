using Trainer.Profile.Application.Contracts.Ports.Settings.Models;

namespace Trainer.Profile.Application.Contracts.Ports.Settings;

public interface ITrainerSettings
{
    Task<TrainerSettingsModel> CreateSettingsAsync(Guid trainerId, CancellationToken cancellationToken);
}