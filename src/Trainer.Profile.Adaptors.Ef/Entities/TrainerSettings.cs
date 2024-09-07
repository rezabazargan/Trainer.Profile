using System.ComponentModel.DataAnnotations.Schema;

namespace Trainer.Profile.Adaptors.Ef.Entities;

[Table("TrainerSettings")]
public class TrainerSettingsEntity : EntityBase<Guid>
{
    public Guid TrainerId { get; set; }

    [ForeignKey(nameof(TrainerId))] public TrainerEntity? Trainer { get; set; }

    public required int ClientCount { get; set; }
}