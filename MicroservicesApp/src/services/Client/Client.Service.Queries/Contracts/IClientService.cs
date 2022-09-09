using Client.Mapper.Dto;

namespace Client.Service.Queries.Contracts
{
    public interface IClientQueryService
    {
        ClientDto GetClient(int id);
        IEnumerable<ClientDto> GetClients();

        Task<DtoRespuesta> CreateClient(ClientDto dto);
        Task<DtoRespuesta> UpdateClient(ClientDto dto);
        Task<DtoRespuesta> UpdateClient(int id, ClientDto dto);
        Task<DtoRespuesta> DeleteClient(int id);
    }
}
