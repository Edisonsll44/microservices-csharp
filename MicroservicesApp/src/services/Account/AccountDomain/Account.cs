using System.ComponentModel.DataAnnotations.Schema;

namespace AccountDomain
{
    [Table("Cuenta", Schema = "account")]
    public class Account
    {
        [Column("Id")]
        public int AccountId { get; set; }
        [Column("NumeroCuenta")]
        public string AccountNumber { get; set; }
        [Column("TipoCuenta")]
        public string AccountType { get; set; }
        [Column("Saldo")]
        public decimal Balance { get; set; }
        [Column("Estado")]
        public bool State { get; set; }
    }
}