namespace Trainer.Profile.Application.Contracts.Adaptors.Communication.Registration.Models;

public class UserRegistrationRequestModel : UserRegistrationModel
{
    public required string Password { get; set; }
    public required string Name { get; set; }
}