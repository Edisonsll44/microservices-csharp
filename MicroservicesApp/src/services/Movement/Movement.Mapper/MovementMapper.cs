using Movement.Mapper.Dto;
using mov = Movement.Domain;

namespace Movement.Mapper
{
    public static class MovementMapper
    {
        public static MovementDto MapEntityToDto(mov.Movement movement)
        {
            return new MovementDto
            {
                CuentaId = movement.AccountClientId,
                FechaMovimiento = movement.MovementDate,
                MovimientoId = movement.MovementId,
                Saldo = movement.Balance,
                TipoMovimiento = movement.MovementType,
            };
        }

        public static mov.Movement MapDtoToEntity(MovementDto movement, string tipo, decimal actualBalance)
        {
            return new mov.Movement
            {
                AccountClientId = movement.CuentaId,
                Balance = tipo.Contains("Deposito") ? movement.Saldo + actualBalance : actualBalance - movement.Saldo,
                MovementDate = movement.FechaMovimiento,
                MovementId = movement.MovimientoId,
                MovementType = movement.TipoMovimiento,
            };
        }

        public static mov.Movement MapDtoToEntity(mov.Movement movement, MovementDto dto)
        {
            movement.AccountClientId = dto.CuentaId;
            movement.MovementId = dto.MovimientoId;
            movement.MovementDate = dto.FechaMovimiento;
            movement.MovementType = dto.TipoMovimiento;
            movement.Balance = dto.Saldo;
            return movement;
        }

        public static IEnumerable<MovementDto> MapEntityToDtoCollection(IEnumerable<mov.Movement> movements)
        {
            var clientsDto = new List<MovementDto>();
            foreach (var movement in movements)
            {
                var dto = new MovementDto
                {
                    CuentaId = movement.AccountClientId,
                    FechaMovimiento = movement.MovementDate,
                    MovimientoId = movement.MovementId,
                    Saldo = movement.Balance,
                    TipoMovimiento = movement.MovementType,
                };
                clientsDto.Add(dto);
            }
            return clientsDto;
        }

        public static IEnumerable<MovementDto> MapEntityToDtoCollection(IEnumerable<mov.Movement> movements, string clientName, string dni, IEnumerable<AccountClientDto> accountsClient)
        {
            var clientsDto = new List<MovementDto>();
            foreach (var movement in movements)
            {
                var dto = new MovementDto
                {
                    FechaMovimiento = movement.MovementDate,
                    Cliente = accountsClient.FirstOrDefault(v => v.CuentaClienteId == movement.AccountClientId).NombreCliente,
                    NumeroCuenta = accountsClient.FirstOrDefault(v => v.CuentaClienteId == movement.AccountClientId).NumeroCuenta,
                    TipoCuenta = accountsClient.FirstOrDefault(v => v.CuentaClienteId == movement.AccountClientId).TipoCuenta,
                    Saldo = movement.Balance,
                    Estado = movement.Status ? "True" : "False",
                    Descripcion = movement.MovementType
                };
                clientsDto.Add(dto);
            }
            return clientsDto;
        }
    }
}