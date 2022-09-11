using Client.Mapper.Dto;

namespace Account.Service.Proxies
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
    }
}
