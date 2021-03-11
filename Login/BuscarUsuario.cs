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
    public partial class BuscarUsuario : Form
    {
        public BuscarUsuario()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscarNombre.Text.Trim()) == false)
            {
                try
                {
                    DataSet ds;
                    string cmd = "SELECT *FROM TEmpleado WHERE Nombres LIKE ('%" + txtBuscarNombre.Text.Trim() + "%')";
                    ds = Utilidades.Ejecutar(cmd);
                    dgvPuntoVenta1.DataSource = ds.Tables[0];
                }
                catch (Exception error)
                {
                    MessageBox.Show("Ha ocurrido un error..." + error.Message);
                }
            }
        }
        public DataSet LLenarDatosAlmacen(string tabla)
        {
            DataSet DS;

            string cmd = string.Format("SELECT * FROM " + tabla);
            DS = Utilidades.Ejecutar(cmd);
            return DS;
        }
        private void BuscarUsuario_Load(object sender, EventArgs e)
        {
            dgvPuntoVenta1.DataSource = LLenarDatosAlmacen("TEmpleado").Tables[0];
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
