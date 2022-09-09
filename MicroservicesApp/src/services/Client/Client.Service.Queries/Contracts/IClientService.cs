using Client.Mapper.Dto;

namespace Client.Service.Queries.Contracts
{
    public interface IClientQueryService
    {
        Task<ClientDto> GetClient(int id);
        IEnumerable<ClientDto> GetClients();

        Task CreateClient(ClientDto dto);
        Task UpdateClient(ClientDto dto);
        Task DeleteClient(int id);
    }
}
