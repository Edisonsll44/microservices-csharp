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
    public class AccountClientDto
    {
        public int CuentaClienteId { get; set; }
        public string NuemroCuenta { get; set; }
        public decimal Saldo { get; set; }
        public bool Estado { get; set; }
        public int CuentaId { get; set; }
        public int ClienteId { get; set; }
    }
}
