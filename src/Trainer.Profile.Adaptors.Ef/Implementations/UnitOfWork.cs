using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainer.Profile.Application.Contracts.Adaptors.DataHandlers;

namespace Trainer.Profile.Adaptors.Ef.Implementations
{
    internal class UnitOfWork(TrainerProfileDbContext dbContext) : IUnitOfWork
    {
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}