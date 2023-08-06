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
    public partial class frmClientes : Form
    {
        Clientes C = new Clientes();
        int Id = 0;
        public frmClientes()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtPrimerNombre.Text != "" && txtSegundoNombre.Text != "" && txtPrimerApellido.Text != "" && txtSegundoApellido.Text != "" &&
                txtIdentificacion.Text != "" && cbTIdentificacion.Text != "")
            {
                try
                {
                    C.InsertCliente(txtPrimerNombre.Text, txtSegundoNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text, txtIdentificacion.Text
                    , cbTIdentificacion.Text);
                    dataGridView1.DataSource = null;
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = C.GetAllClientes().ToList();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Error al ingresar los datos, Error: "+ Ex, "Error");
                }
            }
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C.GetAllClientes().ToList();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Obtener los valores de la fila seleccionada
                Id = Convert.ToInt32(row.Cells["IdCliente"].Value);
                txtPrimerNombre.Text = row.Cells["PrimerNombre"].Value.ToString();
                txtSegundoNombre.Text = row.Cells["SegundoNombre"].Value.ToString();
                txtPrimerApellido.Text = row.Cells["PrimerApellido"].Value.ToString();
                txtSegundoApellido.Text = row.Cells["SegundoApellido"].Value.ToString();
                txtIdentificacion.Text = row.Cells["Identificacion"].Value.ToString();
                cbTIdentificacion.SelectedText = row.Cells["TipoIdentificacion"].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Id != 0)
            {
                try
                {
                    C.UpdateCliente(Id, txtPrimerNombre.Text, txtSegundoNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text, txtIdentificacion.Text
                    , cbTIdentificacion.Text);
                    MessageBox.Show("Se actualizo el cliente");
                    Id = 0;
                    dataGridView1.DataSource = null;
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = C.GetAllClientes().ToList();
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            } 
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Id != 0)
            {
                try
                {
                    C.DeleteCliente(Id);
                    MessageBox.Show("Se elimino al cliente");
                    Id = 0;
                    dataGridView1.DataSource = null;
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = C.GetAllClientes().ToList();
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
        }
    }
}
