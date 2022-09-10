using Movement.Mapper.Dto;
using mov = MovementDomain;

namespace Movement.Query.Service
{
    public interface IMovementQueryService
    {
        MovementDto GetMovemment(int id);
        IEnumerable<MovementDto> GetMovemments();

        mov.Movement GetMovemmentEntity(int id);
    }
}
