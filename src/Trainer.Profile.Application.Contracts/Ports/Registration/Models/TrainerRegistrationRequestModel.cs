namespace Trainer.Profile.Application.Contracts.Ports.Registration.Models;

public class TrainerRegistrationRequestModel : TrainerRegistrationModel
{
    public required string Password { get; set; }
}