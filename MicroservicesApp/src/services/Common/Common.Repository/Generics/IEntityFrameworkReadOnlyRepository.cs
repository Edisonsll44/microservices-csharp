using System.Linq.Expressions;

namespace Common.Repository.Generics
{
    public interface IEntityFrameworkReadOnlyRepository
    {
        /// <summary>
        /// Devuelve todos los elementos de una entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll<TEntity>(
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = null,
           int? skip = null,
           int? take = null)
           where TEntity : class;

        /// <summary>
        /// Devuelve todos los elementos de una entidad asicronicamente
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class;

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
        IEnumerable<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class;

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
        Task<IEnumerable<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class;

        /// <summary>
        /// Devuelve un elemento a buscar de una entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        TEntity GetOne<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null)
            where TEntity : class;

        /// <summary>
        /// Devuelve un elemento de una entidad o deveueve nulo por defecto si no 
        /// encuentra coincidencia
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        TEntity GetOneOrDefault<TEntity>(Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null)
            where TEntity : class;

        /// <summary>
        /// Devuelve un elemento a buscar de una entidad asincronico
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<TEntity> GetOneAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null)
            where TEntity : class;

        /// <summary>
        /// Devuelve el primer elemento de una entidad 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        TEntity GetFirst<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null)
            where TEntity : class;

        /// <summary>
        /// Devuelve el primer elemento de una entidad  asincronico
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<TEntity> GetFirstAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null)
            where TEntity : class;

        /// <summary>
        /// Devuelve un elemento de la entidad filtrado por Id
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById<TEntity>(object id)
            where TEntity : class;

        /// <summary>
        /// Devuelve el numero de elementos de una entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class;

        /// <summary>
        /// Devuelve el numero de elementos de una entidad asincronico
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class;

        /// <summary>
        /// Devuelve la respuesta de existe o no de un elementos de una entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class;

        /// <summary>
        /// Devuelve la respuesta de existe o no de un elementos de una entidad asincronico
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class;

        /// <summary>
        /// Devuelve todos los elementos de una entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        (IQueryable<TEntity>, int) GetTuple<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class;
        /// <summary>
        /// Devuelve todos los elementos de una entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetWithQueryable<TEntity>(Expression<Func<TEntity, bool>> match) where TEntity : class;

        /// <summary>
        /// Devuelve un elemento de una entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="match">expresion</param>
        /// <returns></returns>
        Task<TEntity> FindOneAsync<TEntity>(Expression<Func<TEntity, bool>> match) where TEntity : class;

        /// <summary>
        /// Obtiene varios elementos de una entidad a partir 
        /// de condiciones asincronicamente
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate">filtro de busqued</param>
        /// <returns></returns>
        Task<ICollection<TEntity>> FindAllAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

    }
}
