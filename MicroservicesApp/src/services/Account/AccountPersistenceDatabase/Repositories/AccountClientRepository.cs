using AccountPersistenceDatabase;
using Common.Repository.Generics;

namespace Account.PersistenceDatabase.Repositories
{
    public class AccountClientRepository : EntityFrameworkReadOnlyRepository<ApplicationAccountDbContext>, IAccountClientRepository
    {
        public AccountClientRepository(ApplicationAccountDbContext Context) : base(Context)
        {
        }
    }
}
