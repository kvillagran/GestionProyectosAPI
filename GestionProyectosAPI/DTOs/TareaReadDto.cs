namespace GestionProyectosAPI.DTOs
{
    public class TareaReadDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; } // "Pendiente", "EnProgreso", "Completada"
        public ProyectoSimplificadoDto Proyecto { get; set; }
    }
}
