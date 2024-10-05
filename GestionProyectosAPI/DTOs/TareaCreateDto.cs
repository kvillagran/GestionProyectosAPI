using GestionProyectosAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace GestionProyectosAPI.DTOs
{
    public class TareaCreateDto
    {
        [Required(ErrorMessage = "La descripción de la tarea es obligatoria.")]
        [MinLength(5, ErrorMessage = "La descripción debe tener al menos 5 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La tarea debe tener un estado.")]
        [Range(0, 2, ErrorMessage = "El estado debe ser 0 (Pendiente), 1 (EnProgreso) o 2 (Completada).")]
        public int Estado { get; set; } // 0: Pendiente, 1: EnProgreso, 2: Completada

        [Required(ErrorMessage = "La tarea debe estar asociada a un proyecto.")]
        public int ProyectoId { get; set; }
    }
}
