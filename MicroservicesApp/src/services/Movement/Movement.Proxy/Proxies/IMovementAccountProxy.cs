using Movement.Mapper.Dto;

namespace Movement.Service.Proxies
{
    public interface IMovementAccountProxy
    {
        /// <summary>
        /// Devuelve el id de una cuenta filtrado por su tipo
        /// </summary>
        /// <param name="accountType"></param>
        /// <returns></returns>
        Task<int> GetAccountIdAsync(string accountType);
        /// <summary>
        /// Devuelve el nombre de una cuenta
        /// filtrada por su id
        /// </summary>
        /// <param name="idAccount"></param>
        /// <returns></returns>
        Task<string> GetAccountName(int idAccount);
        /// <summary>
        /// Devuelve el codigo de la cuenta
        /// por cliente filtrado por el
        /// id del cliente
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        Task<IEnumerable<CommandCreateAccountClientDto>> GetAccountsByClient(int clientId, string clientName, string dni);

    }
}
