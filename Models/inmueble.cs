using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
   
    public class Inmueble
    {
        
        public int idInmueble { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string direccion { get; set; }

        [Required(ErrorMessage = "El tipo es obligatorio")]
        public string tipo { get; set; }

        [Required(ErrorMessage = "La superficie es obligatoria")]
        [Range(0.01, double.MaxValue, ErrorMessage = "La superficie debe ser mayor a 0")]
        public double superficie { get; set; }

        [Required(ErrorMessage = "Debe indicar la cantidad de ambientes")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe haber al menos 1 ambiente")]
        public int ambientes { get; set; }

        [Required(ErrorMessage = "Debe indicar la cantidad de baños")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe haber al menos 1 baño")]
        public int baños { get; set; }

        public bool cochera { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un estado")]
        public string estado { get; set; }

        [Required(ErrorMessage = "Debe incluir una descripción")]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un propietario")]
        public int idPropietario { get; set; }

        // Nuevas propiedades:
        public string? nombrePropietario { get; set; }
        public string? apellidoPropietario { get; set; }
        public string? dniPropietario { get; set; }
        public Propietario? Propietario { get; set; }
    }

}

