using Felix.WebService.Common.Exceptions.Repository;
using Felix.WebService.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.DAL.Repositories
{
    public class GenericRepository<TContext, TEntity> : IGenericRepository<TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        protected readonly TContext _dbContext;
        protected readonly DbSet<TEntity> _table;

        public GenericRepository(TContext dbContext)
        {
            _dbContext = dbContext;
            _table = dbContext.Set<TEntity>();
        }

        public bool Any(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _table.Any() : _table.Any(filter);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            return filter == null ? await _table.AnyAsync(cancellationToken) : await _table.AnyAsync(filter, cancellationToken);
        }

        public int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _table.Count() : _table.Count(filter);
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            return filter == null ? _table.CountAsync(cancellationToken) : _table.CountAsync(filter, cancellationToken);
        }

        public TEntity Create(TEntity entity)
        {
            return _table.Add(entity).Entity;
        }

        public void CreateRange(IEnumerable<TEntity> entities)
        {
            _table.AddRange(entities);
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _table.AddRangeAsync(entities, cancellationToken);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = GetDefaultQuery(filter, include, orderBy);
            return query.FirstOrDefault();
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = GetDefaultQuery(filter, include, orderBy);
            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = GetDefaultQuery(filter, include, orderBy);
            return query.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = GetDefaultQuery(filter, include, orderBy);
            return await query.ToListAsync(cancellationToken);
        }

        public TEntity GetById(int id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            var filter = GetIdEqualQuery(id);

            return SingleOrDefault(
                filter: filter,
                include: include,
                orderBy: orderBy
                );
        }

        public async Task<TEntity> GetByIdAsync(int id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, CancellationToken cancellationToken = default)
        {
            var filter = GetIdEqualQuery(id);

            return await SingleOrDefaultAsync(
                filter: filter,
                include: include,
                orderBy: orderBy,
                cancellationToken: cancellationToken
                );
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = GetDefaultQuery(filter, include, orderBy);
            return query.SingleOrDefault();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = GetDefaultQuery(filter, include, orderBy);
            return await query.SingleOrDefaultAsync(cancellationToken);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbContext.UpdateRange(entities);
        }

        private IQueryable<TEntity> GetDefaultQuery(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
            )
        {
            IQueryable<TEntity> query = _table;
            if (filter != null)
                query = query.Where(filter);

            if (include != null)
                query = include(query);

            if (orderBy != null)
                return orderBy(query);

            return query;

        }

        private string GetIdPropertyName()
        {
            IReadOnlyList<IProperty> properties = _dbContext.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties;

            if (properties == null && !properties.Any())
                throw new PrimaryKeyNotFoundException();

            if (properties.Count == 1)
            {
                return properties.Single().Name;
            }
            else
            {
                throw new CompositeKeyFoundException();
            }
        }

        private Expression<Func<TEntity, bool>> GetIdEqualQuery(int id)
        {
            return x => EF.Property<int>(x, GetIdPropertyName()) == id;
        }
    }
}
