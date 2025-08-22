using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Inmobiliaria.Models
{
    public class PropietarioRepository
    {
        private readonly string connectionString = "server=localhost;database=inmobiliaria;user=root;password=;";

        public List<Propietario> GetAll()
        {
            var lista = new List<Propietario>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT * FROM propietarios";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lista.Add(new Propietario
                        {
                            Id_Propietario = reader.GetInt32("id_propietario"),
                            Dni_Propietario = reader.GetString("dni_propietario"),
                            Apellido = reader.GetString("apellido"),
                            Nombre = reader.GetString("nombre"),
                            Telefono = reader.GetString("telefono"),
                            Email = reader.GetString("email"),
                            Domicilio_Personal = reader.GetString("domicilio_personal")
                        });
                    }
                }
            }
            Console.WriteLine($"Total Propietarios: {lista.Count}");
            Console.WriteLine("QQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQ:");
            Console.WriteLine("Propietarios List:");
            foreach (var propietario in lista)
            {
                Console.WriteLine($"- {propietario.Apellido}, {propietario.Nombre} ({propietario.Dni_Propietario})");
            }
            return lista;
        }

        public void Alta(Propietario p)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = @"INSERT INTO propietarios 
                           (dni_propietario, apellido, nombre, telefono, email, domicilio_personal) 
                           VALUES (@dni, @ape, @nom, @tel, @mail, @dom)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@dni", p.Dni_Propietario);
                    cmd.Parameters.AddWithValue("@ape", p.Apellido);
                    cmd.Parameters.AddWithValue("@nom", p.Nombre);
                    cmd.Parameters.AddWithValue("@tel", p.Telefono);
                    cmd.Parameters.AddWithValue("@mail", p.Email);
                    cmd.Parameters.AddWithValue("@dom", p.Domicilio_Personal);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Propietario ObtenerPorId(int id)
        {
            Propietario p = new Propietario();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT * FROM propietarios WHERE id_propietario=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        p = new Propietario
                        {
                            Id_Propietario = reader.GetInt32("id_propietario"),
                            Dni_Propietario = reader.GetString("dni_propietario"),
                            Apellido = reader.GetString("apellido"),
                            Nombre = reader.GetString("nombre"),
                            Telefono = reader.GetString("telefono"),
                            Email = reader.GetString("email"),
                            Domicilio_Personal = reader.GetString("domicilio_personal")
                        };
                    }
                }
            }
            return p;
        }

        public void Editar(Propietario p)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = @"UPDATE propietarios 
                    SET dni_propietario=@dni, apellido=@ape, nombre=@nom, telefono=@tel, 
                        email=@mail, domicilio_personal=@dom 
                    WHERE id_propietario=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@dni", p.Dni_Propietario);
                    cmd.Parameters.AddWithValue("@ape", p.Apellido);
                    cmd.Parameters.AddWithValue("@nom", p.Nombre);
                    cmd.Parameters.AddWithValue("@tel", p.Telefono);
                    cmd.Parameters.AddWithValue("@mail", p.Email);
                    cmd.Parameters.AddWithValue("@dom", p.Domicilio_Personal);
                    cmd.Parameters.AddWithValue("@id", p.Id_Propietario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Borrar(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = "DELETE FROM propietarios WHERE id_propietario=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}