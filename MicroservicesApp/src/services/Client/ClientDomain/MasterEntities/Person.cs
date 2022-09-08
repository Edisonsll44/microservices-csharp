using System.ComponentModel.DataAnnotations;

namespace ClientDomain
{
    public class Person
    {
        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        [StringLength(13)]
        public string Identificacion { get; set; }
        [Required]
        [StringLength(50)]
        public string Direccion { get; set; }
        [Required]
        [StringLength(10)]
        public string Telefono { get; set; }
    }
}
