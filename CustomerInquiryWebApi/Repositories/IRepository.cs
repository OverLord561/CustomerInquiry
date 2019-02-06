using AutoMapper;
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

        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> All();

        Task<List<TEntity>> AllAsync();

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
       
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        TProjection SingleOrDefault<TProjection>(Expression<Func<TEntity, bool>> predicate, object parameters = null);
        Task<TProjection> SingleOrDefaultAsync<TProjection>(Expression<Func<TEntity, bool>> predicate, IConfigurationProvider configuration = null);
    }
}
