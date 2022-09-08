using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository.Generics
{
    public abstract class GenericRepository<T> : BaseRepository<T> where T : class
    {
        protected GenericRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
