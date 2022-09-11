using Account.Query.Service;
using AccountMapper.Dto;
using AccountPersistenceDatabase.Repositories;
using MediatR;

namespace Account.Command.Service.Handlers.Account
{
    public class AccountCreateEventHandlerService : IAccountCreateEventHandlerService, INotificationHandler<CommandCreateAccountDto>
    {
        private readonly IAccountRepository _accountRepository;

        public AccountCreateEventHandlerService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task Handle(CommandCreateAccountDto dto, CancellationToken token)
        {
            var newAccount = AccountMapper.AccountMapper.MapDtoToEntity(dto);
            _accountRepository.Create(newAccount);
            _accountRepository.Save();
        }
    }
}
