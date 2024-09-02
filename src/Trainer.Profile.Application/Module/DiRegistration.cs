using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Trainer.Profile.Application.Contracts.Ports.Registration;
using Trainer.Profile.Application.Services.Registration;
using Trainer.Profile.Application.Validations.Registrations;

namespace Trainer.Profile.Application.Module;

public static class DiRegistration
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services,
        Action<ApplicationConfig> configBuilder)
    {
        services.Configure(configBuilder);

        services.AddTransient<ITrainerRegistration, TrainerRegistration>();

        services.AddValidatorsFromAssemblyContaining<TrainerRegistrationRequestValidator>(ServiceLifetime.Scoped);

        return services;
    }
}