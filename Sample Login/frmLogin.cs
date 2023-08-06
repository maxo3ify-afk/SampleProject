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
    public partial class frmLogin : Form
    {
        Login L = new Login();
        Registro R = new Registro();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            frmRegistrarse Reg = new frmRegistrarse();
            Reg.ShowDialog();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (!R.ValidateEmail(txtcorreo.Text))
                MessageBox.Show("Correo invalido");
            else
            { 
                if (L.UserLogin(txtcorreo.Text,txtcontraseña.Text))
                {
                    this.Hide();
                    frmClientes frm = new frmClientes();
                    frm.ShowDialog();
                    this.Dispose();
                }
                else
                    MessageBox.Show("Inicio de sesión fallido.");
            }
        }
    }
}
