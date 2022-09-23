using System.ComponentModel.DataAnnotations.Schema;

namespace Movement.Domain
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
        public string Value { get; set; }
        [Column("Saldo", TypeName = "decimal(18,4)")]
        public decimal Balance { get; set; }
        [Column("CuentaClienteId")]
        public int AccountClientId { get; set; }
        [Column("Estado")]
        public bool Status { get; set; }

    }
}