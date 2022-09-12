using Movement.Mapper.Dto;

namespace Movement.Rules.Business
{
    public interface IBalanceValidator
    {
        Task BalanceCeroValidator(MovementDto movementDto);
    }
}