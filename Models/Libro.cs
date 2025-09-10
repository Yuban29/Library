using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace LibraryManagement.Models
{
    public class Libro
    {
        public int Id { get; set; }


        [Required]
        public string Titulo { get; set; } = string.Empty;


        [Required]
        public string Autor { get; set; } = string.Empty;


        // Ruta relativa en wwwroot/images o URL
        public string? Imagen { get; set; }


        // "Disponible", "Prestado", "Reservado"
        [Required]
        public string Estado { get; set; } = "Disponible";


        public ICollection<Prestamo>? Prestamos { get; set; }
        public ICollection<Reserva>? Reservas { get; set; }
    }
}
