using System.ComponentModel.DataAnnotations;

namespace GestionProyectosAPI.DTOs
{
    public class EquipoCreateDto
    {
        [Required(ErrorMessage = "El nombre del equipo es obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres.")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
    }
}
