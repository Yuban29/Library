using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;
using System.Threading.Tasks;
using System.Linq;


namespace LibraryManagement.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _context;


        public BooksController(LibraryContext context)
        {
            _context = context;
        }


        // GET: /Books?search=texto
        public async Task<IActionResult> Index(string? search)
        {
            var query = _context.Libros.AsQueryable();


            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                query = query.Where(b => b.Titulo.ToLower().Contains(search) || b.Autor.ToLower().Contains(search));
            }


            var lista = await query.OrderBy(b => b.Titulo).ToListAsync();
            return View(lista);
        }
    }
}