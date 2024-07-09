using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    public class Livro
    {
        [Key]
        public int IdLivro { get; set; }

        [Required(ErrorMessage = "Campo Necessário!")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo Necessário!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Necessário!")]
        public string AnoPublicacao { get; set; }

        [Required(ErrorMessage = "Campo Necessário!")]
        public int NPaginas { get; set; }

        public string? FotoLivro { get; set; }

        public int IdAutor;

        [ForeignKey("IdAutor")]
        public Autor Autor { get; set; }

        public int IdGenero;

        [ForeignKey("IdGenero")]
        public Genero Genero { get; set; }
    }
}
