using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Common.Repository.Generics
{
    public class EntityFrameworkReadOnlyRepository<TContext> : IEntityFrameworkReadOnlyRepository
         where TContext : DbContext

    {
        public TContext Context;

        /// <summary>
        /// Constructor
        /// </summary>
        public EntityFrameworkReadOnlyRepository(TContext Context)
        {
            this.Context = Context;
        }

        /// <summary>
        /// Método que genera filtros genericos
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        protected virtual IQueryable<TEntity> GetQueryable<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<TEntity> query = Context.Set<TEntity>();

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

        /// <summary>
        /// Método que genera filtros genericos
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        protected virtual (IQueryable<TEntity>, int) GetQueryableTuple<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<TEntity> query = Context.Set<TEntity>();
            int count = 0;
            if (filter != null)
            {
                query = query.Where(filter);
                count = query.Count();
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
            if (count > 9)
            {
                if (skip.HasValue)
                {
                    query = query.Skip(skip.Value);
                }

                if (take.HasValue)
                {
                    query = query.Take(take.Value);
                }
            }

            return (query, count);
        }

        /// <summary>
        /// Obtiene varios elementos de una entidad a partir 
        /// de condiciones
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
        => GetQueryable(filter, orderBy, includeProperties, skip, take).ToList();

        /// <summary>
        /// Devuelve todos los elementos de una entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
        => GetQueryable(null, orderBy, includeProperties, skip, take).ToList();

        /// <summary>
        /// Devuelve todos los elementos de una entidad asicronicamente
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
        => await GetQueryable(null, orderBy, includeProperties, skip, take).ToListAsync();

        /// <summary>
        /// Obtiene varios elementos de una entidad a partir 
        /// de condiciones asincronicamente
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
        => await GetQueryable(filter, orderBy, includeProperties, skip, take).ToListAsync();

        /// <summary>
        /// Devuelve un elemento de la entidad filtrado por Id
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetById<TEntity>(object id) where TEntity : class
        => Context.Set<TEntity>().Find(id);

        /// <summary>
        /// Devuelve el numero de elementos de una entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        => GetQueryable(filter).Count();

        /// <summary>
        /// Devuelve el numero de elementos de una entidad asincronico
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        => GetQueryable(filter).CountAsync();

        /// <summary>
        /// Devuelve la respuesta de existe o no de un elementos de una entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        => GetQueryable(filter).Any();

        /// <summary>
        /// Devuelve la respuesta de existe o no de un elementos de una entidad asincronico
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        => GetQueryable(filter).AnyAsync();

        /// <summary>
        /// Devuelve el primer elemento de una entidad 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual TEntity GetFirst<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) where TEntity : class
        => GetQueryable(filter, orderBy, includeProperties).FirstOrDefault();

        /// <summary>
        /// Devuelve el primer elemento de una entidad  asincronico
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual Task<TEntity> GetFirstAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) where TEntity : class
        => GetQueryable(filter, orderBy, includeProperties).FirstOrDefaultAsync();

        /// <summary>
        /// Devuelve un elemento a buscar de una entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class
        => GetQueryable(filter, null, includeProperties).FirstOrDefault();

        /// <summary>
        /// Devuelve un elemento a buscar de una entidad asincronico
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual Task<TEntity> GetOneAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class
        => GetQueryable(filter, null, includeProperties).FirstOrDefaultAsync();

        /// <summary>
        /// Devuelve un elemento de una entidad o deveueve nulo por defecto si no 
        /// encuentra coincidencia
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public TEntity GetOneOrDefault<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class
        => GetQueryable(filter, null, includeProperties).FirstOrDefault();

        /// <summary>
        /// Metodo para crear un nuevo registro en la entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="createdBy"></param>
        public void Create<TEntity>(TEntity entity, string createdBy = null) where TEntity : class
        => Context.Set<TEntity>().Add(entity);

        /// <summary>
        /// Metodo para insertar n registros en una entidad, en formato bulk
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="count"></param>
        /// <param name="commitCount"></param>
        public void Create<TEntity>(TEntity entity, int count, int commitCount) where TEntity : class
        {
            Context.Set<TEntity>().Add(entity);

            if (count % commitCount == 0)
            {
                Context.SaveChanges();
            }
        }

        /// <summary>
        /// Metodo para crear una lista de registros dentro de una entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        /// <param name="createdBy"></param>
        public void CreateList<TEntity>(IEnumerable<TEntity> entities, string createdBy = null) where TEntity : class
        => Context.Set<TEntity>().AddRange(entities);

        /// <summary>
        /// Metodo para eliminar un registro en una entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="modifiedBy"></param>
        public void Delete<TEntity>(object id) where TEntity : class
        {
            TEntity entity = Context.Set<TEntity>().Find(id);
            Delete(entity);
        }

        /// <summary>
        /// Metodo para eliminar la entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            var dbSet = Context.Set<TEntity>();
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        /// <summary>
        /// Metodo para grabar
        /// </summary>
        public void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("entity");
            }
        }

        /// <summary>
        /// Metodo para grabar asincronicamente
        /// </summary>
        /// <returns></returns>
        public Task SaveAsync()
        {
            try
            {
                return Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("entity");
            }

            return Task.FromResult(0);
        }

        /// <summary>
        /// Metodo para actualizar un registro en una entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="modifiedBy"></param>
        public void Update<TEntity>(TEntity entity, string modifiedBy = null) where TEntity : class
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public (IQueryable<TEntity>, int) GetTuple<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
        => GetQueryableTuple(filter, orderBy, includeProperties, skip, take);

        public IQueryable<TEntity> GetWithQueryable<TEntity>(Expression<Func<TEntity, bool>> match) where TEntity : class
        => GetQueryable(match);

        public Task<TEntity> FindOneAsync<TEntity>(Expression<Func<TEntity, bool>> match) where TEntity : class
        => GetQueryable(match).SingleOrDefaultAsync();

        public async Task<ICollection<TEntity>> FindAllAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        => await GetQueryable(filter: predicate).ToListAsync();
    }
}
