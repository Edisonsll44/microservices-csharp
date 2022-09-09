using AccountDomain;
using AccountPersistenceDatabase.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AccountPersistenceDatabase
{
    public class ApplicationAccountDbContext : DbContext, IApplicationAccountDbContext
    {
        public ApplicationAccountDbContext(DbContextOptions<ApplicationAccountDbContext> option) : base(option)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountClient> AccountClients { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ModelConfig(builder);
        }
        /// <summary>
        /// Configuracion inicial
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new AccountConfiguration(modelBuilder.Entity<Account>());
        }

    }
}