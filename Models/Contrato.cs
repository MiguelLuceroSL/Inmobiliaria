namespace Inmobiliaria.Models
{
    public class Contrato
    {
        public int idContrato { get; set; }
        public int idInquilino { get; set; }
        public int idInmueble { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public decimal monto { get; set; }
    }
}