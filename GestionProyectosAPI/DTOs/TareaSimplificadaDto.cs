namespace GestionProyectosAPI.DTOs
{
    public class TareaSimplificadaDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; } // Mostrar como texto en las respuestas GET
    }
}
