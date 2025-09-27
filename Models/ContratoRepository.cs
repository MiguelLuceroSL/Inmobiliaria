using MySql.Data.MySqlClient;

namespace Inmobiliaria.Models
{
    public class ContratoRepository
    {
        private readonly string connectionString = "server=localhost;database=inmobiliaria;user=root;password=;";

        public List<ContratoDetalle> GetAllConDetalles()
        {
            var lista = new List<ContratoDetalle>();
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var sql = @"SELECT c.id_contrato, c.fecha_desde, c.fecha_hasta, c.cuota_mensual, c.estado_contrato, c.al_dia, c.fecha_rescision, c.cancelado_por,
                                    i.nombre AS nombre_inquilino,
                                    im.descripcion, im.direccion
                                FROM contratos c
                                JOIN inquilinos i ON c.id_inquilino = i.id_inquilino
                                JOIN inmuebles im ON c.id_inmueble = im.id_inmueble";

                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ContratoDetalle
                            {
                                idContrato = reader.GetInt32("id_contrato"),
                                fechaDesde = reader.GetDateTime("fecha_desde"),
                                fechaHasta = reader.GetDateTime("fecha_hasta"),
                                cuotaMensual = reader.GetDecimal("cuota_mensual"),
                                estadoContrato = reader.IsDBNull(reader.GetOrdinal("estado_contrato"))
                                    ? string.Empty
                                    : reader.GetString("estado_contrato"),
                                alDia = reader.IsDBNull(reader.GetOrdinal("al_dia"))
                                    ? (bool?)null
                                    : reader.GetBoolean("al_dia"),
                                fechaRescision = reader.IsDBNull(reader.GetOrdinal("fecha_rescision"))
                                    ? null
                                    : reader.GetDateTime("fecha_rescision"),
                                canceladoPor = reader.IsDBNull(reader.GetOrdinal("cancelado_por"))
                                    ? null
                                    : reader.GetString("cancelado_por"),
                                nombreInquilino = reader.IsDBNull(reader.GetOrdinal("nombre_inquilino"))
                                    ? string.Empty
                                    : reader.GetString("nombre_inquilino"),
                                descripcionInmueble = reader.IsDBNull(reader.GetOrdinal("descripcion"))
                                    ? string.Empty
                                    : reader.GetString("descripcion"),
                                direccionInmueble = reader.IsDBNull(reader.GetOrdinal("direccion"))
                                    ? string.Empty
                                    : reader.GetString("direccion")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener los contratos", ex);
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
                           (id_inquilino, id_inmueble, cuota_mensual, estado_contrato, al_dia, fecha_rescision, cancelado_por, fecha_desde, fecha_hasta) 
                           VALUES (@idInquilino, @idInmueble, @cuotaMensual, @estadoContrato, @alDia, @fechaRescision, @canceladoPor, @fechaDesde, @fechaHasta);
                           SELECT LAST_INSERT_ID();";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@idInquilino", c.idInquilino);
                    cmd.Parameters.AddWithValue("@idInmueble", c.idInmueble);
                    cmd.Parameters.AddWithValue("@cuotaMensual", c.cuotaMensual);
                    cmd.Parameters.AddWithValue("@estadoContrato", c.estadoContrato);
                    cmd.Parameters.AddWithValue("@alDia", c.alDia);
                    cmd.Parameters.AddWithValue("@fechaRescision", c.fechaRescision);
                    cmd.Parameters.AddWithValue("@canceladoPor", c.canceladoPor);
                    cmd.Parameters.AddWithValue("@fechaDesde", c.fechaDesde);
                    cmd.Parameters.AddWithValue("@fechaHasta", c.fechaHasta);
                    res = Convert.ToInt32(cmd.ExecuteScalar());
                    c.idContrato = res;
                    conn.Close();
                }
            }
            return res;
        }

        public bool ExisteContratoEnRango(int idInmueble, DateTime fechaDesde, DateTime fechaHasta)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = @"SELECT COUNT(*) 
                    FROM contratos 
                    WHERE id_inmueble = @idInmueble 
                      AND estado_contrato = 'Vigente'
                      AND (
                          (fecha_desde <= @fechaHasta AND fecha_hasta >= @fechaDesde)
                      )";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@idInmueble", idInmueble);
                    cmd.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                    cmd.Parameters.AddWithValue("@fechaHasta", fechaHasta);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
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
                            cuotaMensual = reader.GetDecimal("cuota_mensual"),
                            estadoContrato = reader.IsDBNull(reader.GetOrdinal("estado_contrato"))
                                ? string.Empty
                                : reader.GetString("estado_contrato"),
                            alDia = reader.IsDBNull(reader.GetOrdinal("al_dia"))
                                ? (bool?)null
                                : reader.GetBoolean("al_dia"),
                            fechaRescision = reader.IsDBNull(reader.GetOrdinal("fecha_rescision"))
                            ? null
                            : reader.GetDateTime("fecha_rescision"),
                            canceladoPor = reader.IsDBNull(reader.GetOrdinal("cancelado_por"))
                            ? null
                            : reader.GetString("cancelado_por"),
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
                           cuota_mensual=@cuotaMensual, 
                           estado_contrato=@estadoContrato, 
                           al_dia=@alDia, 
                           fecha_rescision=@fechaRescision, 
                           cancelado_por=@canceladoPor, 
                           fecha_desde=@fechaDesde, 
                           fecha_hasta=@fechaHasta
                           WHERE id_contrato=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@idInquilino", c.idInquilino);
                    cmd.Parameters.AddWithValue("@idInmueble", c.idInmueble);
                    cmd.Parameters.AddWithValue("@cuotaMensual", c.cuotaMensual);
                    cmd.Parameters.AddWithValue("@estadoContrato", c.estadoContrato);
                    cmd.Parameters.AddWithValue("@alDia", c.alDia);
                    cmd.Parameters.AddWithValue("@fechaRescision", c.fechaRescision);
                    cmd.Parameters.AddWithValue("@canceladoPor", c.canceladoPor);
                    cmd.Parameters.AddWithValue("@fechaDesde", c.fechaDesde);
                    cmd.Parameters.AddWithValue("@fechaHasta", c.fechaHasta);
                    cmd.Parameters.AddWithValue("@id", c.idContrato);
                    res = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            return res;
        }

        public int cancelarContrato(int idContrato, string anuladoPor)
        {
            int res = -1;
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = "UPDATE contratos SET estado_contrato='Cancelado', cancelado_por=@anuladoPor, fecha_rescision=CURDATE() WHERE id_contrato=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idContrato);
                    cmd.Parameters.AddWithValue("@anuladoPor", anuladoPor);
                    res = cmd.ExecuteNonQuery();
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