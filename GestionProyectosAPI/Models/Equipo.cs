using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionProyectosAPI.Models
{
    public class Equipo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del equipo es obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres.")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        // Relación con Proyectos
        public ICollection<Proyecto> Proyectos { get; set; }
    }
}
