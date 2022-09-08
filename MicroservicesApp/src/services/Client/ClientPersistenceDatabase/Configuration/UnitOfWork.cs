using ClientPersistenceDatabase.Contract;
using Microsoft.EntityFrameworkCore.Storage;

namespace Common.Repository.Generics
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool _disposed;
        private readonly IApplicationDbContext _dbContext;

        public UnitOfWork(IApplicationDbContext context)
        {
            _dbContext = context;

        }

        public Task<int> SaveChanges()
        {
            return _dbContext.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        protected void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.SaveChangesAsync();
        }

        IDbContextTransaction IUnitOfWork.BeginTransaction()
        {
            throw new NotImplementedException();
        }

        Task<IDbContextTransaction> IUnitOfWork.BeginTransactionAsync()
        {
            throw new NotImplementedException();
        }
    }
}
