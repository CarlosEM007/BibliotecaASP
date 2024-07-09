using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Campo Necessário!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Necessário!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Necessário!")]
        public string Cpf { get; set; }

        public string UsuarioDesde { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");
    }
}
