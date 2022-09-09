using ClientPersistenceDatabase.Contract.Repositories;
using Common.Repository.Generics;

namespace ClientPersistenceDatabase.Repositories
{
    public class ClientRepository : EntityFrameworkReadOnlyRepository<ApplicationDbContext>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext Context) : base(Context)
        {
        }
    }
}
