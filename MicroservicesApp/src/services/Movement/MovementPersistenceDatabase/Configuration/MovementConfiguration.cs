using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovementDomain;

namespace MovementPersistenceDatabase.Configuration
{
    public class MovementConfiguration
    {
        public MovementConfiguration(EntityTypeBuilder<Movement> entityBuilder)
        {
            var movements = new List<Movement>();
            var movement = new Movement
            {
                Balance = 2000,
                MovementDate = DateTime.Now,
                MovementId = 1,
                MovementType = "Retiro de 575",
                AccountId = 1
            };
            movements.Add(movement);
            entityBuilder.HasData(movements);
        }
    }
}
