namespace Common.Repository.Generics
{
    public interface IEntityFrameworkRepositoryGeneric : IEntityFrameworkReadOnlyRepository
    {
        /// <summary>
        /// Metodo para crear un nuevo registro en la entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="createdBy"></param>
        void Create<TEntity>(TEntity entity, string createdBy = null)
            where TEntity : class;

        /// <summary>
        /// Metodo para insertar n registros en una entidad, en formato bulk
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="count"></param>
        /// <param name="commitCount"></param>
        void Create<TEntity>(TEntity entity, int count, int commitCount) where TEntity : class;

        /// <summary>
        /// Metodo para crear una lista de registros dentro de una entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        /// <param name="createdBy"></param>
        void CreateList<TEntity>(IEnumerable<TEntity> entities, string createdBy = null)
            where TEntity : class;

        /// <summary>
        /// Metodo para actualizar un registro en una entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="modifiedBy"></param>
        void Update<TEntity>(TEntity entity, string modifiedBy = null)
            where TEntity : class;

        /// <summary>
        /// Metodo para eliminar un registro en una entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        void Delete<TEntity>(object id)
            where TEntity : class;

        /// <summary>
        /// Metodo para eliminar la entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void Delete<TEntity>(TEntity entity)
            where TEntity : class;

        /// <summary>
        /// Metodo para grabar
        /// </summary>
        void Save();

        /// <summary>
        /// Metodo para grabar asincronicamente
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();
    }
}
