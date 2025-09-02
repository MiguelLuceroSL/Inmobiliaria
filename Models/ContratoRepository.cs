using MySql.Data.MySqlClient;

namespace Inmobiliaria.Models
{
    public class ContratoRepository
    {
        private readonly string connectionString = "server=localhost;database=inmobiliaria;user=root;password=;";

        public List<ContratoDetalle> GetAllConDetalles()
        {
            var lista = new List<ContratoDetalle>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = @"SELECT c.id_contrato, c.fecha_inicio, c.fecha_fin, c.monto,
                           i.nombre AS nombre_inquilino,
                           im.descripcion, im.direccion
                    FROM contratos c
                    JOIN inquilinos i ON c.id_inquilino = i.id_inquilino
                    JOIN inmuebles im ON c.id_inmueble = im.id_inmueble";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lista.Add(new ContratoDetalle
                        {
                            idContrato = reader.GetInt32("id_contrato"),
                            fechaInicio = reader.GetDateTime("fecha_inicio"),
                            fechaFin = reader.GetDateTime("fecha_fin"),
                            monto = reader.GetDecimal("monto"),
                            nombreInquilino = reader.GetString("nombre_inquilino"),
                            descripcionInmueble = reader.GetString("descripcion"),
                            direccionInmueble = reader.GetString("direccion")
                        });
                    }
                }
            }
            foreach (var contratoEach in lista)
            {
                Console.WriteLine(
                    $"Contrato {contratoEach.idContrato}: Inquilino {contratoEach.nombreInquilino} | " +
                    $"Inmueble: {contratoEach.descripcionInmueble} - {contratoEach.direccionInmueble}"
                );
            }
            return lista;
        }
    }
}