using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
        return services;
    }
}