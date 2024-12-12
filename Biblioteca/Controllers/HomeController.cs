using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDataContext _context;
        public HomeController(AppDataContext context)
        {
            _context = context;
        }

        /*
         O Index() recebe como parametro um array que vem do index.cshtml
         no momento em que esse método é usado ele instancia um objeto Filtro que no construtor vai o array recebido
         lá na classe ele vai atribuir aos atributos o valores correspondentes.
         */
        public IActionResult Index(int[] filtros)
        {
            Filtros filtro = new Filtros(filtros);

            //Armazena os valores no objeto filtro
            ViewBag.Filtros = filtro;

            // Preenche o ViewBag com dados necessários para os filtros
            ViewBag.Genero = _context.Generos.ToList();
            ViewBag.Autor = _context.Autores.ToList();

            //Faz uma consulta usando "Inner join" em autor e genero, armazenando todos os dados
            IQueryable<Livro> consulta = _context.Livros
                .Include(a => a.Autor)
                .Include(g => g.Genero);

            //Verifica se há algum autor selecionado
            if (filtro.TemAutor &&  filtro.IdAutor != null)
            {
                /*
                 * Altera a consulta usando a própria consulta
                 * Fazendo ela armazenar somente os Livros em que o IdAutor é igual ao IdAutor selecionado
                 */
                consulta = consulta.Where(a => a.IdAutor == filtro.IdAutor);
            }

            //faz a mesma coisa que o código de cima, porém, para Genero
            if(filtro.TemGenero && filtro.IdGenero != null)
            {
                consulta = consulta.Where(g => g.IdGenero == filtro.IdGenero);
            }

            //Organiza os livros pelo ano de publicação
            var livros = consulta.OrderBy(l => l.AnoPublicacao).ToList();

            return View(livros);
        }

        [HttpPost]
        public IActionResult Filtrar(int[] filtros)
        {
            // Redireciona para a ação Index com os filtros aplicados
            return RedirectToAction("Index", new { filtros = filtros });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
