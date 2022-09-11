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
    }
}
