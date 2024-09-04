using Refit;
using Trainer.Profile.Adaptors.Http.Refit.Model;

namespace Trainer.Profile.Adaptors.Http.Refit.Apis;

internal interface IIdentityApi
{
    [Post("/register")]
    Task<string> RegisterAsync(RegisterRequestModel model, CancellationToken cancellationToken);
}