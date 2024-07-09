using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }
        [Required(ErrorMessage = "Campo Necessário!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo Necessário!")]
        public string Bibliografia { get; set; }
        [Required(ErrorMessage = "Campo Necessário!")]
        public DateTime Nascimento { get; set; }
        
        public DateTime? Falecimento { get; set; }
    }
}
