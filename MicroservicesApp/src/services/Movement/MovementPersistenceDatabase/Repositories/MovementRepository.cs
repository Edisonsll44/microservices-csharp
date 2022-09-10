using Common.Repository.Generics;
using MovementPersistenceDatabase;

namespace Movement.PersistenceDatabase
{
    public class MovementRepository : EntityFrameworkReadOnlyRepository<ApplicationMovementDbContext>, IMovementRepository
    {
        public MovementRepository(ApplicationMovementDbContext Context) : base(Context)
        {
        }
    }
}
