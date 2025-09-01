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
                            Id_Inmueble = reader.GetInt32("id_inmueble"),
                            Direccion = reader.GetString("direccion"),
                            Tipo = reader.GetString("tipo"),
                            Superficie = reader.GetDouble("superficie"),
                            Ambientes = reader.GetInt32("ambientes"),
                            Baños = reader.GetInt32("baños"),
                            Cochera = reader.GetBoolean("cochera"),
                            Estado = reader.GetString("estado"),
                            Descripcion = reader.GetString("descripcion"),
                            Id_Propietario = reader.GetInt32("id_propietario")
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
                    cmd.Parameters.AddWithValue("@dir", i.Direccion);
                    cmd.Parameters.AddWithValue("@tipo", i.Tipo);
                    cmd.Parameters.AddWithValue("@sup", i.Superficie);
                    cmd.Parameters.AddWithValue("@amb", i.Ambientes);
                    cmd.Parameters.AddWithValue("@ban", i.Baños);
                    cmd.Parameters.AddWithValue("@coch", i.Cochera);
                    cmd.Parameters.AddWithValue("@est", i.Estado);
                    cmd.Parameters.AddWithValue("@desc", i.Descripcion);
                    cmd.Parameters.AddWithValue("@prop", i.Id_Propietario);
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
                                Id_Inmueble = reader.GetInt32("id_inmueble"),
                                Direccion = reader.GetString("direccion"),
                                Tipo = reader.GetString("tipo"),
                                Superficie = reader.GetDouble("superficie"),
                                Ambientes = reader.GetInt32("ambientes"),
                                Baños = reader.GetInt32("baños"),
                                Cochera = reader.GetBoolean("cochera"),
                                Estado = reader.GetString("estado"),
                                Descripcion = reader.GetString("descripcion"),
                                Id_Propietario = reader.GetInt32("id_propietario")
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
                    cmd.Parameters.AddWithValue("@dir", i.Direccion);
                    cmd.Parameters.AddWithValue("@tipo", i.Tipo);
                    cmd.Parameters.AddWithValue("@sup", i.Superficie);
                    cmd.Parameters.AddWithValue("@amb", i.Ambientes);
                    cmd.Parameters.AddWithValue("@ban", i.Baños);
                    cmd.Parameters.AddWithValue("@coch", i.Cochera);
                    cmd.Parameters.AddWithValue("@est", i.Estado);
                    cmd.Parameters.AddWithValue("@desc", i.Descripcion);
                    cmd.Parameters.AddWithValue("@prop", i.Id_Propietario);
                    cmd.Parameters.AddWithValue("@id", i.Id_Inmueble);
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
