using Trainer.Profile.Application.Contracts.Ports.Registration;
using Trainer.Profile.Application.Contracts.Ports.Registration.Models;

namespace Trainer.Profile.Api.APIs.Registration;

public static class TrainerRegistrationApi
{
    public static void SetTrainerRoutes(this WebApplication app)
    {
        app.MapGroup("trainer")
            .Register()
            .WithOpenApi();
    }

    private static RouteGroupBuilder Register(this RouteGroupBuilder group)
    {
        group.MapPost("/",
            async (TrainerRegistrationRequestModel payload, ITrainerRegistration service,
                    CancellationToken cancellationToken) =>
                await service.RegisterTrainerAsync(payload, cancellationToken));
        return group;
    }
}