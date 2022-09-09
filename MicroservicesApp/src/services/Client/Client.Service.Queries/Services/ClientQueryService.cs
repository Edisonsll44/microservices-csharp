using Client.Mapper;
using Client.Mapper.Dto;
using Client.Service.Queries.Contracts;
using ClientPersistenceDatabase.Contract.Repositories;
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

        public Task CreateClient(ClientDto dto)
        {
            var newClient = ClientMapper.MapDtoToEntity(dto);
            return _clientRepository.Add(newClient);
        }

        public async Task DeleteClient(int id)
        {
            var clientFound = await GetClient(id);
            var clientToDelete = ClientMapper.MapDtoToEntity(clientFound);
            await _clientRepository.Delete(clientToDelete);
        }

        public async Task<ClientDto> GetClient(int id)
        {
            var client = await _clientRepository.GetByIdAsync<domain.Client>(id);
            var clientDto = ClientMapper.MapEntityToDto(client);
            return clientDto;
        }

        public IEnumerable<ClientDto> GetClients()
        {
            var clientsDto = new List<ClientDto>();
            var clients = _clientRepository.GetAll<domain.Client>();
            var dtos = ClientMapper.MapEntityToDtoCollection(clients);
            return dtos;
        }

        public Task UpdateClient(ClientDto dto)
        {
            throw new NotImplementedException();
        }
    }
}