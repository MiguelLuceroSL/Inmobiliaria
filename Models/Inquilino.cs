using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{

    public class Inquilino
    {
        // public int idInquilino { get; set; }
        // public string dniInquilino { get; set; }
        // public string apellido { get; set; }
        // public string nombre { get; set; }
        // public string telefono { get; set; }
        // public string email { get; set; }
        // public string domicilioPersonal { get; set; }



         public int idInquilino { get; set; }

        [Required(ErrorMessage = "El DNI es obligatorio.")]
        public string dniInquilino { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string apellido { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "El teléfono no tiene un formato válido.")]
        public string telefono { get; set; }

        [Required(ErrorMessage = "El email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El email no tiene un formato válido.")]
        public string email { get; set; }

        [Required(ErrorMessage = "El domicilio personal es obligatorio.")]
        public string domicilioPersonal { get; set; }
    }
}