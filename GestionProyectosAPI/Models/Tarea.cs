using System.ComponentModel.DataAnnotations;

namespace GestionProyectosAPI.Models
{
    public enum EstadoTarea
    {
        Pendiente,
        EnProgreso,
        Completada
    }

    public class Tarea
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción de la tarea es obligatoria.")]
        [MinLength(5, ErrorMessage = "La descripción debe tener al menos 5 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La tarea debe tener un estado.")]
        public EstadoTarea Estado { get; set; }

        // Clave foránea para Proyecto
        [Required(ErrorMessage = "La tarea debe estar asociada a un proyecto.")]
        public int ProyectoId { get; set; }

        // Navegación
        public Proyecto Proyecto { get; set; }
    }
}
