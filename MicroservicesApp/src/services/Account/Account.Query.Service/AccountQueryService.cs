using AccountMapper.Dto;
using AccountPersistenceDatabase.Repositories;
using acc = AccountDomain;
namespace Account.Query.Service
{
    public class AccountQueryService : IAccountQueryService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountQueryService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public AccountDto GetAccount(int id)
        {
            var account = _accountRepository.GetById<acc.Account>(id);
            var dto = AccountMapper.AccountMapper.MapEntityToDto(account);
            return dto;
        }

        public acc.Account GetAccountEntity(int id)
        {
            var account = _accountRepository.GetById<acc.Account>(id);
            return account;
        }

        public IEnumerable<AccountDto> GetAccounts()
        {
            var account = _accountRepository.GetAll<acc.Account>();
            var dto = AccountMapper.AccountMapper.MapEntityToDtoCollection(account);
            return dto;
        }
    }
}