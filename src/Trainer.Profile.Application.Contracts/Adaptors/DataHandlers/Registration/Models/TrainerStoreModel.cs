namespace Trainer.Profile.Application.Contracts.Adaptors.DataHandlers.Registration.Models;

public abstract class TrainerStoreModel
{
    public required string Name { get; set; }
    public string? Description { get; set; }

    public required string UserId { get; set; }
    public string? PhoneNumber { get; set; }
    public string?  Email { get; set; }

}