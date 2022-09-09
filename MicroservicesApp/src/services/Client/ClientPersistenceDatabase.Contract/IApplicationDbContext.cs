using ClientDomain;
using Common.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace ClientPersistenceDatabase.Contract
{
    public interface IApplicationDbContext : IDbContext
    {
        public DbSet<Client> Clients { get; set; }
    }
}