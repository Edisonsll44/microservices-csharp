using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientDomain
{
    [Table("Cliente")]
    public class Client : Person
    {
        [Column("Id")]
        public int ClientId { get; set; }
        [Column("Contrasenia")]
        [StringLength(10)]
        public string Pasword { get; set; }
        [Column("Estado")]
        public bool State { get; set; }
    }
}