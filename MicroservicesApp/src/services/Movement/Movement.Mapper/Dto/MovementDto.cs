namespace Movement.Mapper.Dto
{
    public class MovementDto
    {
        public int MovimientoId { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string TipoMovimiento { get; set; }
        public string TipoCuenta { get; set; }
        public decimal Saldo { get; set; }
        public int CuentaId { get; set; }
        public string Cliente { get; set; }
        public string Descripcion { get; set; }
        public string NumeroCuenta { get; set; }
        public string Estado { get; set; }
    }

    public class AccountClientDto
    {
        public int CuentaClienteId { get; set; }
        public string TipoCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public string IdentificacionCliente { get; set; }
        public string NombreCliente { get; set; }
    }

    public class AccountDto
    {
        public int CuentaId { get; set; }
        public string TipoCuenta { get; set; }

    }

    public class CommandCreateAccountClientDto
    {
        public int CuentaClienteId { get; set; }
        public string TipoCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public decimal Saldo { get; set; }
        public bool Estado { get; set; }
        public string EstadoWeb { get; set; }
        public string IdentificacionCliente { get; set; }
        public string NombreCliente { get; set; }
    }

    public class ClientDto
    {
        public int ClientId { get; set; }
        public string Pasword { get; set; }
        public bool State { get; set; }
    }
}
