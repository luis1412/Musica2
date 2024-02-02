namespace Musica2.Models
{
    public class CancionesUsuarios
    {
        public Usuarios Usuarios { get; set; }
        public Canciones Canciones { get; set; }
        public int UsuariosId { get; set; }
        public int CancionesId { get; set; } 
    }
}
