using Client.Mapper;
using Client.Mapper.Dto;
using Client.Service.Queries.Contracts;
using ClientPersistenceDatabase.Contract.Repositories;
using Common.Repository.Generics;
using domain = ClientDomain;

namespace Client.Service.Queries.Services
{
    public class ClientQueryService : IClientQueryService
    {
        private readonly IClientRepository _clientRepository;

        public ClientQueryService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        /// <summary>
        /// Crea un nuevo cliente
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Task<DtoRespuesta> CreateClient(ClientDto dto)
        {
            var newClient = ClientMapper.MapDtoToEntity(dto);
            _clientRepository.Create(newClient);
            _clientRepository.Save();
            return Respuesta.DevolverRespuesta("Cliente", "creado");
        }
        /// <summary>
        /// Elimina cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<DtoRespuesta> DeleteClient(int id)
        {
            var clientFound = GetClient(id);
            _clientRepository.Delete(clientFound);
            return Respuesta.DevolverRespuesta("Cliente", "eliminado");
        }
        /// <summary>
        /// Devuelve el cliente por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClientDto GetClient(int id)
        {
            var client = _clientRepository.GetById<domain.Client>(id);
            var clientDto = ClientMapper.MapEntityToDto(client);
            return clientDto;
        }

        public ClientDto GetClient(string dni)
        {
            var client = _clientRepository.GetFirst<domain.Client>(c => c.Identificacion.Equals(dni));
            var clientDto = ClientMapper.MapEntityToDto(client);
            return clientDto;
        }

        /// <summary>
        /// Devuelve todos los clientes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ClientDto> GetClients()
        {
            var clientsDto = new List<ClientDto>();
            var clients = _clientRepository.GetAll<domain.Client>();
            var dtos = ClientMapper.MapEntityToDtoCollection(clients);
            return dtos;
        }

        public Task<DtoRespuesta> UpdateClient(ClientDto dto)
        {
            var client = _clientRepository.GetById<domain.Client>(dto.ClientId);
            var clientModified = ClientMapper.MapDtoIntoEntity(dto, client);
            _clientRepository.Update(clientModified);
            _clientRepository.Save();
            return Respuesta.DevolverRespuesta("Cliente", "modificado");
        }

        public Task<DtoRespuesta> UpdateClient(int id, ClientDto dto)
        {
            var client = _clientRepository.GetById<domain.Client>(id);
            var clientModified = ClientMapper.MapDtoIntoEntity(dto, client);
            _clientRepository.Update(clientModified);
            _clientRepository.Save();
            return Respuesta.DevolverRespuesta("Cliente", "modificado");
        }
    }
}