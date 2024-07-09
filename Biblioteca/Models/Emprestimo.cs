using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    public class Emprestimo
    {
        [Key]
        public int IdEmprestimo { get; set; }

        public int IdLivro { get; set; }

        [ForeignKey("IdLivro")]
        public Livro Livro { get; set; }

        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }

        public bool Atrasado => DateTime.Today > DataDevolucao;

        public Emprestimo()
        {
            DataEmprestimo = DateTime.Now;
            DataDevolucao = DateTime.Now.AddMonths(1);
        }
    } 
}
