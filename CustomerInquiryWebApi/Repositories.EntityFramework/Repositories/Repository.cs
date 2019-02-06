using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Repositories.EntityFramework.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, new()
    {
        protected readonly DbContext _context;

        protected virtual IQueryable<TEntity> Include()
        {
            return _context.Set<TEntity>();
        }

        public Repository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public virtual bool Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<TEntity>().Add(entity);
            return _context.SaveChanges() > 0;
        }

        public virtual async Task<bool> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _context.Set<TEntity>().AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual bool AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            return _context.SaveChanges() > 0;
        }

        public virtual async Task<bool> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual IEnumerable<TEntity> All()
        {
            return Include().ToList();
        }

        public virtual async Task<List<TEntity>> AllAsync()
        {
            return await Include().ToListAsync();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Include().Where(predicate).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Include().Where(predicate).ToListAsync();
        }

        public virtual bool Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Include().SingleOrDefault(predicate);
        }

        public virtual async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Include().SingleOrDefaultAsync(predicate);
        }

        public virtual TProjection SingleOrDefault<TProjection>(Expression<Func<TEntity, bool>> predicate, object parameters = null)
        {
            IQueryable<TProjection> projection;
            var query = _context.Set<TEntity>().Where(predicate);

            if (parameters != null)
            {
                projection = query.ProjectTo<TProjection>(parameters);
            }
            else
            {
                projection = query.ProjectTo<TProjection>();
            }

            return projection.SingleOrDefault();
        }

        public virtual async Task<TProjection> SingleOrDefaultAsync<TProjection>(Expression<Func<TEntity, bool>> predicate, object parameters = null)
        {
            IQueryable<TProjection> projection;
            var query = _context.Set<TEntity>().Where(predicate);

            if (parameters != null)
            {
                projection = query.ProjectTo<TProjection>(parameters as IConfigurationProvider);
            }
            else
            {
                projection = query.ProjectTo<TProjection>();
            }

            return await projection.SingleOrDefaultAsync();

        }
    }
}
