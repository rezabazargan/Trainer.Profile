using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trainer.Profile.Adaptors.Http.Refit.Apis;
using Refit;
using Trainer.Profile.Adaptors.Http.Refit.Implementations;
using Trainer.Profile.Application.Contracts.Adaptors.Communication.Registration;

namespace Trainer.Profile.Adaptors.Http.Refit.Module;

public static class DiRegistration
{
    public static IServiceCollection RegisterRefitAdaptor(this IServiceCollection services,
        IConfigurationManager config)
    {
        var settings = config.Get<RefitConfigurationSettings>();

        if (settings?.Services == null)
            throw new ArgumentNullException(nameof(settings.Services));

        services.AddRefitClient<IIdentityApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(settings.Services.Identity.BaseUrl));

        services.AddScoped<IUserRegistrationAdaptor, UserRegistrationAdaptor>();

        return services;
    }
}