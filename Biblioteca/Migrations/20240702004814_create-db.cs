using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class createdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    IdAutor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Bibliografia = table.Column<string>(type: "longtext", nullable: false),
                    Nascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Falecimento = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.IdAutor);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    IdGenero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.IdGenero);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    IdLivro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "longtext", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: false),
                    AnoPublicacao = table.Column<string>(type: "longtext", nullable: false),
                    NPaginas = table.Column<int>(type: "int", nullable: false),
                    FotoLivro = table.Column<string>(type: "longtext", nullable: true),
                    IdAutor = table.Column<int>(type: "int", nullable: false),
                    IdGenero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.IdLivro);
                    table.ForeignKey(
                        name: "FK_Livros_Autores_IdAutor",
                        column: x => x.IdAutor,
                        principalTable: "Autores",
                        principalColumn: "IdAutor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livros_Generos_IdGenero",
                        column: x => x.IdGenero,
                        principalTable: "Generos",
                        principalColumn: "IdGenero",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Autores",
                columns: new[] { "IdAutor", "Bibliografia", "Falecimento", "Nascimento", "Nome" },
                values: new object[,]
                {
                    { 1, "Nasceu em Boston, EUA. Publicou seu primeiro livro 'Tamerlane and Other Poems' em 1827.", null, new DateTime(1809, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Edgar Allan Poe" },
                    { 2, "Nasceu em Edimburgo, Escócia. Publicou seu primeiro livro 'A Study in Scarlet' em 1887.", null, new DateTime(1859, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arthur Conan Doyle" },
                    { 3, "Nasceu em Providence, EUA. Publicou seu primeiro livro 'The Alchemist' em 1916.", null, new DateTime(1890, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "H. P. Lovecraft" },
                    { 4, "Nasceu em Londres, Inglaterra. Publicou seu primeiro livro 'Frankenstein' em 1818.", null, new DateTime(1797, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mary Shelly" },
                    { 5, "Nasceu em Torquay, Inglaterra. Publicou seu primeiro livro 'The Mysterious Affair at Styles' em 1920.", null, new DateTime(1890, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agatha Christie" },
                    { 6, "Nasceu em Portland, EUA. Publicou seu primeiro livro 'Carrie' em 1974.", null, new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stephen King" },
                    { 7, "Nasceu em Dublin, Irlanda. Publicou seu primeiro livro 'The Snake's Pass' em 1890.", null, new DateTime(1847, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bram Stoker" }
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "IdGenero", "Nome" },
                values: new object[,]
                {
                    { 1, "Terror" },
                    { 2, "Romance" },
                    { 3, "Investigação Policial" }
                });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "IdLivro", "AnoPublicacao", "Descricao", "FotoLivro", "IdAutor", "IdGenero", "NPaginas", "Titulo" },
                values: new object[,]
                {
                    { 1, "1845", "Poema narrativo sobre um homem atormentado pelo corvo que visita sua casa durante a noite.", null, 1, 1, 100, "O Corvo" },
                    { 2, "1843", "Conto psicológico que explora a culpa e a paranoia de um assassino que acredita ouvir o coração da vítima batendo sob o assoalho.", null, 1, 1, 120, "O Coração Delator" },
                    { 3, "1887", "Primeiro romance de Sherlock Holmes, onde ele e Dr. Watson investigam um assassinato misterioso.", null, 2, 3, 200, "Um Estudo em Vermelho" },
                    { 4, "1902", "Sherlock Holmes investiga uma lenda sobre um cão fantasmagórico que assombra a família Baskerville.", null, 2, 3, 180, "O Cão dos Baskervilles" },
                    { 5, "1928", "Conto que introduz o horror cósmico de Cthulhu, uma entidade antiga que aguarda adormecida.", null, 3, 1, 150, "A Chamada de Cthulhu" },
                    { 6, "1936", "Uma expedição à Antártica descobre ruínas antigas e criaturas terríveis que desafiam a compreensão humana.", null, 3, 1, 170, "Nas Montanhas da Loucura" },
                    { 7, "1818", "Um cientista cria uma criatura grotesca em um experimento ousado que desafia os limites da ciência e da moralidade.", null, 4, 1, 220, "Frankenstein" },
                    { 8, "1819", "Uma jovem luta com sentimentos proibidos por seu pai distante e se vê envolvida em um dilema emocional intenso.", null, 4, 2, 130, "Mathilda" },
                    { 9, "1926", "Um dos mais famosos romances policiais de Agatha Christie, conhecido por seu final surpreendente.", null, 5, 3, 190, "O Assassinato de Roger Ackroyd" },
                    { 10, "1934", "Hercule Poirot investiga um assassinato ocorrido em um luxuoso trem europeu.", null, 5, 3, 210, "Assassinato no Expresso Oriente" },
                    { 11, "1977", "Um escritor aceita um emprego como zelador de um hotel isolado e descobre que o local abriga segredos aterrorizantes.", null, 6, 1, 240, "O Iluminado" },
                    { 12, "1986", "Um grupo de crianças enfrenta seus medos mais profundos quando um mal antigo ressurge na cidade de Derry.", null, 6, 1, 280, "It: A Coisa" },
                    { 13, "1897", "O clássico romance que introduziu o lendário vampiro Conde Drácula ao mundo.", null, 7, 1, 260, "Drácula" },
                    { 14, "1903", "Um arqueólogo britânico desafia antigas maldições ao desenterrar um túmulo egípcio em Londres.", null, 7, 2, 150, "O Diamante das Sete Estrelas" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livros_IdAutor",
                table: "Livros",
                column: "IdAutor");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_IdGenero",
                table: "Livros",
                column: "IdGenero");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
