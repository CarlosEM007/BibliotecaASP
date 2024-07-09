using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;

namespace Biblioteca.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Usuario> usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Inicialização de Gêneros
            modelBuilder.Entity<Genero>().HasData(
                new Genero { IdGenero = 1, Nome = "Terror" },
                new Genero { IdGenero = 2, Nome = "Romance" },
                new Genero { IdGenero = 3, Nome = "Investigação Policial" }
            );

            // Inicialização de Autores
            modelBuilder.Entity<Autor>().HasData(
                new Autor { IdAutor = 1, Nome = "Edgar Allan Poe", Bibliografia = "Nasceu em Boston, EUA. Publicou seu primeiro livro 'Tamerlane and Other Poems' em 1827.", Nascimento = new DateTime(1809, 1, 19) },
                new Autor { IdAutor = 2, Nome = "Arthur Conan Doyle", Bibliografia = "Nasceu em Edimburgo, Escócia. Publicou seu primeiro livro 'A Study in Scarlet' em 1887.", Nascimento = new DateTime(1859, 5, 22) },
                new Autor { IdAutor = 3, Nome = "H. P. Lovecraft", Bibliografia = "Nasceu em Providence, EUA. Publicou seu primeiro livro 'The Alchemist' em 1916.", Nascimento = new DateTime(1890, 8, 20) },
                new Autor { IdAutor = 4, Nome = "Mary Shelly", Bibliografia = "Nasceu em Londres, Inglaterra. Publicou seu primeiro livro 'Frankenstein' em 1818.", Nascimento = new DateTime(1797, 8, 30) },
                new Autor { IdAutor = 5, Nome = "Agatha Christie", Bibliografia = "Nasceu em Torquay, Inglaterra. Publicou seu primeiro livro 'The Mysterious Affair at Styles' em 1920.", Nascimento = new DateTime(1890, 9, 15) },
                new Autor { IdAutor = 6, Nome = "Stephen King", Bibliografia = "Nasceu em Portland, EUA. Publicou seu primeiro livro 'Carrie' em 1974.", Nascimento = new DateTime(1947, 9, 21) },
                new Autor { IdAutor = 7, Nome = "Bram Stoker", Bibliografia = "Nasceu em Dublin, Irlanda. Publicou seu primeiro livro 'The Snake's Pass' em 1890.", Nascimento = new DateTime(1847, 11, 8) }
            );

            // Inicialização de Livros
            modelBuilder.Entity<Livro>().HasData(
                // Livros de Edgar Allan Poe
                new Livro { IdLivro = 1, Titulo = "O Corvo", Descricao = "Poema narrativo sobre um homem atormentado pelo corvo que visita sua casa durante a noite.", AnoPublicacao = "1845", NPaginas = 100, IdAutor = 1, IdGenero = 1 },
                new Livro { IdLivro = 2, Titulo = "O Coração Delator", Descricao = "Conto psicológico que explora a culpa e a paranoia de um assassino que acredita ouvir o coração da vítima batendo sob o assoalho.", AnoPublicacao = "1843", NPaginas = 120, IdAutor = 1, IdGenero = 1 },

                // Livros de Arthur Conan Doyle
                new Livro { IdLivro = 3, Titulo = "Um Estudo em Vermelho", Descricao = "Primeiro romance de Sherlock Holmes, onde ele e Dr. Watson investigam um assassinato misterioso.", AnoPublicacao = "1887", NPaginas = 200, IdAutor = 2, IdGenero = 3 },
                new Livro { IdLivro = 4, Titulo = "O Cão dos Baskervilles", Descricao = "Sherlock Holmes investiga uma lenda sobre um cão fantasmagórico que assombra a família Baskerville.", AnoPublicacao = "1902", NPaginas = 180, IdAutor = 2, IdGenero = 3 },

                // Livros de H. P. Lovecraft
                new Livro { IdLivro = 5, Titulo = "A Chamada de Cthulhu", Descricao = "Conto que introduz o horror cósmico de Cthulhu, uma entidade antiga que aguarda adormecida.", AnoPublicacao = "1928", NPaginas = 150, IdAutor = 3, IdGenero = 1 },
                new Livro { IdLivro = 6, Titulo = "Nas Montanhas da Loucura", Descricao = "Uma expedição à Antártica descobre ruínas antigas e criaturas terríveis que desafiam a compreensão humana.", AnoPublicacao = "1936", NPaginas = 170, IdAutor = 3, IdGenero = 1 },

                // Livros de Mary Shelly
                new Livro { IdLivro = 7, Titulo = "Frankenstein", Descricao = "Um cientista cria uma criatura grotesca em um experimento ousado que desafia os limites da ciência e da moralidade.", AnoPublicacao = "1818", NPaginas = 220, IdAutor = 4, IdGenero = 1 },
                new Livro { IdLivro = 8, Titulo = "Mathilda", Descricao = "Uma jovem luta com sentimentos proibidos por seu pai distante e se vê envolvida em um dilema emocional intenso.", AnoPublicacao = "1819", NPaginas = 130, IdAutor = 4, IdGenero = 2 },

                // Livros de Agatha Christie
                new Livro { IdLivro = 9, Titulo = "O Assassinato de Roger Ackroyd", Descricao = "Um dos mais famosos romances policiais de Agatha Christie, conhecido por seu final surpreendente.", AnoPublicacao = "1926", NPaginas = 190, IdAutor = 5, IdGenero = 3 },
                new Livro { IdLivro = 10, Titulo = "Assassinato no Expresso Oriente", Descricao = "Hercule Poirot investiga um assassinato ocorrido em um luxuoso trem europeu.", AnoPublicacao = "1934", NPaginas = 210, IdAutor = 5, IdGenero = 3 },

                // Livros de Stephen King
                new Livro { IdLivro = 11, Titulo = "O Iluminado", Descricao = "Um escritor aceita um emprego como zelador de um hotel isolado e descobre que o local abriga segredos aterrorizantes.", AnoPublicacao = "1977", NPaginas = 240, IdAutor = 6, IdGenero = 1 },
                new Livro { IdLivro = 12, Titulo = "It: A Coisa", Descricao = "Um grupo de crianças enfrenta seus medos mais profundos quando um mal antigo ressurge na cidade de Derry.", AnoPublicacao = "1986", NPaginas = 280, IdAutor = 6, IdGenero = 1 },

                // Livros de Bram Stoker
                new Livro { IdLivro = 13, Titulo = "Drácula", Descricao = "O clássico romance que introduziu o lendário vampiro Conde Drácula ao mundo.", AnoPublicacao = "1897", NPaginas = 260, IdAutor = 7, IdGenero = 1 },
                new Livro { IdLivro = 14, Titulo = "O Diamante das Sete Estrelas", Descricao = "Um arqueólogo britânico desafia antigas maldições ao desenterrar um túmulo egípcio em Londres.", AnoPublicacao = "1903", NPaginas = 150, IdAutor = 7, IdGenero = 2 }
            );
        }
    }
}