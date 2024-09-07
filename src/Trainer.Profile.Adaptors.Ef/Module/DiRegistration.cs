using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Trainer.Profile.Adaptors.Ef.Entities;
using Trainer.Profile.Adaptors.Ef.Implementations;
using Trainer.Profile.Adaptors.Ef.Repositories;
using Trainer.Profile.Application.Contracts.Adaptors.DataHandlers;
using Trainer.Profile.Application.Contracts.Adaptors.DataHandlers.Registration;
using Trainer.Profile.Application.Contracts.Adaptors.DataHandlers.Settings;

namespace Trainer.Profile.Adaptors.Ef.Module;

public static class DiRegistration
{
    public static IServiceCollection RegisterEfAdaptor(this IServiceCollection services,
        Action<EfConfigurationSettings> config)
    {
        var settings = new EfConfigurationSettings();
        config(settings);
        services.AddDbContext<TrainerProfileDbContext>(s =>
            s.UseSqlServer(settings.ConnectionString ??
                           throw new ArgumentNullException(settings.ConnectionString)));


        services.AddScoped<IUnitOfWork, UnitOfWork>();

        //Repositories
        services.AddScoped<IRepository<TrainerEntity, Guid>, TrainerRepository>();
        services.AddScoped<IRepository<TrainerSettingsEntity, Guid>, TrainerSettingsRepository>();

        //Adaptor Implementations
        services.AddScoped<ITrainerRegistrationDataHandler, TrainerRegistrationDataHandler>();
        services.AddScoped<ITrainerSettingsDataHandler, TrainerSettingsDataHandler>();

        return services;
    }
}