namespace Trainer.Profile.Application.Contracts.Adaptors.Communication.Registration.Models;

public class UserRegistrationResponseModel : UserRegistrationModel
{
    public required string UserId { get; set; }
}