namespace Musica2.Models
{
    public class DatosBancarios
    {
        public int Id { get; set; }
        public string IBAN { get; set; }
        public string fechaExpiracion { get; set; }
        public int CVV { get; set; }
        public int UsuariosId { get; set; }

    }
}
