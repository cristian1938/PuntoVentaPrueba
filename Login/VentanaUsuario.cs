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
    public partial class VentanaUsuario : Form
    {
        public VentanaUsuario()
        {
            InitializeComponent();
        }

        private void VentanaUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void VentanaUsuario_Load(object sender, EventArgs e)
        {
            String cmd = "SELECT * FROM usuarios WHERE id = " + VentanaLogin.codigo;
            DataSet DS = Utilidades.Ejecutar(cmd);

            lblUsua.Text = DS.Tables[0].Rows[0]["Usuario"].ToString();
            lblNombre.Text = DS.Tables[0].Rows[0]["Nombre"].ToString();
            lblCodigo.Text = DS.Tables[0].Rows[0]["id"].ToString();
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            MenuSistema MenuPrin = new MenuSistema();
            this.Hide();
            MenuPrin.Show();
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {

        }
    }
}
