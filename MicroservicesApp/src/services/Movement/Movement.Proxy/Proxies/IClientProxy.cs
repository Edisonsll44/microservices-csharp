using Client.Mapper.Dto;

namespace Movement.Service.Proxies
{
    public interface IClientProxy
    {
        /// <summary>
        /// Consulta un cliente por su
        /// identificacion y devuelve 
        /// su Id
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        Task<int> GetClientId(string dni);

        /// <summary>
        /// Deveuelve un cliente
        /// filtrado por su nombre
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<ClientDto> GetClient(string name);

        Task<IEnumerable<ClientDto>> GetClients();
    }
}
