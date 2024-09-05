using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Trainer.Profile.Adaptors.Ef.Entities;
using Trainer.Profile.Adaptors.Ef.Implementations;
using Trainer.Profile.Adaptors.Ef.Repositories;
using Trainer.Profile.Application.Contracts.Adaptors.DataHandlers;
using Trainer.Profile.Application.Contracts.Adaptors.DataHandlers.Registration;

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

        //Adaptor Implementations
        services.AddScoped<ITrainerRegistrationDataHandler, TrainerRegistrationDataHandler>();

        return services;
    }
}