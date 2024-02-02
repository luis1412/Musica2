namespace Musica2.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string nombreUsuario { get; set; }
        public DatosBancarios DatosBancarios { get; set; }
        List<CancionesUsuarios> CancionesUsuarios { get; set; }
    }
}
      