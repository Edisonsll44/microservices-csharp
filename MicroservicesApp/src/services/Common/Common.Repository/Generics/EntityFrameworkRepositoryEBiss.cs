using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository.Generics
{
    internal class EntityFrameworkRepositoryGeneric<TContext> : EntityFrameworkReadOnlyRepository<TContext>, IEntityFrameworkRepositoryGeneric where TContext : DbContext
    {
        public EntityFrameworkRepositoryGeneric(TContext Context) : base(Context)
        {
        }
        /// <summary>
        /// Metodo para crear un nuevo registro en la entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="createdBy"></param>
        public virtual void Create<TEntity>(TEntity entity, string createdBy = null)
           where TEntity : class
        => Context.Set<TEntity>().Add(entity);

        /// <summary>
        /// Metodo para insertar n registros en una entidad, en formato bulk
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="count"></param>
        /// <param name="commitCount"></param>
        public virtual void Create<TEntity>(TEntity entity, int count, int commitCount)
            where TEntity : class
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
        public virtual void Update<TEntity>(TEntity entity, string modifiedBy = null)
            where TEntity : class
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
        /// <summary>
        /// Metodo para eliminar un registro en una entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        public virtual void Delete<TEntity>(object id)
            where TEntity : class
        {
            TEntity entity = Context.Set<TEntity>().Find(id);
            Delete(entity);
        }
        /// <summary>
        /// Metodo para eliminar la entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public virtual void Delete<TEntity>(TEntity entity)
            where TEntity : class
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
        public virtual void Save()
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
        public virtual Task SaveAsync()
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
        /// Metodo para crear una lista de registros dentro de una entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        /// <param name="createdBy"></param>
        public virtual void CreateRange<TEntity>(IEnumerable<TEntity> entities, string createdBy = null) where TEntity : class
        => Context.Set<TEntity>().AddRange(entities);
    }
}
