using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        public string Avatar { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Clave { get; set; } = string.Empty;

        [Required]
        public string Rol { get; set; } = string.Empty;
    }
}