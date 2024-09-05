using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Trainer.Profile.Adaptors.Ef.Entities;

namespace Trainer.Profile.Adaptors.Ef.Repositories;

internal abstract class RepositoryBase<T, TKey>(TrainerProfileDbContext dbContext) : IRepository<T, TKey>
    where T : EntityBase<TKey>
{
    public ValueTask<T?> FindAsync(TKey id, CancellationToken cancellationToken)
    {
        return dbContext.FindAsync<T>(id, cancellationToken);
    }

    public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return dbContext.Set<T>().Where(predicate).Take(200)
            .ToListAsync(cancellationToken);
    }

    public async ValueTask<T> InsertAsync(T entity, CancellationToken cancellationToken)
    {
        return (await dbContext.AddAsync(entity, cancellationToken)).Entity;
    }
}