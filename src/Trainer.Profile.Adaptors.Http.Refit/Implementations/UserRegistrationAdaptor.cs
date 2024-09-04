using Trainer.Profile.Adaptors.Http.Refit.Apis;
using Trainer.Profile.Adaptors.Http.Refit.Model;
using Trainer.Profile.Application.Contracts.Adaptors.Communication.Registration;
using Trainer.Profile.Application.Contracts.Adaptors.Communication.Registration.Models;

namespace Trainer.Profile.Adaptors.Http.Refit.Implementations;

internal class UserRegistrationAdaptor(IIdentityApi identityApi) : IUserRegistrationAdaptor
{
    public async Task<UserRegistrationResponseModel> RegisterUserAsync(UserRegistrationRequestModel request,
        CancellationToken cancellationToken)
    {
        var result = await identityApi.RegisterAsync(new RegisterRequestModel()
        {
            Email = request.Username,
            Name = request.Name,
            Password = request.Password
        }, cancellationToken);

        return new UserRegistrationResponseModel()
        {
            UserId = result,
            Username = request.Username
        };
    }
}