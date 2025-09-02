using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Inmobiliaria.Models
{
    public class InmuebleRepository
    {
        private readonly string connectionString = "server=localhost;database=inmobiliaria;user=root;password=;";

        public List<Inmueble> GetAll()
        {
            var lista = new List<Inmueble>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT * FROM inmuebles";
                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Inmueble
                        {
                            idInmueble = reader.GetInt32("id_inmueble"),
                            direccion = reader.GetString("direccion"),
                            tipo = reader.GetString("tipo"),
                            superficie = reader.GetDouble("superficie"),
                            ambientes = reader.GetInt32("ambientes"),
                            baños = reader.GetInt32("baños"),
                            cochera = reader.GetBoolean("cochera"),
                            estado = reader.GetString("estado"),
                            descripcion = reader.GetString("descripcion"),
                            idPropietario = reader.GetInt32("id_propietario")
                        });
                    }
                }
            }
            return lista;
        }

        public void Alta(Inmueble i)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = @"INSERT INTO inmuebles 
                            (direccion, tipo, superficie, ambientes, baños, cochera, estado, descripcion, id_propietario) 
                            VALUES (@dir, @tipo, @sup, @amb, @ban, @coch, @est, @desc, @prop)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@dir", i.direccion);
                    cmd.Parameters.AddWithValue("@tipo", i.tipo);
                    cmd.Parameters.AddWithValue("@sup", i.superficie);
                    cmd.Parameters.AddWithValue("@amb", i.ambientes);
                    cmd.Parameters.AddWithValue("@ban", i.baños);
                    cmd.Parameters.AddWithValue("@coch", i.cochera);
                    cmd.Parameters.AddWithValue("@est", i.estado);
                    cmd.Parameters.AddWithValue("@desc", i.descripcion);
                    cmd.Parameters.AddWithValue("@prop", i.idPropietario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Inmueble ObtenerPorId(int id)
        {
            Inmueble i = null;
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT * FROM inmuebles WHERE id_inmueble=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            i = new Inmueble
                            {
                                idInmueble = reader.GetInt32("id_inmueble"),
                                direccion = reader.GetString("direccion"),
                                tipo = reader.GetString("tipo"),
                                superficie = reader.GetDouble("superficie"),
                                ambientes = reader.GetInt32("ambientes"),
                                baños = reader.GetInt32("baños"),
                                cochera = reader.GetBoolean("cochera"),
                                estado = reader.GetString("estado"),
                                descripcion = reader.GetString("descripcion"),
                                idPropietario = reader.GetInt32("id_propietario")
                            };
                        }
                    }
                }
            }
            return i;
        }

        public void Editar(Inmueble i)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = @"UPDATE inmuebles 
                            SET direccion=@dir, tipo=@tipo, superficie=@sup, ambientes=@amb, baños=@ban, cochera=@coch, 
                                estado=@est, descripcion=@desc, id_propietario=@prop 
                            WHERE id_inmueble=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@dir", i.direccion);
                    cmd.Parameters.AddWithValue("@tipo", i.tipo);
                    cmd.Parameters.AddWithValue("@sup", i.superficie);
                    cmd.Parameters.AddWithValue("@amb", i.ambientes);
                    cmd.Parameters.AddWithValue("@ban", i.baños);
                    cmd.Parameters.AddWithValue("@coch", i.cochera);
                    cmd.Parameters.AddWithValue("@est", i.estado);
                    cmd.Parameters.AddWithValue("@desc", i.descripcion);
                    cmd.Parameters.AddWithValue("@prop", i.idPropietario);
                    cmd.Parameters.AddWithValue("@id", i.idInmueble);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Borrar(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = "DELETE FROM inmuebles WHERE id_inmueble=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
