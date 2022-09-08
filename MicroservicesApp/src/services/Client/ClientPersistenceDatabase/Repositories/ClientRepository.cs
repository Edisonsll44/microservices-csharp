using ClientDomain;
using ClientPersistenceDatabase.Contract;
using ClientPersistenceDatabase.Contract.Repositories;
using Common.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace ClientPersistenceDatabase.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(IApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        protected override DbSet<Client> DbEntity => _applicationDbContext.Clients;
    }
}
