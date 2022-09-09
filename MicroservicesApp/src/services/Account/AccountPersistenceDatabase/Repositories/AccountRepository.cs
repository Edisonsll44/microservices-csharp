using Common.Repository.Generics;

namespace AccountPersistenceDatabase.Repositories
{
    public class AccountRepository : EntityFrameworkReadOnlyRepository<ApplicationAccountDbContext>, IAccountRepository
    {
        public AccountRepository(ApplicationAccountDbContext Context) : base(Context)
        {
        }
    }
}
