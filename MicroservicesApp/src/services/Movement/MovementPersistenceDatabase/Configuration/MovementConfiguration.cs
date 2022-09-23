using Microsoft.EntityFrameworkCore.Metadata.Builders;
using me = Movement.Domain;

namespace MovementPersistenceDatabase.Configuration
{
    public class MovementConfiguration
    {
        public MovementConfiguration(EntityTypeBuilder<me.Movement> entityBuilder)
        {
            var movements = new List<me.Movement>();
            var movement = new me.Movement
            {
                Balance = 2000,
                MovementDate = DateTime.Now,
                MovementId = 1,
                MovementType = "Retiro de 575",
                AccountClientId = 1
            };
            movements.Add(movement);
            entityBuilder.HasData(movements);
        }
    }
}
