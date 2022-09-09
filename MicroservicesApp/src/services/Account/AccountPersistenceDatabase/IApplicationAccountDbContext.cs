using AccountDomain;
using Common.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace AccountPersistenceDatabase
{
    public interface IApplicationAccountDbContext : IDbContext
    {

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountClient> AccountClients { get; set; }
    }
}
