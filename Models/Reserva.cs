using System;
using System.ComponentModel.DataAnnotations;


namespace LibraryManagement.Models
{
    public class Reserva
    {
        public int Id { get; set; }


        [Required]
        public int LibroId { get; set; }


        public Libro? Libro { get; set; }


        [Required]
        public DateTime FechaReserva { get; set; }


        // "Activa", "Cancelada", "Cumplida"
        [Required]
        public string Estado { get; set; } = "Activa";
    }
}
