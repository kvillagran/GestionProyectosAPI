using System.ComponentModel.DataAnnotations;

namespace GestionProyectosAPI.DTOs
{
    public class ProyectoCreateDto
    {
        [Required(ErrorMessage = "El nombre del proyecto es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
        public string Nombre { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "El proyecto debe estar asociado a un equipo.")]
        public int EquipoId { get; set; }
    }
}
