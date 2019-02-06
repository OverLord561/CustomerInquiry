using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        bool Add(TEntity entity);

        Task<bool> AddAsync(TEntity entity);

        bool AddRange(IEnumerable<TEntity> enteties);

        Task<bool> AddRangeAsync(IEnumerable<TEntity> enteties);

        bool Remove(TEntity entity);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> All();

        Task<List<TEntity>> AllAsync();
    }
}
