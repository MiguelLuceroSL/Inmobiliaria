namespace Inmobiliaria.Models
{
    public class Contrato
    {
        public int Id { get; set; }
        public int InquilinoId { get; set; }
        public int PropietarioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Monto { get; set; }
    }
}