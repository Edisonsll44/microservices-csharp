using AccountMapper.Dto;
using acc = AccountDomain;

namespace Account.Query.Service
{
    public interface IAccountQueryService
    {
        /// <summary>
        /// Devuelve una cuenta
        /// por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AccountDto GetAccount(int id);
        /// <summary>
        /// DEvuelve todas las cuentas
        /// </summary>
        /// <returns></returns>
        IEnumerable<AccountDto> GetAccounts();
        /// <summary>
        /// DEvuelve la entidad
        /// cuenta filtrada por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        acc.Account GetAccountEntity(int id);
        /// <summary>
        /// Devuel el id de la cuenta
        /// filtrada por id
        /// </summary>
        /// <param name="accountType"></param>
        /// <returns></returns>
        AccountDto GetAccountEntity(string accountType);
    }
}
