using Common.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using me = MovementDomain;

namespace MovementPersistenceDatabase
{
    public interface IApplicationMovementDbContext : IDbContext
    {
        public DbSet<me.Movement> Movements { get; set; }
    }
}
