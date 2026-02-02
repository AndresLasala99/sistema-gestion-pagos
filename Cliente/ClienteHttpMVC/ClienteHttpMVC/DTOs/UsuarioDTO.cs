namespace ClienteHttpMVC.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Pass { get; set; }
        public string Mail { get; set; }
        public RolUsuario Rol { get; set; }
        public int idEquipo { get; set; }
        public string RolSesion { get; set; }
        public string TokenJWT { get; set; }
    }
}
