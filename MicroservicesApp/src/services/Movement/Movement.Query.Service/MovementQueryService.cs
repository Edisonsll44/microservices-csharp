using Movement.Mapper;
using Movement.Mapper.Dto;
using Movement.PersistenceDatabase;

namespace Movement.Query.Service
{
    public class MovementQueryService : IMovementQueryService
    {
        private readonly IMovementRepository _movementRepository;
        public MovementQueryService(IMovementRepository movementRepository)
        {
            _movementRepository = movementRepository;
        }
        public MovementDto GetMovemment(int id)
        {
            var account = _movementRepository.GetById<MovementDomain.Movement>(id);
            var dto = MovementMapper.MapEntityToDto(account);
            return dto;
        }

        public MovementDomain.Movement GetMovemmentEntity(int id)
        {
            var account = _movementRepository.GetById<MovementDomain.Movement>(id);
            return account;
        }

        public IEnumerable<MovementDto> GetMovemments()
        {
            var account = _movementRepository.GetAll<MovementDomain.Movement>();
            var dto = MovementMapper.MapEntityToDtoCollection(account);
            return dto;
        }
    }
}