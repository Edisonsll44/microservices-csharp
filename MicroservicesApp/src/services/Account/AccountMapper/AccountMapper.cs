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

        public static AccountClient MapDtoToEntity(CommandCreateAccountClientDto dto, int accountId, int clientId)
        {
            return new AccountClient
            {
                AccountId = accountId,
                AccountNumber = dto.NumeroCuenta,
                Balance = dto.Saldo,
                State = dto.Estado,
                ClientId = clientId
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


        public static IEnumerable<CommandCreateAccountClientDto> MapEntityToDtoCollection(IEnumerable<AccountClient> accountsClients, IEnumerable<object> client)
        {
            var clientsDto = new List<CommandCreateAccountClientDto>();
            var t = client;
            foreach (var account in accountsClients)
            {
                var dto = new CommandCreateAccountClientDto
                {
                    NumeroCuenta = account.AccountNumber,
                    Saldo = account.Balance,
                    EstadoWeb = account.State == true ? "True" : "False",
                    //IdentificacionCliente = clientDni,
                    //NombreCliente = clientName

                };
                clientsDto.Add(dto);
            }
            return clientsDto;
        }

        public static CommandCreateAccountClientDto MapEntityToDto(AccountClient accountClient, string accountType, string clientDni, string clientName)
        {
            return new CommandCreateAccountClientDto
            {
                NumeroCuenta = accountClient.AccountNumber,
                TipoCuenta = accountType,
                Saldo = accountClient.Balance,
                EstadoWeb = accountClient.State == true ? "True" : "False",
                IdentificacionCliente = clientDni,
                NombreCliente = clientName
            };
        }
    }
}
