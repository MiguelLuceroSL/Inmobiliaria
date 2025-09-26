using System.Data;

namespace Inmobiliaria.Models
{
    public class Contrato
    {
        public int idContrato { get; set; }
        public int idInquilino { get; set; }
        public int idInmueble { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public decimal cuotaMensual { get; set; }
        public string? estadoContrato { get; set; }
        public Boolean? alDia { get; set; }
        public DateTime? fechaRescision { get; set; }
        public string? canceladoPor { get; set; }
    }
}