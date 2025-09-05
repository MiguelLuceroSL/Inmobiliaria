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
                var sql = @"SELECT c.id_contrato, c.fecha_desde, c.fecha_hasta, c.monto,
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
                            fechaDesde = reader.GetDateTime("fecha_desde"),
                            fechaHasta = reader.GetDateTime("fecha_hasta"),
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

        public int Alta(Contrato c)
        {
            int res = -1;
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = @"INSERT INTO contratos
                           (id_inquilino, id_inmueble, monto, fecha_desde, fecha_hasta) 
                           VALUES (@idInquilino, @idInmueble, @monto, @fechaDesde, @fechaHasta);
                           SELECT LAST_INSERT_ID();";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@idInquilino", c.idInquilino);
                    cmd.Parameters.AddWithValue("@idInmueble", c.idInmueble);
                    cmd.Parameters.AddWithValue("@monto", c.monto);
                    cmd.Parameters.AddWithValue("@fechaDesde", c.fechaDesde);
                    cmd.Parameters.AddWithValue("@fechaHasta", c.fechaHasta);
                    res = Convert.ToInt32(cmd.ExecuteScalar());
                    c.idContrato = res;
                    conn.Close();
                }
            }
            return res;
        }

        public Contrato ObtenerPorId(int id)
        {
            Contrato c = new Contrato();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT * FROM contratos WHERE id_contrato=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        c = new Contrato
                        {
                            idContrato = reader.GetInt32("id_contrato"),
                            idInquilino = reader.GetInt32("id_inquilino"),
                            idInmueble = reader.GetInt32("id_inmueble"),
                            monto = reader.GetDecimal("monto"),
                            fechaDesde = reader.GetDateTime("fecha_desde"),
                            fechaHasta = reader.GetDateTime("fecha_hasta")
                        };
                    }
                }
            }
            return c;
        }

        public int Editar(Contrato c)
        {
            int res = -1;
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = @"UPDATE contratos SET 
                           id_inquilino=@idInquilino, 
                           id_inmueble=@idInmueble, 
                           monto=@monto, 
                           fecha_desde=@fechaDesde, 
                           fecha_hasta=@fechaHasta
                           WHERE id_contrato=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@idInquilino", c.idInquilino);
                    cmd.Parameters.AddWithValue("@idInmueble", c.idInmueble);
                    cmd.Parameters.AddWithValue("@monto", c.monto);
                    cmd.Parameters.AddWithValue("@fechaDesde", c.fechaDesde);
                    cmd.Parameters.AddWithValue("@fechaHasta", c.fechaHasta);
                    cmd.Parameters.AddWithValue("@id", c.idContrato);
                    res = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            return res;
        }

        public int Borrar(int id)
        {
            int res = -1;
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = "DELETE FROM contratos WHERE id_contrato=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    res = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            return res;
        }
    }
}