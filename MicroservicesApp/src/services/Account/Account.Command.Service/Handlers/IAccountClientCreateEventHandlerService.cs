using AccountMapper.Dto;

namespace Account.Command.Service.Handlers
{
    public interface IAccountClientCreateEventHandlerService
    {
        /// <summary>
        /// Actualiza una cuenta
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task Handle(CommandCreateAccountClientDto dto, CancellationToken token);
        /// <summary>
        /// Devuelve las cuentas atadas a un cliente
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        IEnumerable<CommandCreateAccountClientDto> GetAccountsByClientId(int clientId, string clientName, string dni);
    }
}
