using Account.PersistenceDatabase.Repositories;
using Account.Service.Proxies;
using AccountDomain;
using AccountMapper.Dto;

namespace Account.Query.Service
{
    public class AccountClientQueryService : IAccountClientQueryService
    {
        private readonly IAccountClientRepository _accountClientRepository;
        private readonly IAccountProxy _accountProxy;
        private readonly IClientProxy _clientProxy;

        public AccountClientQueryService(IAccountClientRepository accountClientRepository, IAccountProxy accountProxy, IClientProxy clientProxy)
        {
            _accountClientRepository = accountClientRepository;
            _clientProxy = clientProxy;
            _accountProxy = accountProxy;
        }
        public async Task<CommandCreateAccountClientDto> GetAccountByNameAsync(string nameClient)
        {
            var client = await _clientProxy.GetClient(nameClient);

            var accountClientFound = _accountClientRepository.GetFirst<AccountClient>(a => a.ClientId == client.ClientId);
            if (accountClientFound == null)
                throw new Exception("Tipo de cuenta no encontrada, vuelva a intentarlo");
            var account = await _accountProxy.GetAccountName(accountClientFound.AccountId);
            var dto = AccountMapper.AccountMapper.MapEntityToDto(accountClientFound, clientDni: client.Identificacion, clientName: client.Nombre, accountType: account);
            return dto;
        }

        public async Task<IEnumerable<CommandCreateAccountClientDto>> GetAccountsByClientsAsync()
        {
            var accountsClientsFound = _accountClientRepository.GetAll<AccountClient>();
            var clients = await _clientProxy.GetClients();
            if (accountsClientsFound.Any())
                throw new Exception("No se encontro cuentas de clientes, vuelva a intentarlo");
            var dto = AccountMapper.AccountMapper.MapEntityToDtoCollection(accountsClientsFound, clients);
            return dto;
        }
    }
}
