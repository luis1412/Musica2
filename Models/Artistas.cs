namespace Musica2.Models
{
    public class Artistas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int numeroCanciones { get; set; }
        public int oyentesMensuales { get; set; }
        public List<Canciones> Canciones { get; set; }

    }
}
