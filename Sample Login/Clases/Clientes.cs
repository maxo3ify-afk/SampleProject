using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sample_Login.Clases
{
    class Clientes
    {
        public void InsertCliente(string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string identificacion, string tipoIdentificacion)
        {
            string connectionString = "Server=DESKTOP-CJBP8IC\\SQLEXPRESS;Database=SampleDb;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"INSERT INTO Clientes (PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, Identificacion, TipoIdentificacion) 
                            VALUES (@PrimerNombre, @SegundoNombre, @PrimerApellido, @SegundoApellido, @Identificacion, @TipoIdentificacion)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PrimerNombre", primerNombre);
                    command.Parameters.AddWithValue("@SegundoNombre", segundoNombre);
                    command.Parameters.AddWithValue("@PrimerApellido", primerApellido);
                    command.Parameters.AddWithValue("@SegundoApellido", segundoApellido);
                    command.Parameters.AddWithValue("@Identificacion", identificacion);
                    command.Parameters.AddWithValue("@TipoIdentificacion", tipoIdentificacion);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
        }
        public List<Cliente> GetAllClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            string connectionString = "Server=DESKTOP-CJBP8IC\\SQLEXPRESS;Database=SampleDb;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Clientes";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente
                        {
                            IdCliente = Convert.ToInt32(reader["IdCliente"]),
                            PrimerNombre = reader["PrimerNombre"].ToString(),
                            SegundoNombre = reader["SegundoNombre"].ToString(),
                            PrimerApellido = reader["PrimerApellido"].ToString(),
                            SegundoApellido = reader["SegundoApellido"].ToString(),
                            Identificacion = reader["Identificacion"].ToString(),
                            TipoIdentificacion = reader["TipoIdentificacion"].ToString(),
                            Estado = Convert.ToBoolean(reader["Estado"])
                        };

                        clientes.Add(cliente);
                    }
                }
            }

            return clientes;
        }

        public void UpdateCliente(int idCliente, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string identificacion, string tipoIdentificacion)
        {
            string connectionString = "Server=DESKTOP-CJBP8IC\\SQLEXPRESS;Database=SampleDb;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"UPDATE Clientes SET PrimerNombre = @PrimerNombre, SegundoNombre = @SegundoNombre, PrimerApellido = @PrimerApellido, SegundoApellido = @SegundoApellido, Identificacion = @Identificacion, TipoIdentificacion = @TipoIdentificacion
                                WHERE IdCliente = @IdCliente";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdCliente", idCliente);
                    command.Parameters.AddWithValue("@PrimerNombre", primerNombre);
                    command.Parameters.AddWithValue("@SegundoNombre", segundoNombre);
                    command.Parameters.AddWithValue("@PrimerApellido", primerApellido);
                    command.Parameters.AddWithValue("@SegundoApellido", segundoApellido);
                    command.Parameters.AddWithValue("@Identificacion", identificacion);
                    command.Parameters.AddWithValue("@TipoIdentificacion", tipoIdentificacion);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCliente(int idCliente)
        {
            string connectionString = "Server=DESKTOP-CJBP8IC\\SQLEXPRESS;Database=SampleDb;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Clientes WHERE IdCliente = @IdCliente";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdCliente", idCliente);

                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
        }

        public class Cliente
        {
            public int IdCliente { get; set; }
            public string PrimerNombre { get; set; }
            public string SegundoNombre { get; set; }
            public string PrimerApellido { get; set; }
            public string SegundoApellido { get; set; }
            public string Identificacion { get; set; }
            public string TipoIdentificacion { get; set; }
            public bool Estado { get; set; }
        }
    }
}
