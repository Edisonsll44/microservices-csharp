using AccountMapper.Dto;

namespace Account.Query.Service
{
    public interface IAccountClientQueryService
    {
        Task<IEnumerable<CommandCreateAccountClientDto>> GetAccountsByClientsAsync();
        Task<CommandCreateAccountClientDto> GetAccountByNameAsync(string nameClient);

    }
}
