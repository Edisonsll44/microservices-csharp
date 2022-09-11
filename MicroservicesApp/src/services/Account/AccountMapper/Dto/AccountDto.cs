using MediatR;

namespace AccountMapper.Dto
{
    public class AccountDto : INotification
    {
        public int CuentaId { get; set; }
        public string TipoCuenta { get; set; }

    }

    public class CommandCreateAccountDto : AccountDto { }
    public class CommandUpdateAccountDto : AccountDto { }
    public class CommandCreateAccountClientDto : INotification
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
}
