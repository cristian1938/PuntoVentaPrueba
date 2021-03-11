using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiLibreria;

namespace Login
{
    public partial class Almacen : Form
    {
        public Almacen()
        {
            InitializeComponent();
        }
        public DataSet LLenarDatosAlmacen(string tabla)
        {
            DataSet DS;

            string cmd = string.Format("SELECT * FROM " + tabla);
            DS = Utilidades.Ejecutar(cmd);
            return DS;
        }
        private void Almacen_Load(object sender, EventArgs e)
        {
            
            dgvPuntoVenta1.DataSource = LLenarDatosAlmacen("TProducto").Tables[0];
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscarNombre.Text.Trim())==false)
            {
                try
                {
                    DataSet ds;
                    string cmd= "SELECT *FROM TProducto WHERE NombreProducto LIKE ('%"+txtBuscarNombre.Text.Trim()+"%')";
                    ds = Utilidades.Ejecutar(cmd);
                    dgvPuntoVenta1.DataSource = ds.Tables[0];
                }
                catch (Exception error)
                {
                    MessageBox.Show("Ha ocurrido un error..." + error.Message);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMenuSistema_Click(object sender, EventArgs e)
        {
            MenuSistema MenuPrin = new MenuSistema();
            this.Hide();
            MenuPrin.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dgvPuntoVenta1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBuscarNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
