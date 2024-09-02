namespace Trainer.Profile.Application.Contracts.Ports.Registration.Models;

public class TrainerRegistrationModel
{
    public required string Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }

}