using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountMapper.Dto
{
    public class AccountDto
    {
        public int CuentaId { get; set; }
        public string TipoCuenta { get; set; }

    }

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
