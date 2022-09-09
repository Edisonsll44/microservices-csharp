using AccountDomain;
using AccountMapper.Dto;

namespace AccountMapper
{
    public class AccountMapper
    {
        public static AccountDto MapEntityToDto(Account account)
        {
            return new AccountDto
            {
                CuentaId = account.AccountId,
                TipoCuenta = account.AccountType
            };
        }

        public static Account MapDtoToEntity(AccountDto account)
        {
            return new Account
            {
                AccountId = account.CuentaId,
                AccountType = account.TipoCuenta
            };
        }

        public static Account MapDtoToEntity(Account account, AccountDto dto)
        {
            account.AccountId = dto.CuentaId;
            account.AccountType = dto.TipoCuenta;
            return account;
        }

        public static IEnumerable<AccountDto> MapEntityToDtoCollection(IEnumerable<Account> accounts)
        {
            var clientsDto = new List<AccountDto>();
            foreach (var account in accounts)
            {
                var dto = new AccountDto
                {
                    CuentaId = account.AccountId,
                    TipoCuenta = account.AccountType
                };
                clientsDto.Add(dto);
            }
            return clientsDto;
        }
    }
}