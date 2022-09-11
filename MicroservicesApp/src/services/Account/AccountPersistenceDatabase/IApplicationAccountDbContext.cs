using AccountDomain;
using Common.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using ac = AccountDomain;

namespace AccountPersistenceDatabase
{
    public interface IApplicationAccountDbContext : IDbContext
    {

        public DbSet<ac.Account> Accounts { get; set; }
        public DbSet<AccountClient> AccountClients { get; set; }
    }
}
