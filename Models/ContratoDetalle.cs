namespace Inmobiliaria.Models
{
    public class ContratoDetalle
    {
        public int idContrato { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public decimal montoInicial { get; set; }
        public decimal montoActual { get; set; }
        public decimal cuotaMensual { get; set; }
        public string? estadoContrato { get; set; }
        public Boolean? alDia { get; set; }
        public DateTime? fechaRescision { get; set; }
        public decimal? interesMora { get; set; }

        public string nombreInquilino { get; set; }
        public string descripcionInmueble { get; set; }
        public string direccionInmueble { get; set; }
    }
}