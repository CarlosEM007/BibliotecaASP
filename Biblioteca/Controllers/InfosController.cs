using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers
{
    public class InfosController : Controller
    {
        private readonly AppDataContext _context;
        public InfosController(AppDataContext context)
        {
            _context = context;
        }

        public IActionResult Livro(int id)
        {

            if (id != null)
            {
                // Faz uma consulta usando "Include" para obter o autor e gênero associados ao livro
                Livro livro = _context.Livros
                    .Include(a => a.Autor)
                    .Include(g => g.Genero)
                    .FirstOrDefault(l => l.IdLivro == id);

                if (livro != null)
                {
                    return View(livro); // Passa o modelo livro para a view
                }
            }

            return RedirectToAction("Index"); // Redireciona para a ação Index caso o livro não seja encontrado
        }

        public IActionResult Usuario()
        {
            return View();
        }

        public IActionResult Autor(int id)
        {
            Livro livro = _context.Livros
            .Include(a => a.Autor)
            .FirstOrDefault(a => a.IdAutor == id);

            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }
    }
}
