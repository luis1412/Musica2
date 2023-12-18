namespace Musica2.Models
{
    public class Artista
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int numeroCanciones { get; set; }
        public long numeroOyentesMensuales { get; set; }

        public Artista() { }
    }
}
