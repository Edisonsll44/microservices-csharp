using Common.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using me = Movement.Domain;

namespace MovementPersistenceDatabase
{
    public interface IApplicationMovementDbContext : IDbContext
    {
        public DbSet<me.Movement> Movements { get; set; }
    }
}
