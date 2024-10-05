using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionProyectosAPI.Models
{
    public class Proyecto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del proyecto es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
        public string Nombre { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }

        // Clave foránea para Equipo
        [Required(ErrorMessage = "El proyecto debe estar asociado a un equipo.")]
        public int EquipoId { get; set; }

        // Navegación
        public Equipo Equipo { get; set; }

        // Relación con Tareas
        public ICollection<Tarea> Tareas { get; set; }
    }
}
