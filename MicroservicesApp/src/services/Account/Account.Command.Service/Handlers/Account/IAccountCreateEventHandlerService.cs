using AccountMapper.Dto;

namespace Account.Command.Service.Handlers.Account
{
    public interface IAccountCreateEventHandlerService
    {

        /// <summary>
        /// Actualiza una cuenta
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task Handle(CommandCreateAccountDto dto, CancellationToken token);

    }
}
