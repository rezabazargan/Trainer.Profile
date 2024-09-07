using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainer.Profile.Adaptors.Ef.Entities;
using Trainer.Profile.Adaptors.Ef.Repositories;
using Trainer.Profile.Application.Contracts.Adaptors.DataHandlers.Settings;
using Trainer.Profile.Application.Contracts.Adaptors.DataHandlers.Settings.Models;

namespace Trainer.Profile.Adaptors.Ef.Implementations
{
    internal class TrainerSettingsDataHandler(IRepository<TrainerSettingsEntity, Guid> _repository)
        : ITrainerSettingsDataHandler
    {
        public async Task<TrainerSettingsStoreResponseModel> StoreAsync(TrainerSettingsStoreRequestModel request,
            CancellationToken cancellationToken)
        {
            var entity = await _repository.InsertAsync(new TrainerSettingsEntity()
            {
                ClientCount = request.ClientCount,
                TrainerId = request.TrainerId,
                Id = Guid.NewGuid()
            }, cancellationToken);

            return new TrainerSettingsStoreResponseModel()
            {
                TrainerId = entity.TrainerId,
                ClientCount = entity.ClientCount,
                Id = entity.Id
            };
        }
    }
}