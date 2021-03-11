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
    public partial class VentanaAdmin : Form
    {
        public VentanaAdmin()
        {
            InitializeComponent();
        }

        private void VentanaAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void VentanaAdmin_Load(object sender, EventArgs e)
        {
            String cmd = "SELECT * FROM TEmpleado WHERE CodEmpleado = " + VentanaLogin.codigo;
            DataSet DS = Utilidades.Ejecutar(cmd);

            lblAdmin.Text = DS.Tables[0].Rows[0]["Usuario"].ToString();
            lblNomb.Text = DS.Tables[0].Rows[0]["Nombres"].ToString();
            lblCod.Text = DS.Tables[0].Rows[0]["CodEmpleado"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuSistema menu = new MenuSistema();
            this.Hide();
            menu.Show();
        }

        private void btnCambContraseña_Click(object sender, EventArgs e)
        {

        }

        private void btnAdminUsuario_Click(object sender, EventArgs e)
        {
            label1 AgreUsuario = new label1();
            this.Hide();
            AgreUsuario.Show();
        }

        private void btnCerrarSecion_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }
    }
}
