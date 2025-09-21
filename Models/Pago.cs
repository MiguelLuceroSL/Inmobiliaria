namespace Inmobiliaria.Models
{
    public class Pago
    {
        public int idPago { get; set; }
        public int idContrato { get; set; }
        public int numeroPago { get; set; }   //para saber si es el primer, segundo, tercer pago, etc..
        public DateTime fechaPago { get; set; }
        public string detalle { get; set; }
        public decimal importe { get; set; }
        public bool anulado { get; set; }  //por si se anuló el pago, en el caso de que se haya hecho mal
    }
}
