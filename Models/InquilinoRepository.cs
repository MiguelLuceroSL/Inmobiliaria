
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

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
                            idInquilino = reader.GetInt32("id_inquilino"),
                            dniInquilino = reader.GetString("dni_inquilino"),
                            apellido = reader.GetString("apellido"),
                            nombre = reader.GetString("nombre"),
                            telefono = reader.GetString("telefono"),
                            email = reader.GetString("email"),
                            domicilioPersonal = reader.GetString("domicilio_personal")
                        });
                    }
                }
            }
            return lista;
        }

    public IList<Inquilino> ObtenerListaInquilinos(int paginaNro = 1, int tamPagina = 10)
{
    IList<Inquilino> res = new List<Inquilino>();

    if (paginaNro < 1) paginaNro = 1;
    if (tamPagina < 1) tamPagina = 10;

    using (var connection = new MySqlConnection(connectionString))
    {
        string sql = @"
            SELECT id_inquilino, dni_inquilino, apellido, nombre, telefono, email, domicilio_personal
            FROM inquilinos
            LIMIT @limit OFFSET @offset
        ";

        using (var command = new MySqlCommand(sql, connection))
        {
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@limit", tamPagina);
            command.Parameters.AddWithValue("@offset", (paginaNro - 1) * tamPagina);

            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Inquilino i = new Inquilino
                    {
                        idInquilino = reader.GetInt32("id_inquilino"),
                        dniInquilino = reader.GetString("dni_inquilino"),
                        apellido = reader.GetString("apellido"),
                        nombre = reader.GetString("nombre"),
                        telefono = reader.GetString("telefono"),
                        email = reader.GetString("email"),
                        domicilioPersonal = reader.GetString("domicilio_personal")
                    };
                    res.Add(i);
                }
            }
        }
    }

    return res;
}
        public List<Inquilino> Buscar(string filtro, int offset, int limit = 20)
        {
            var lista = new List<Inquilino>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var sql = @"SELECT * FROM inquilinos 
                    WHERE apellido LIKE @filtro OR nombre LIKE @filtro OR dni_inquilino LIKE @filtro 
                    ORDER BY apellido, nombre
                    LIMIT @limit OFFSET @offset";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                    cmd.Parameters.AddWithValue("@limit", limit);
                    cmd.Parameters.AddWithValue("@offset", offset);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lista.Add(new Inquilino
                        {
                            idInquilino = reader.GetInt32("id_inquilino"),
                            dniInquilino = reader.GetString("dni_inquilino"),
                            apellido = reader.GetString("apellido"),
                            nombre = reader.GetString("nombre"),
                            telefono = reader.GetString("telefono"),
                            email = reader.GetString("email"),
                            domicilioPersonal = reader.GetString("domicilio_personal")
                        });
                    }
                }
            }
            return lista;
        }

public int ContarInquilinos()
{
    int total = 0;
    using (var connection = new MySqlConnection(connectionString))
    {
        string sql = "SELECT COUNT(*) FROM inquilinos";
        using (var command = new MySqlCommand(sql, connection))
        {
            command.CommandType = CommandType.Text;
            connection.Open();
            total = Convert.ToInt32(command.ExecuteScalar());
        }
    }
    return total;
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
                    cmd.Parameters.AddWithValue("@dni", i.dniInquilino);
                    cmd.Parameters.AddWithValue("@ape", i.apellido);
                    cmd.Parameters.AddWithValue("@nom", i.nombre);
                    cmd.Parameters.AddWithValue("@tel", i.telefono);
                    cmd.Parameters.AddWithValue("@mail", i.email);
                    cmd.Parameters.AddWithValue("@dom", i.domicilioPersonal);
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
                            idInquilino = reader.GetInt32("id_inquilino"),
                            dniInquilino = reader.GetString("dni_inquilino"),
                            apellido = reader.GetString("apellido"),
                            nombre = reader.GetString("nombre"),
                            telefono = reader.GetString("telefono"),
                            email = reader.GetString("email"),
                            domicilioPersonal = reader.GetString("domicilio_personal")
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
                    cmd.Parameters.AddWithValue("@dni", i.dniInquilino);
                    cmd.Parameters.AddWithValue("@ape", i.apellido);
                    cmd.Parameters.AddWithValue("@nom", i.nombre);
                    cmd.Parameters.AddWithValue("@tel", i.telefono);
                    cmd.Parameters.AddWithValue("@mail", i.email);
                    cmd.Parameters.AddWithValue("@dom", i.domicilioPersonal);
                    cmd.Parameters.AddWithValue("@id", i.idInquilino);
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



