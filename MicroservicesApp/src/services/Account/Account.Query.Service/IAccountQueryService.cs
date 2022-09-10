using AccountMapper.Dto;
using acc = AccountDomain;

namespace Account.Query.Service
{
    public interface IAccountQueryService
    {
        AccountDto GetAccount(int id);
        IEnumerable<AccountDto> GetAccounts();

        acc.Account GetAccountEntity(int id);


    }
}
