using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers
{
    public class PrestamosController : Controller
    {
        private readonly LibraryContext _context;

        public PrestamosController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Prestamos
        public async Task<IActionResult> Index()
        {
            var prestamos = await _context.Prestamos
                                           .Include(p => p.Libro)
                                           .OrderByDescending(p => p.FechaPrestamo)
                                           .ToListAsync();
            return View(prestamos);
        }

        // GET: Prestamos/Create?libroId=...
        public IActionResult Create(int? libroId)
        {
            if (libroId == null) return NotFound();

            var libro = _context.Libros.FirstOrDefault(l => l.Id == libroId.Value);
            if (libro == null) return NotFound();

            var prestamo = new Prestamo
            {
                LibroId = libro.Id,
                FechaPrestamo = DateTime.Now,
                Estado = "Activo"
            };
            return View(prestamo);
        }

        public IActionResult Create(int libroId)
        {
            var libro = _context.Libros.FirstOrDefault(l => l.Id == libroId);
            if (libro == null)
            {
                return NotFound();
            }

            var prestamo = new Prestamo
            {
                LibroId = libro.Id,
                Libro = libro,
                FechaPrestamo = DateTime.Now,
                Estado = "Activo"
            };

            return View(prestamo);
        }


        // POST: Prestamos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LibroId,FechaPrestamo,Estado")] Prestamo prestamo)
        {
            if (!ModelState.IsValid) return View(prestamo);

            var libro = await _context.Libros.FindAsync(prestamo.LibroId);
            if (libro == null)
            {
                ModelState.AddModelError("LibroId", "Libro no encontrado.");
                return View(prestamo);
            }

            if (libro.Estado == "Prestado")
            {
                ModelState.AddModelError("", "El libro ya está prestado.");
                return View(prestamo);
            }

            prestamo.Estado = "Activo";
            _context.Prestamos.Add(prestamo);

            libro.Estado = "Prestado";
            _context.Libros.Update(libro);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Prestamos/Return/5  -> Opcional: muestra confirmación
        public async Task<IActionResult> Return(int? id)
        {
            if (id == null) return NotFound();

            var prestamo = await _context.Prestamos
                                         .Include(p => p.Libro)
                                         .FirstOrDefaultAsync(p => p.Id == id.Value);

            if (prestamo == null) return NotFound();

            // Si ya está devuelto, redirigimos al Index
            if (prestamo.Estado != "Activo")
                return RedirectToAction(nameof(Index));

            return View(prestamo); // Ver Views/Prestamos/Return.cshtml (opcional)
        }

        // POST: Prestamos/Return/5 -> efectúa la devolución
        [HttpPost, ActionName("Return")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReturnConfirmed(int id)
        {
            var prestamo = await _context.Prestamos
                                         .Include(p => p.Libro)
                                         .FirstOrDefaultAsync(p => p.Id == id);

            if (prestamo == null) return NotFound();

            if (prestamo.Estado == "Activo")
            {
                prestamo.Estado = "Devuelto";
                if (prestamo.Libro != null)
                {
                    prestamo.Libro.Estado = "Disponible";
                    _context.Libros.Update(prestamo.Libro);
                }

                _context.Prestamos.Update(prestamo);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
