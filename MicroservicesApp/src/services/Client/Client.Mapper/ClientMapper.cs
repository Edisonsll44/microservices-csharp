
using Client.Mapper.Dto;
using domain = ClientDomain;
namespace Client.Mapper
{
    public static class ClientMapper
    {
        public static ClientDto MapEntityToDto(domain.Client client)
        {
            return new ClientDto
            {
                Direccion = client.Direccion,
                ClientId = client.ClientId,
                Edad = client.Edad,
                Genero = client.Genero,
                Identificacion = client.Identificacion,
                Nombre = client.Nombre,
                Pasword = client.Pasword,
                State = client.State,
                Telefono = client.Telefono
            };
        }

        public static domain.Client MapDtoToEntity(ClientDto dto)
        {
            return new domain.Client
            {
                Direccion = dto.Direccion,
                Edad = dto.Edad,
                Genero = dto.Genero,
                Identificacion = dto.Identificacion,
                Nombre = dto.Nombre,
                Pasword = dto.Pasword,
                State = dto.State,
                Telefono = dto.Telefono
            };
        }


        public static domain.Client MapDtoIntoEntity(ClientDto dto, domain.Client client)
        {

            client.Direccion = dto.Direccion;
            client.Edad = dto.Edad;
            client.Genero = dto.Genero;
            client.Identificacion = dto.Identificacion;
            client.Nombre = dto.Nombre;
            client.Pasword = dto.Pasword;
            client.State = dto.State;
            client.Telefono = dto.Telefono;
            return client;
        }

        public static IEnumerable<ClientDto> MapEntityToDtoCollection(IEnumerable<domain.Client> clients)
        {
            var clientsDto = new List<ClientDto>();
            foreach (var client in clients)
            {
                var dto = new ClientDto
                {
                    Direccion = client.Direccion,
                    ClientId = client.ClientId,
                    Edad = client.Edad,
                    Genero = client.Genero,
                    Identificacion = client.Identificacion,
                    Nombre = client.Nombre,
                    Pasword = client.Pasword,
                    State = client.State,
                    Telefono = client.Telefono
                };
                clientsDto.Add(dto);
            }
            return clientsDto;
        }
    }
}