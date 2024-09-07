namespace Trainer.Profile.Application.Contracts.Ports.Settings.Models;

public class TrainerSettingsModel
{
    public required Guid TrainerId { get; set; }
    public int? ClientAmount { get; set; }
}