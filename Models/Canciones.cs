namespace Musica2.Models
{
    public class Canciones
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int ArtistasId { get; set; }
        List<CancionesUsuarios> CancionesUsuarios { get; set; }
    }
}
