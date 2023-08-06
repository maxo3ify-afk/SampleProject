using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sample_Login.Clases;

namespace Sample_Login
{
    public partial class frmRegistrarse : Form
    {
        Registro r = new Registro();
        public frmRegistrarse()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (!r.CheckPasswords(txtContraseña.Text, txtRepetirContraseña.Text))
                MessageBox.Show("Error en las contraseñas", "Error");
            else
            {
                if (r.SecurePassword(txtContraseña.Text))
                {
                    if (r.ValidateEmail(txtCorreo.Text))
                    {
                        try
                        {
                            r.CrearRegistro(txtCorreo.Text, txtContraseña.Text);
                            MessageBox.Show("Usuario Creado con exito");
                            this.Dispose();
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show("No se pudo crear el usuario Error: "+Ex.ToString(), "Error");
                        }
                        
                    }
                        
                    else
                        MessageBox.Show("Correo invalido", "Error");
                }
                else
                    MessageBox.Show("Contraseña no segura", "Error");
            }
        }
    }
}
