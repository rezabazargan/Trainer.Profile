using System.Linq.Expressions;
using Trainer.Profile.Adaptors.Ef.Entities;

namespace Trainer.Profile.Adaptors.Ef.Repositories;

internal interface IRepository<T, in TKey> where T : EntityBase<TKey>
{
    ValueTask<T?> FindAsync(TKey id, CancellationToken cancellationToken);
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);

    ValueTask<T> InsertAsync(T entity, CancellationToken cancellationToken);
}