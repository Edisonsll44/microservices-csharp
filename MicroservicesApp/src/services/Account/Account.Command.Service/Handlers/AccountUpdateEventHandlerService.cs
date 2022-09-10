using Account.Query.Service;
using AccountMapper.Dto;
using AccountPersistenceDatabase.Repositories;
using MediatR;

namespace Account.Command.Service.Handlers
{
    public class AccountUpdateEventHandlerService : IAccountUpdateEventHandlerService, INotificationHandler<CommandUpdateAccountDto>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountQueryService _accountQueryService;

        public AccountUpdateEventHandlerService(IAccountRepository accountRepository, IAccountQueryService accountQueryService)
        {
            _accountQueryService = accountQueryService;
            _accountRepository = accountRepository;
        }
        public async Task Handle(CommandUpdateAccountDto dto, CancellationToken token)
        {
            var accountFound = _accountQueryService.GetAccountEntity(dto.CuentaId);
            AccountMapper.AccountMapper.MapDtoToEntity(accountFound, dto);
            _accountRepository.Update(accountFound);
            _accountRepository.Save();
        }
    }
}
