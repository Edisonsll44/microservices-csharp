using FluentValidation;
using Movement.Mapper.Dto;
using Movement.PersistenceDatabase;
using mov = Movement.Domain;

namespace Movement.Rules.Business
{
    public class BalanceValidator : AbstractValidator<MovementDto>, IBalanceValidator
    {
        private readonly IMovementRepository _movementRepository;

        public BalanceValidator(IMovementRepository movementRepository)
        {
            _movementRepository = movementRepository;
        }

        public async Task BalanceCeroValidator(MovementDto dto)
        {
            ValidateBalance();
            await ExecuteValidation(dto);
        }

        async void ValidateBalance()
        {
            RuleFor(x => x.CuentaId).Must((o, account) => { return CheckBalance(o.CuentaId); }).WithMessage("Saldo no disponible");
            RuleFor(x => x.CuentaId).MustAsync(async (o, account, balance) => await InsufficientBalance(o.CuentaId, o.Saldo, o.TipoMovimiento)).WithMessage("No tiene suficiente saldo");
        }
        bool CheckBalance(int accountId)
        {
            var actualBalance = _movementRepository.Get<mov.Movement>(d => d.AccountClientId == accountId);
            if (actualBalance == null)
                return true;

            return actualBalance.Sum(d => d.Balance) != 0;
        }

        async Task<bool> InsufficientBalance(int accountId, decimal balance, string type)
        {
            var actualBalance = _movementRepository.Get<mov.Movement>(d => d.AccountClientId == accountId);
            if (actualBalance == null)
                return true;
            if (type.Contains("Retiro"))
            {
                if (actualBalance.Sum(d => d.Balance) - balance < 0)
                    throw new Exception("Fondos insuficientes");
            }
            return true;
        }

        async Task ExecuteValidation(MovementDto dto)
        {
            var validacion = await ValidateAsync(dto);
            if (!validacion.IsValid)
                throw new Exception("Error: " + string.Join(", ", validacion?.Errors?.Select(e => e.ErrorMessage)));
        }


    }
}
