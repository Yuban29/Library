using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LibraryManagement.Models
{
    public class Prestamo
    {
        public int Id { get; set; }


        [Required]
        [Display(Name = "LibroId")]
        public int LibroId { get; set; }


        public Libro? Libro { get; set; }


        [Required]
        [Display(Name = "Fecha de Préstamo")]
        public DateTime FechaPrestamo { get; set; }


        // "Activo", "Devuelto"
        [Required]
        public string Estado { get; set; } = "Activo";
    }
}