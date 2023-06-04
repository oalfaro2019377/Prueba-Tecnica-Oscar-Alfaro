using System.ComponentModel.DataAnnotations;

namespace OscarAlfaroPruebaTecnica.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
    }
}
