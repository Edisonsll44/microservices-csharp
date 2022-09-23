using System.ComponentModel.DataAnnotations.Schema;

namespace AccountDomain
{
    [Table("CuentaCliente", Schema = "account")]
    public class AccountClient
    {
        [Column("Id")]
        public int AccountClientId { get; set; }
        [Column("NumeroCuenta")]
        public string AccountNumber { get; set; }
        [Column("Saldo", TypeName = "decimal(18,4)")]
        public decimal Balance { get; set; }
        [Column("Estado")]
        public bool State { get; set; }

        [Column("ClienteId")]
        public int ClientId { get; set; }


        [Column("CuentaId")]
        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}
