using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
    public class Propietario
    {
           [Required]
        public int idPropietario { get; set; }

        [Required]
        public string dniPropietario { get; set; }

        [Required]
        public string apellido { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public string telefono { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string domicilioPersonal { get; set; }
    }
}