using Trainer.Profile.Adaptors.Ef.Entities;

namespace Trainer.Profile.Adaptors.Ef.Repositories;

internal class TrainerRepository(TrainerProfileDbContext dbContext)
    : RepositoryBase<TrainerEntity, Guid>(dbContext)
{
}