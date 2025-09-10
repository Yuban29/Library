using System;
using System.Linq;
using LibraryManagement.Models;


namespace LibraryManagement.Data
{
    public static class DbInitializer
    {
        public static void Initialize(LibraryContext context)
        {
            if (context.Libros.Any())
            {
                return; // DB ya contiene datos
            }


            var libros = new Libro[]
            {
new Libro{ Id = 1, Titulo = "Cien años de soledad", Autor = "Gabriel García Márquez", Imagen = "/images/Libros/cien_anos.jpg", Estado = "Disponible" },
new Libro{ Id = 2, Titulo = "Don Quijote de la Mancha", Autor = "Miguel de Cervantes", Imagen = "/Images/Libros/quijote.jpg", Estado = "Disponible" },
new Libro{ Id = 3, Titulo = "El Principito", Autor = "Antoine de Saint-Exupéry", Imagen = "/images/Libros/principito.jpg", Estado = "Disponible" }
            };


            context.Libros.AddRange(libros);
            context.SaveChanges();


            // Algunos préstamos y reservas de ejemplo
            var prestamo = new Prestamo
            {
                LibroId = 2,
                FechaPrestamo = DateTime.Now.AddDays(-5),
                Estado = "Activo"
            };


            // cuando hay un préstamo activo, marcamos el libro como "Prestado"
            var libroPrestado = context.Libros.FirstOrDefault(l => l.Id == prestamo.LibroId);
            if (libroPrestado != null) libroPrestado.Estado = "Prestado";


            var reserva = new Reserva
            {
                LibroId = 3,
                FechaReserva = DateTime.Now.AddDays(-1),
                Estado = "Activa"
            };


            // cuando hay reserva, marcamos libro como "Reservado"
            var libroReservado = context.Libros.FirstOrDefault(l => l.Id == reserva.LibroId);
            if (libroReservado != null) libroReservado.Estado = "Reservado";


            context.Prestamos.Add(prestamo);
            context.Reservas.Add(reserva);


            context.SaveChanges();
        }
    }
}
