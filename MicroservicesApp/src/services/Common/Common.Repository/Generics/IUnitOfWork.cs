using Microsoft.EntityFrameworkCore.Storage;

namespace Common.Repository
{
    public interface IUnitOfWork
    {
        //int SaveChanges();
        Task<int> SaveChangesAsync();
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
