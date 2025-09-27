namespace Inmobiliaria.Models
{
    public class ContratoDetalle
    {
        public int idContrato { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public decimal cuotaMensual { get; set; }
        public string? estadoContrato { get; set; }
        public DateTime? fechaRescision { get; set; }
        public string? canceladoPor { get; set; }

        public string? nombreInquilino { get; set; }
        public string? descripcionInmueble { get; set; }
        public string direccionInmueble { get; set; }
    }
}