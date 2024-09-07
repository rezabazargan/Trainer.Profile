using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainer.Profile.Adaptors.Ef.Entities;

[Table("Trainer")]
public class TrainerEntity : EntityBase<Guid>
{
    public required string Name { get; set; }
    public required string UserId { get; set; }

    [EmailAddress] [MaxLength(50)] public required string Email { get; set; }

    [Phone] [MaxLength(15)] public string? PhoneNumber { get; set; }
    public DateOnly? BirthDate { get; set; }

    public TrainerSettingsEntity? TrainerSettings { get; set; }

    public Guid? TrainerSettingsId { get; set; }
}