using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Common.Repository.Generics
{
    public abstract class BaseRepository<T> : IRepositoryGenerico<T>
       where T : class
    {
        //CRUD
        protected readonly IDbContext _dbContext;

        protected abstract DbSet<T> DbEntity { get; }

        public BaseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            await DbEntity.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }



        public async Task<IEnumerable<T>> GetAll()
        {
            return await DbEntity.ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual TEntity GetOneOrDefault<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) where TEntity : class
        {
            return GetQueryable(filter, orderBy, includeProperties).FirstOrDefault();
        }

        public virtual IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) where TEntity : class
        {
            return GetQueryable(filter, orderBy, includeProperties).ToList();
        }

        public bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            return GetQueryable(filter).Any();
        }

        public async Task CreateRange<TEntity>(IEnumerable<TEntity> entities, string createdBy = null) where TEntity : class
        {
            _dbContext.Set<TEntity>().AddRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        protected virtual IQueryable<TEntity> GetQueryable<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        public virtual Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            int? nullable = null;
            int? nullable1 = nullable;
            nullable = null;
            return this.GetQueryable<TEntity>(filter, null, null, nullable1, nullable).AnyAsync<TEntity>();
        }

        public virtual async Task<TEntity> GetOneAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class
        {
            int? nullable = null;
            int? nullable1 = nullable;
            nullable = null;
            TEntity tEntity = await this.GetQueryable<TEntity>(filter, null, includeProperties, nullable1, nullable).SingleOrDefaultAsync<TEntity>();
            return tEntity;
        }

        public virtual async Task<T> GetByIdAsync<T>(object id) where T : class
        {
            return await _dbContext.Set<T>().FindAsync(new object[] { id });
        }


        public virtual async Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
        {
            IEnumerable<TEntity> listAsync = await this.GetQueryable<TEntity>(filter, orderBy, includeProperties, skip, take).ToListAsync<TEntity>();
            return listAsync;
        }
    }
}
