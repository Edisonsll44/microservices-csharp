using ClientDomain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientPersistenceDatabase.Configuration
{
    public class ClientConfiguration
    {
        public ClientConfiguration(EntityTypeBuilder<Client> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.ClientId);
            entityBuilder.Property(x => x.State).IsRequired();
            entityBuilder.Property(x => x.Pasword).IsRequired().HasMaxLength(10);

            //Client by default
            var clients = new List<Client>();

            var client1 = new Client
            {
                Nombre = "Jose Lema",
                Genero = "Masculino",
                Edad = 27,
                Identificacion = "1802245263",
                Direccion = "Otavalo sn y principal ",
                Pasword = "1234",
                State = true,
                Telefono = "098254785 ",
                ClientId = 1
            };
            clients.Add(client1);

            var client2 = new Client
            {
                Nombre = "Marianela Montalvo",
                Genero = "Femenino",
                Edad = 50,
                Identificacion = "1804568765",
                Direccion = "Amazonas y  NNUU",
                Pasword = "5678",
                State = true,
                Telefono = "097548965  ",
                ClientId = 2
            };
            clients.Add(client2);

            var client3 = new Client
            {
                Nombre = "Juan Osorio",
                Genero = "Masculino",
                Edad = 37,
                Identificacion = "180224522001",
                Direccion = "13 junio y Equinoccial",
                Pasword = "4322",
                State = true,
                Telefono = "098874587 ",
                ClientId = 3
            };
            clients.Add(client3);

            entityBuilder.HasData(clients);
        }
    }
}
