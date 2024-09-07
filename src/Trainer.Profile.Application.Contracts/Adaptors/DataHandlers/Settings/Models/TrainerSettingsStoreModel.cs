namespace Trainer.Profile.Application.Contracts.Adaptors.DataHandlers.Settings.Models;

public class TrainerSettingsStoreModel
{
    public required int ClientCount { get; set; }
    public required Guid TrainerId { get; set; }
}