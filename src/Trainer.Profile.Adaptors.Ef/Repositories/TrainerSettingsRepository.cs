using Trainer.Profile.Adaptors.Ef.Entities;

namespace Trainer.Profile.Adaptors.Ef.Repositories;

internal class TrainerSettingsRepository(TrainerProfileDbContext dbContext)
    : RepositoryBase<TrainerSettingsEntity, Guid>(dbContext)
{
}