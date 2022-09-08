using System.ComponentModel.DataAnnotations.Schema;

namespace MovementDomain
{
    [Table("Movimientos", Schema = "movement")]
    public class Movement
    {
        [Column("Id")]
        public int MovementId { get; set; }
        [Column("Fechamovimiento")]
        public DateTime MovementDate { get; set; }
        [Column("TipoMovimiento")]
        public string MovementType { get; set; }
        [Column("Tipo")]
        public decimal Value { get; set; }
        [Column("Saldo", TypeName = "decimal(18,4)")]
        public decimal Balance { get; set; }
        [Column("CuentaId")]
        public int AccountId { get; set; }
    }
}