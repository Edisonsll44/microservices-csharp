using Account.PersistenceDatabase.Repositories;
using Account.Service.Proxies;
using AccountMapper.Dto;
using MediatR;
using acc = AccountDomain;

namespace Account.Command.Service.Handlers
{
    public class AccountClientCreateEventHandlerService : IAccountClientCreateEventHandlerService, INotificationHandler<CommandCreateAccountClientDto>

    {
        private readonly IAccountClientRepository _accountClientRepository;
        private readonly IAccountProxy _accountProxy;
        private readonly IClientProxy _clientProxy;
        public AccountClientCreateEventHandlerService(IAccountClientRepository accountClientRepository, IAccountProxy accountProxy, IClientProxy clientProxy)
        {
            _accountClientRepository = accountClientRepository;
            _accountProxy = accountProxy;
            _clientProxy = clientProxy;
        }

        public IEnumerable<CommandCreateAccountClientDto> GetAccountsByClientId(int clientId, string clientName, string dni)
        {
            var acounts = _accountClientRepository.Get<acc.AccountClient>(c => c.ClientId == clientId);
            var accountsDto = AccountMapper.AccountMapper.MapEntityToDtoCollection(acounts, clientName, dni);
            return accountsDto;
        }

        public async Task Handle(CommandCreateAccountClientDto dto, CancellationToken token)
        {
            var accountId = await _accountProxy.GetAccountIdAsync(dto.TipoCuenta);
            var clientId = await _clientProxy.GetClientId(dto.IdentificacionCliente);
            var newAccount = AccountMapper.AccountMapper.MapDtoToEntity(dto, accountId, clientId);
            _accountClientRepository.Create(newAccount);
            _accountClientRepository.Save();
        }
    }
}
