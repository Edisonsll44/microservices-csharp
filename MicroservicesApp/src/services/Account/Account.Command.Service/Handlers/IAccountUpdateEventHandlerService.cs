using AccountMapper.Dto;

namespace Account.Command.Service.Handlers
{
    public interface IAccountUpdateEventHandlerService
    {

        /// <summary>
        /// Actualiza una cuenta
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task Handle(CommandUpdateAccountDto dto, CancellationToken token);

    }
}
