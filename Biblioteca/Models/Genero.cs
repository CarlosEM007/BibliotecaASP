using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Genero
    {
        [Key]
        public int IdGenero { get; set; }
        [Required(ErrorMessage = "Campo Necessário!")]
        public string Nome { get; set; }
    }
}
