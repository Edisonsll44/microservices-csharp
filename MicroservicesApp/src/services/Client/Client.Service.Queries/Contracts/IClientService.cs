using Client.Mapper.Dto;

namespace Client.Service.Queries.Contracts
{
    public interface IClientQueryService
    {
        /// <summary>
        /// devuelve un cliente por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ClientDto GetClient(int id);
        /// <summary>
        /// Deveulve un cliente
        /// por identificacion
        /// </summary>
        /// <returns></returns>
        IEnumerable<ClientDto> GetClients();
        /// <summary>
        /// Deveulve todos los clientes
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        ClientDto GetClient(string dni);
        /// <summary>
        /// Crea un nuevo cliente
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<DtoRespuesta> CreateClient(ClientDto dto);
        /// <summary>
        /// Actualiza un cliente
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<DtoRespuesta> UpdateClient(ClientDto dto);
        /// <summary>
        /// Actualiza una seccion del cliente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<DtoRespuesta> UpdateClient(int id, ClientDto dto);
        /// <summary>
        /// Eliminacion de cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DtoRespuesta> DeleteClient(int id);
    }
}
