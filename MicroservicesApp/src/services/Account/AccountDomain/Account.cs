using System.ComponentModel.DataAnnotations.Schema;

namespace AccountDomain
{
    [Table("Cuenta", Schema = "account")]
    public class Account
    {
        [Column("Id")]
        public int AccountId { get; set; }
        [Column("TipoCuenta")]
        public string AccountType { get; set; }

        public ICollection<AccountClient> CuentasCliente { get; set; }
    }
}