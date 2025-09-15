// using System;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc.ModelBinding;

// namespace Inmobiliaria_.Net_Core.Models
// {
//     [Table("Inmuebles")]
//     public class Inmueble
//     {
//         [Key]
//         [Display(Name = "ID Inmueble")]
//         public int Id_Inmueble { get; set; }

//         [Required]
//         [Display(Name = "ID Propietario")]
//         public int Id_Propietario { get; set; }

//         [ForeignKey(nameof(Id_Propietario))]
//         [BindNever]
//         public Propietario? Propietario { get; set; }

//         [Required(ErrorMessage = "La dirección es requerida")]
//         [Display(Name = "Dirección")]
//         public string? Direccion { get; set; }

//         [Required]
//         [Display(Name = "Tipo de Inmueble")]
//         public string? Tipo { get; set; }

//         [Required]
//         [Display(Name = "Superficie (m²)")]
//         public int Superficie { get; set; }

//         [Required]
//         [Display(Name = "Ambientes")]
//         public int Ambientes { get; set; }

//         [Required]
//         [Display(Name = "Baños")]
//         public int Baños { get; set; }

//         [Display(Name = "Cochera")]
//         public bool Cochera { get; set; }

//         [Display(Name = "Estado")]
//         public string? Estado { get; set; }

//         [Display(Name = "Descripción")]
//         public string? Descripcion { get; set; }

//         public string? Portada { get; set; }

//       /*  [NotMapped]
//         public IFormFile? PortadaFile { get; set; }

//       /*  [ForeignKey(nameof(Imagen.InmuebleId))]
//         public IList<Imagen> Imagenes { get; set; } = new List<Imagen>();*/

//         [NotMapped]
//         public bool Habilitado { get; set; } = true;
//     }
// }




// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;


// namespace Inmobiliaria_.Net_Core.Models
// {
//     [Table("Inmuebles")]
//     public class Inmueble
//     {
//         [Key]
//         [Display(Name = "ID Inmueble")]
//         public int Id_Inmueble { get; set; }

//         [Required]
//         [Display(Name = "ID Propietario")]
//         public int Id_Propietario { get; set; }

//         [ForeignKey(nameof(Id_Propietario))]
//         public Propietario? Propietario { get; set; }

//         [Required(ErrorMessage = "La dirección es requerida")]
//         [Display(Name = "Dirección")]
//         public string? Direccion { get; set; }

//         [Required]
//         [Display(Name = "Tipo de Inmueble")]
//         public string? Tipo { get; set; }

//         [Required]
//         [Display(Name = "Superficie (m²)")]
//         public int Superficie { get; set; }

//         [Required]
//         [Display(Name = "Ambientes")]
//         public int Ambientes { get; set; }

//         [Required]
//         [Display(Name = "Baños")]
//         public int Baños { get; set; }

//         [Display(Name = "Cochera")]
//         public bool Cochera { get; set; }

//         [Display(Name = "Estado")]
//         public string? Estado { get; set; }

//         [Display(Name = "Descripción")]
//         public string? Descripcion { get; set; }
//     }
// }


// public class Inmueble
// {
//     public int Id_Inmueble { get; set; }
//     public int IdPropietario { get; set; }
//     public string Direccion { get; set; }
//     public string Tipo { get; set; }
//     public double Superficie { get; set; }
//     public int Ambientes { get; set; }
//     public int Baños { get; set; }
//     public int Cochera { get; set; }
//     public string Estado { get; set; }


//     public string Descripcion { get; set; }

// }
namespace Inmobiliaria.Models
{
    // public class Inmueble
    // {
    //     public int idInmueble { get; set; }
    //     public string direccion { get; set; }
    //     public string tipo { get; set; }
    //     public double superficie { get; set; }
    //     public int ambientes { get; set; }
    //     public int baños { get; set; }
    //     public bool cochera { get; set; }
    //     public string estado { get; set; }
    //     public string descripcion { get; set; }
    //     public int idPropietario { get; set; }
    // }
    public class Inmueble
{
    public int idInmueble { get; set; }
    public string direccion { get; set; }
    public string tipo { get; set; }
    public double superficie { get; set; }
    public int ambientes { get; set; }
    public int baños { get; set; }
    public bool cochera { get; set; }
    public string estado { get; set; }
    public string descripcion { get; set; }
    public int idPropietario { get; set; }

    // Nuevas propiedades:
    public string nombrePropietario { get; set; }
    public string apellidoPropietario { get; set; }
}

}

