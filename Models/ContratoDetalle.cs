namespace Inmobiliaria.Models
{
    public class ContratoDetalle
    {
        public int idContrato { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public decimal monto { get; set; }

        public string nombreInquilino { get; set; }
        public string descripcionInmueble { get; set; }
        public string direccionInmueble { get; set; }
    }
}