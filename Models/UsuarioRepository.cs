using Inmobiliaria.Models;
using MySql.Data.MySqlClient;

namespace Inmobiliaria.Repositories
{
    public class UsuarioRepository
    {
        private readonly string connectionString = "server=localhost;database=inmobiliaria;user=root;password=;";

        // Buscar usuario por email y verificar contraseña
        public Usuario? Login(string email, string clave)
        {
            Usuario? usuario = null;

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"SELECT id, nombre, apellido, avatar, email, clave, rol 
                               FROM usuarios WHERE email = @Email LIMIT 1";

                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hashGuardado = reader.GetString("clave");

                            if (VerificarPassword(clave, hashGuardado))
                            {
                                usuario = new Usuario
                                {
                                    Id = reader.GetInt32("id"),
                                    Nombre = reader.GetString("nombre"),
                                    Apellido = reader.GetString("apellido"),
                                    Avatar = reader.GetString("avatar"),
                                    Email = reader.GetString("email"),
                                    Clave = hashGuardado,
                                    Rol = reader.GetString("rol")
                                };
                            }
                        }
                    }
                }
            }

            return usuario;
        }

        public List<Usuario> GetAll()
    {
        var lista = new List<Usuario>();
        try
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT id, nombre, apellido, avatar, email, clave, rol FROM usuarios";
                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Usuario
                        {
                            Id = reader.GetInt32("id"),
                            Nombre = reader.GetString("nombre"),
                            Apellido = reader.GetString("apellido"),
                            Avatar = reader.GetString("avatar"),
                            Email = reader.GetString("email"),
                            Clave = reader.GetString("clave"),
                            Rol = reader.GetString("rol")
                        });
                    }
                }
            }
        }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al obtener usuarios: {ex.Message}");
    }

    return lista;
}




        // Hashear password
        public static string HashPassword(string password)
        {
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        // Comparar hash
        private static bool VerificarPassword(string passwordIngresada, string hashGuardado)
        {
            var hashIngresado = HashPassword(passwordIngresada);
            return hashIngresado == hashGuardado;
        }
    }





}