using Trainer.Profile.Adaptors.Ef.Entities;
using Trainer.Profile.Adaptors.Ef.Repositories;
using Trainer.Profile.Application.Contracts.Adaptors.DataHandlers.Registration;
using Trainer.Profile.Application.Contracts.Adaptors.DataHandlers.Registration.Models;

namespace Trainer.Profile.Adaptors.Ef.Implementations;

internal class TrainerRegistrationDataHandler(IRepository<TrainerEntity, Guid> repository)
    : ITrainerRegistrationDataHandler
{
    public async Task<TrainerStoreResponseModel> StoreAsync(TrainerStoreRequestModel request,
        CancellationToken cancellationToken)
    {
        var result = await repository.InsertAsync(new TrainerEntity()
        {
            Email = request.Email,
            Name = request.Name,
            UserId = request.UserId,
            Id = Guid.NewGuid(),
            PhoneNumber = request.PhoneNumber
        }, cancellationToken);

        return new TrainerStoreResponseModel()
        {
            Name = result.Name,
            UserId = result.UserId,
            Email = result.Email,
            Id = result.Id
        };
    }
}