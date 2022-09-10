using Movement.Mapper.Dto;
using mov = MovementDomain;

namespace Movement.Mapper
{
    public static class MovementMapper
    {
        public static MovementDto MapEntityToDto(mov.Movement movement)
        {
            return new MovementDto
            {
                CuentaId = movement.AccountId,
                FechaMovimiento = movement.MovementDate,
                MovimientoId = movement.MovementId,
                Saldo = movement.Balance,
                TipoMovimiento = movement.MovementType,
                Valor = movement.Value
            };
        }

        public static mov.Movement MapDtoToEntity(MovementDto movement)
        {
            return new mov.Movement
            {
                AccountId = movement.CuentaId,
                Balance = movement.Saldo,
                MovementDate = movement.FechaMovimiento,
                MovementId = movement.MovimientoId,
                MovementType = movement.TipoMovimiento,
                Value = movement.Valor
            };
        }

        public static mov.Movement MapDtoToEntity(mov.Movement movement, MovementDto dto)
        {
            movement.AccountId = dto.CuentaId;
            movement.MovementId = dto.MovimientoId;
            movement.MovementDate = dto.FechaMovimiento;
            movement.MovementType = dto.TipoMovimiento;
            movement.Balance = dto.Saldo;
            movement.Value = dto.Valor;
            return movement;
        }

        public static IEnumerable<MovementDto> MapEntityToDtoCollection(IEnumerable<mov.Movement> movements)
        {
            var clientsDto = new List<MovementDto>();
            foreach (var movement in movements)
            {
                var dto = new MovementDto
                {
                    CuentaId = movement.AccountId,
                    FechaMovimiento = movement.MovementDate,
                    MovimientoId = movement.MovementId,
                    Saldo = movement.Balance,
                    TipoMovimiento = movement.MovementType,
                    Valor = movement.Value
                };
                clientsDto.Add(dto);
            }
            return clientsDto;
        }
    }
}