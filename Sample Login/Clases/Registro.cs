using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace Sample_Login.Clases
{
    class Registro
    {
        public bool CheckPasswords(string a, string b)
        {
            if (a != b)
                return false;
            else
                return true;
        }
        public bool SecurePassword(string Contraseña)
        {
            if (Contraseña.Length < 8)
                return false;
            if (!Contraseña.Any(char.IsUpper))
                return false;
            if (!Contraseña.Any(char.IsLower))
                return false;
            if (!Contraseña.Any(char.IsDigit))
                return false;
            if (!Contraseña.Any(c => !char.IsLetterOrDigit(c)))
                return false;

            return true;
        }
        public bool ValidateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
        public string EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2")); 
                }
                return builder.ToString();
            }
        }

        public void CrearRegistro(string correo, string password)
        {
            string HashPassword = EncryptPassword(password);
            string connectionString = "Server=DESKTOP-CJBP8IC\\SQLEXPRESS;Database=SampleDb;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Usuarios (Correo, Contraseña) VALUES (@Email, @Password)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", correo);
                    command.Parameters.AddWithValue("@Password", HashPassword);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
        }
    }
}
