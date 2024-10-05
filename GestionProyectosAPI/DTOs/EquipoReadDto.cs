namespace GestionProyectosAPI.DTOs
{
    public class EquipoReadDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<ProyectoSimplificadoDto> Proyectos { get; set; }
    }
}
