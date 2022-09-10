namespace Movement.Mapper.Dto
{
    public class MovementDto
    {
        public int MovimientoId { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public int CuentaId { get; set; }
    }
}
