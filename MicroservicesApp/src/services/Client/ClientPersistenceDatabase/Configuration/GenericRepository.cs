using ClientPersistenceDatabase.Contract;

namespace Common.Repository.Generics
{
    public abstract class GenericRepository<T> : BaseRepository<T> where T : class
    {
        protected IApplicationDbContext _applicationDbContext
        {
            get { return _applicationDbContext as IApplicationDbContext; }
        }
        protected GenericRepository(IApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
