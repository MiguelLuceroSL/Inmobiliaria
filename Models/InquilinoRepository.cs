
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Inmobiliaria.Models
{
    public class InquilinoRepository
    {
        private readonly string connectionString = "server=localhost;database=inmobiliaria;user=root;password=;";

        public List<Inquilino> GetAll()
        {
            var lista = new List<Inquilino>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT * FROM inquilinos";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lista.Add(new Inquilino
                        {
                            Id_Inquilino = reader.GetInt32("id_inquilino"),
                            Dni_Inquilino = reader.GetString("dni_inquilino"),
                            Apellido = reader.GetString("apellido"),
                            Nombre = reader.GetString("nombre"),
                            Telefono = reader.GetString("telefono"),
                            Email = reader.GetString("email"),
                            Domicilio_Personal = reader.GetString("domicilio_personal")
                        });
                    }
                }
            }
            return lista;
        }

        public void Alta(Inquilino i)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = @"INSERT INTO inquilinos 
                           (dni_inquilino, apellido, nombre, telefono, email, domicilio_personal) 
                           VALUES (@dni, @ape, @nom, @tel, @mail, @dom)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@dni", i.Dni_Inquilino);
                    cmd.Parameters.AddWithValue("@ape", i.Apellido);
                    cmd.Parameters.AddWithValue("@nom", i.Nombre);
                    cmd.Parameters.AddWithValue("@tel", i.Telefono);
                    cmd.Parameters.AddWithValue("@mail", i.Email);
                    cmd.Parameters.AddWithValue("@dom", i.Domicilio_Personal);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Inquilino ObtenerPorId(int id)
        {
            Inquilino i = new Inquilino();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT * FROM inquilinos WHERE id_inquilino=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        i = new Inquilino
                        {
                            Id_Inquilino = reader.GetInt32("id_inquilino"),
                            Dni_Inquilino = reader.GetString("dni_inquilino"),
                            Apellido = reader.GetString("apellido"),
                            Nombre = reader.GetString("nombre"),
                            Telefono = reader.GetString("telefono"),
                            Email = reader.GetString("email"),
                            Domicilio_Personal = reader.GetString("domicilio_personal")
                        };
                    }
                }
            }
            return i;
        }

        public void Editar(Inquilino i)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = @"UPDATE inquilinos 
                    SET dni_inquilino=@dni, apellido=@ape, nombre=@nom, telefono=@tel, 
                        email=@mail, domicilio_personal=@dom 
                    WHERE id_inquilino=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@dni", i.Dni_Inquilino);
                    cmd.Parameters.AddWithValue("@ape", i.Apellido);
                    cmd.Parameters.AddWithValue("@nom", i.Nombre);
                    cmd.Parameters.AddWithValue("@tel", i.Telefono);
                    cmd.Parameters.AddWithValue("@mail", i.Email);
                    cmd.Parameters.AddWithValue("@dom", i.Domicilio_Personal);
                    cmd.Parameters.AddWithValue("@id", i.Id_Inquilino);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Borrar(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = "DELETE FROM inquilinos WHERE id_inquilino=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}



