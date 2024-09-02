using Trainer.Profile.Application.Contracts.Adaptors.Communication.Registration.Models;

namespace Trainer.Profile.Application.Contracts.Adaptors.Communication.Registration;

public interface IUserRegistrationAdaptor
{
    Task<UserRegistrationResponseModel> RegisterUserAsync(UserRegistrationRequestModel request, CancellationToken cancellationToken);
}