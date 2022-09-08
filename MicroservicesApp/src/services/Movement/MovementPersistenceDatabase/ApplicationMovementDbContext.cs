using Microsoft.EntityFrameworkCore;
using MovementDomain;
using MovementPersistenceDatabase.Configuration;

namespace MovementPersistenceDatabase
{
    public class ApplicationMovementDbContext : DbContext
    {
        public ApplicationMovementDbContext(DbContextOptions<ApplicationMovementDbContext> option) : base(option)
        {

        }
        public DbSet<Movement> Movements { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.HasDefaultSchema("movement");
            ModelConfig(builder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new MovementConfiguration(modelBuilder.Entity<Movement>());
        }
    }
}