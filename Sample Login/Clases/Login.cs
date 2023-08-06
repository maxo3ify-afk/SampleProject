using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sample_Login.Clases
{
    class Login
    {
        public bool UserLogin(string Correo, string Contraseña)
        {
            Registro r = new Registro();
            string HashedPass = r.EncryptPassword(Contraseña);
            string connectionString = "Server=DESKTOP-CJBP8IC\\SQLEXPRESS;Database=SampleDb;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Usuarios WHERE Correo = @Email AND Contraseña = @Password AND Activo = 1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", Correo);
                    command.Parameters.AddWithValue("@Password", HashedPass);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }
}
