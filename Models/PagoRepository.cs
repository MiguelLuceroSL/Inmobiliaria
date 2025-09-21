using MySql.Data.MySqlClient;

namespace Inmobiliaria.Models
{
    public class PagoRepository
    {
        private readonly string connectionString = "server=localhost;database=inmobiliaria;user=root;password=;";

        public List<Pago> GetByContrato(int idContrato)
        {
            var lista = new List<Pago>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT * FROM pagos WHERE id_contrato=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idContrato);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lista.Add(new Pago
                        {
                            idPago = reader.GetInt32("id_pago"),
                            idContrato = reader.GetInt32("id_contrato"),
                            numeroPago = reader.GetInt32("numero_pago"),
                            fechaPago = reader.GetDateTime("fecha_pago"),
                            detalle = reader.GetString("detalle"),
                            importe = reader.GetDecimal("importe"),
                            anulado = reader.GetBoolean("anulado")
                        });
                    }
                }
            }
            return lista;
        }

        public int Alta(Pago p)
        {
            int res = -1;
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = @"INSERT INTO pagos (id_contrato, numero_pago, fecha_pago, detalle, importe, anulado)
                            VALUES (@idContrato, @numeroPago, @fechaPago, @detalle, @importe, @anulado);
                            SELECT LAST_INSERT_ID();";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@idContrato", p.idContrato);
                    cmd.Parameters.AddWithValue("@numeroPago", p.numeroPago);
                    cmd.Parameters.AddWithValue("@fechaPago", p.fechaPago);
                    cmd.Parameters.AddWithValue("@detalle", p.detalle);
                    cmd.Parameters.AddWithValue("@importe", p.importe);
                    cmd.Parameters.AddWithValue("@anulado", p.anulado);
                    res = Convert.ToInt32(cmd.ExecuteScalar());
                    p.idPago = res;
                }
            }
            return res;
        }

        public int ContarPagosPorContrato(int idContrato)
        {
            int cantidad = 0;
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT COUNT(*) FROM pagos WHERE idContrato = @idContrato";
                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@idContrato", idContrato);
                    connection.Open();
                    cantidad = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return cantidad;
        }

        public int Anular(int idPago)
        {
            int res = -1;
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = "UPDATE pagos SET anulado=1 WHERE id_pago=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idPago);
                    res = cmd.ExecuteNonQuery();
                }
            }
            return res;
        }
    }
}