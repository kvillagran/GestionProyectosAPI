namespace GestionProyectosAPI.DTOs
{
    namespace GestionProyectosAPI.DTOs
    {
        public class ProyectoReadDto
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }
            public EquipoSimplificadoDto Equipo { get; set; }
            public List<TareaSimplificadaDto> Tareas { get; set; }
        }
    }
}
