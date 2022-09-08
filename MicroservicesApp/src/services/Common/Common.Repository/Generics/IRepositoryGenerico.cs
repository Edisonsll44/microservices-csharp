using System.Linq.Expressions;

namespace Common.Repository
{
    public interface IRepositoryGenerico<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Update(T entity);
        Task<T> Add(T entity);
        TEntity GetOneOrDefault<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) where TEntity : class;
        IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) where TEntity : class;
        bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class;
        Task CreateRange<TEntity>(IEnumerable<TEntity> entities, string createdBy = null) where TEntity : class;
        Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class;
        Task<TEntity> GetOneAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class;

        Task<T> GetByIdAsync<T>(object id) where T : class;
        Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class;

    }
}
