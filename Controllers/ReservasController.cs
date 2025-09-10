using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers
{
    public class ReservasController : Controller
    {
        private readonly LibraryContext _context;

        public ReservasController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            var reservas = await _context.Reservas
                                         .Include(r => r.Libro)
                                         .OrderByDescending(r => r.FechaReserva)
                                         .ToListAsync();
            return View(reservas);
        }

        // GET: Reservas/Create?libroId=...
        public IActionResult Create(int? libroId)
        {
            if (libroId == null) return NotFound();

            var libro = _context.Libros.FirstOrDefault(l => l.Id == libroId.Value);
            if (libro == null) return NotFound();

            var reserva = new Reserva
            {
                LibroId = libro.Id,
                FechaReserva = DateTime.Now,
                Estado = "Activa"
            };

            return View(reserva);
        }

        // POST: Reservas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LibroId,FechaReserva,Estado")] Reserva reserva)
        {
            if (!ModelState.IsValid) return View(reserva);

            var libro = await _context.Libros.FindAsync(reserva.LibroId);
            if (libro == null)
            {
                ModelState.AddModelError("LibroId", "Libro no encontrado.");
                return View(reserva);
            }

            if (libro.Estado == "Reservado")
            {
                ModelState.AddModelError("", "El libro ya está reservado.");
                return View(reserva);
            }

            reserva.Estado = "Activa";
            _context.Reservas.Add(reserva);

            libro.Estado = "Reservado";
            _context.Libros.Update(libro);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Reservas/Cancel/5 (opcional: confirmación)
        public async Task<IActionResult> Cancel(int? id)
        {
            if (id == null) return NotFound();

            var reserva = await _context.Reservas
                                        .Include(r => r.Libro)
                                        .FirstOrDefaultAsync(r => r.Id == id.Value);

            if (reserva == null) return NotFound();

            if (reserva.Estado != "Activa")
                return RedirectToAction(nameof(Index));

            return View(reserva); // Vista de confirmación opcional
        }

        // POST: Reservas/Cancel/5
        [HttpPost, ActionName("Cancel")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelConfirmed(int id)
        {
            var reserva = await _context.Reservas
                                        .Include(r => r.Libro)
                                        .FirstOrDefaultAsync(r => r.Id == id);

            if (reserva == null) return NotFound();

            if (reserva.Estado == "Activa")
            {
                reserva.Estado = "Cancelada";
                if (reserva.Libro != null)
                {
                    reserva.Libro.Estado = "Disponible";
                    _context.Libros.Update(reserva.Libro);
                }

                _context.Reservas.Update(reserva);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
