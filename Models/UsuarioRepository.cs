using System.Data;
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


        public int Alta(Usuario u)
        {
            int res = -1;
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = @"INSERT INTO usuarios 
                   (nombre, apellido, avatar, email, clave, rol) 
                   VALUES (@nom, @ape, @ava, @mail, @pass, @rol);
                   SELECT LAST_INSERT_ID();";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nom", u.Nombre);
                    cmd.Parameters.AddWithValue("@ape", u.Apellido);
                    cmd.Parameters.AddWithValue("@ava", u.Avatar);
                    cmd.Parameters.AddWithValue("@mail", u.Email);
                    cmd.Parameters.AddWithValue("@pass", u.Clave);
                    cmd.Parameters.AddWithValue("@rol", u.Rol);
                    res = Convert.ToInt32(cmd.ExecuteScalar());
                    u.Id = res;
                }
            }
            return res;
        }

        public Usuario ObtenerPorId(int id)
        {
            Usuario u = null;
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT * FROM usuarios WHERE id=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        u = new Usuario
                        {
                            Id = reader.GetInt32("id"),
                            Nombre = reader.GetString("nombre"),
                            Apellido = reader.GetString("apellido"),
                            Avatar = reader.GetString("avatar"),
                            Email = reader.GetString("email"),
                            Clave = reader.GetString("clave"),
                            Rol = reader.GetString("rol")
                        };
                    }
                }
            }
            return u;
        }

        public int Editar(Usuario u)
        {
            int res = -1;
            using (var conn = new MySqlConnection(connectionString))
            {
                var sql = @"UPDATE usuarios 
                    SET nombre=@nom, apellido=@ape, avatar=@ava, email=@mail, clave=@pass, rol=@rol 
                    WHERE id=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nom", u.Nombre);
                    cmd.Parameters.AddWithValue("@ape", u.Apellido);
                    cmd.Parameters.AddWithValue("@ava", u.Avatar);
                    cmd.Parameters.AddWithValue("@mail", u.Email);
                    cmd.Parameters.AddWithValue("@pass", u.Clave);
                    cmd.Parameters.AddWithValue("@rol", u.Rol);
                    cmd.Parameters.AddWithValue("@id", u.Id);
                    conn.Open();
                    res = cmd.ExecuteNonQuery();
                }
            }
            return res;
        }

        public List<Usuario> Buscar(string filtro, int offset, int limit)
        {
            var lista = new List<Usuario>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = @"SELECT id, nombre, apellido, email, rol 
                    FROM usuarios
                    WHERE nombre LIKE @filtro
                       OR apellido LIKE @filtro
                       OR email LIKE @filtro
                       OR rol LIKE @filtro
                    LIMIT @limit OFFSET @offset";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                    cmd.Parameters.AddWithValue("@limit", limit);
                    cmd.Parameters.AddWithValue("@offset", offset);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Usuario
                            {
                                Id = reader.GetInt32("id"),
                                Nombre = reader.GetString("nombre"),
                                Apellido = reader.GetString("apellido"),
                                Email = reader.GetString("email"),
                                Rol = reader.GetString("rol")
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public int Borrar(int id)
        {
            int res = -1;
            using (var conn = new MySqlConnection(connectionString))
            {
                var sql = "DELETE FROM usuarios WHERE id=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    res = cmd.ExecuteNonQuery();
                }
            }
            return res;
        }









    }
}



    
