using Movement.Mapper;
using Movement.Mapper.Dto;
using Movement.PersistenceDatabase;
using Movement.Service.Proxies;
using mov = Movement.Domain;

namespace Movement.Query.Service
{
    public class MovementQueryService : IMovementQueryService
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IMovementClientProxy _clientProxy;
        private readonly IMovementAccountProxy _accountProxy;
        public MovementQueryService(IMovementRepository movementRepository, IMovementClientProxy proxy, IMovementAccountProxy accountProxy)
        {
            _movementRepository = movementRepository;
            _clientProxy = proxy;
            _accountProxy = accountProxy;
        }
        public MovementDto GetMovemment(int id)
        {
            var account = _movementRepository.GetById<mov.Movement>(id);
            if (account == null)
                throw new Exception("Movimiento no encontrado, intente de nuevo");
            var dto = MovementMapper.MapEntityToDto(account);
            return dto;
        }

        public mov.Movement GetMovemmentEntity(int id)
        {
            var account = _movementRepository.GetById<mov.Movement>(id);
            return account;
        }

        public IEnumerable<MovementDto> GetMovemments()
        {
            var account = _movementRepository.GetAll<mov.Movement>();
            var dto = MovementMapper.MapEntityToDtoCollection(account);
            return dto;
        }

        public async Task<IEnumerable<MovementDto>> GetMovementByDateOrClient(DateTime dateQuery, string clientName, string clientId)
        {
            List<mov.Movement> movements = new();

            if (dateQuery != DateTime.MinValue)
            {
                movements.AddRange(GetMovementsMovements(dateQuery));
            }

            if (!string.IsNullOrEmpty(clientName) || !string.IsNullOrEmpty(clientId))
            {
                var client = await _clientProxy.GetClient(clientName);
                var accountsClient = await _accountProxy.GetAccountsByClient(client.ClientId, clientName, clientId);
                GetMovementsMovements(null);
            }
            return (IEnumerable<MovementDto>)movements;
        }

        IEnumerable<mov.Movement> GetMovementsMovements(DateTime dateQuery)
        => _movementRepository.Get<mov.Movement>(m => m.MovementDate >= dateQuery).ToList();

        IEnumerable<mov.Movement> GetMovementsMovements(IEnumerable<int> accountsClient)
        {
            List<mov.Movement> movements = new();
            if (accountsClient != null)
            {
                foreach (var account in accountsClient)
                {
                    var movementsClient = _movementRepository.Get<mov.Movement>(m => m.AccountClientId == account);
                    movements.AddRange(movementsClient);
                }
            }
            return movements;
        }
    }
}