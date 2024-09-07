using Microsoft.EntityFrameworkCore.Storage;
using Trainer.Profile.Application.Contracts.Adaptors.DataHandlers;

namespace Trainer.Profile.Adaptors.Ef.Implementations;

internal class UnitOfWork(TrainerProfileDbContext dbContext) : IUnitOfWork
{
    private IDbContextTransaction? _transaction;

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task BeginTransactionAsync(CancellationToken cancellationToken)
    {
        _transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public Task CommitAsync(CancellationToken cancellationToken)
    {
        return _transaction != null ? _transaction.CommitAsync(cancellationToken) : Task.CompletedTask;
    }

    public Task RollbackAsync(CancellationToken cancellationToken)
    {
        return _transaction != null ? _transaction.RollbackAsync(cancellationToken) : Task.CompletedTask;
    }
}