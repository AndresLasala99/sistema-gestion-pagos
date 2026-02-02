namespace ClienteHttpMVC.DTOs
{
    public class AuditoriaDTO
    {
        public int Id { get; set; }
        public TipoAccion Accion { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
        public int IdGasto { get; set; }
    }
}
