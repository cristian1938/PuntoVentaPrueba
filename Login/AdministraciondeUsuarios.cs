using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MiLibreria;

namespace Login
{
	public partial class label1 : Form
	{
		

		public label1()
		{
			InitializeComponent();
		}

		public DataSet LLenarDatos(string tabla)
        {
			DataSet DS;

			string cmd = string.Format("SELECT * FROM " + tabla);
			DS = Utilidades.Ejecutar(cmd);
			return DS;
        }

		private void btnConectarse_Click(object sender, EventArgs e)
		{
			
	    }

		private void btnDesconectarse_Click(object sender, EventArgs e)
		{
		}

		private void btnConsulta_Click(object sender, EventArgs e)
		{
			VentanaAdmin VentanaAdministrador = new VentanaAdmin();
			this.Hide();
			VentanaAdministrador.Show();

		}
		public void Actualizar()
		{
		}
		/*
		private void btnAgregar_Click(object sender, EventArgs e)
		{
			string cadena = "Insert into TEmpleado ([CodEmpleado], [Nombres], [Apellidos], [Funcion], [Telefono]) "+
				"values ('"+txtCodEmpleado.Text+"','"+txtNombres.Text+"','"+txtApellidos.Text+"','"+txtFuncion.Text+"','"+txtTelefono.Text+"')";
			SqlCommand comando = new SqlCommand(cadena, conexion);
			comando.ExecuteNonQuery();

			MessageBox.Show("El usuario: "+txtCodEmpleado.Text+" Se ha agregado correctamente");

			txtCodEmpleado.Text = "";
			txtNombres.Text = "";
			txtApellidos.Text = "";
			txtFuncion.Text = "";
			txtTelefono.Text = "";
			Actualizar();

			//this.Hide(); //esconder el form y entrar
			//AgregarUsuario formulario = new AgregarUsuario();
			//formulario.Show();



		}
		*/
		public Boolean Guardar()
		{
			try
			{
				string cmd = string.Format("EXEC ActualiceUsuario '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}' ", txtCodEmpleado.Text.Trim(), txtNombres.Text.Trim(), txtApellidos.Text.Trim(), txtFuncion.Text.Trim(), txtTelefono.Text.Trim(), txtUsuario.Text.Trim(), txtContraseña.Text.Trim(), txtEstatus.Text.Trim());
				Utilidades.Ejecutar(cmd);
				MessageBox.Show("Se ha guardado correctamente!...");

				return true;
			}
			catch (Exception error)
			{
				MessageBox.Show("Ha ocurrido un error" + error.Message);
				return false;
			}
		}
		private void btnAgregar_Click_1(object sender, EventArgs e)
		{

			Guardar();
			dgvPuntoVenta.DataSource = LLenarDatos("TEmpleado").Tables[0];
			txtCodEmpleado.Text = "";
			txtNombres.Text = "";
			txtApellidos.Text = "";
			txtFuncion.Text = "";
			txtTelefono.Text = "";
			txtUsuario.Text = "";
			txtContraseña.Text = "";
			txtEstatus.Text = "";
			//this.Hide(); //esconder el form y entrar
			//AgregarUsuario formulario = new AgregarUsuario();
			//formulario.Show();

		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			try
			{
				string cmd = string.Format("EXEC EliminarUsuario '{0}'", txtCodEmpleado.Text.Trim());
				Utilidades.Ejecutar(cmd);
				dgvPuntoVenta.DataSource = LLenarDatos("TEmpleado").Tables[0];
				MessageBox.Show("Se ha Eliminado correctamente!...");
			}
			catch (Exception error)
			{
				MessageBox.Show("Ha ocurrido un error" + error.Message);
			}
			txtCodEmpleado.Text = "";
			txtNombres.Text = "";
			txtApellidos.Text = "";
			txtFuncion.Text = "";
			txtTelefono.Text = "";
			txtUsuario.Text = "";
			txtContraseña.Text = "";
			txtEstatus.Text = "";


		}
        private void Form1_Load(object sender, EventArgs e)
        {
			dgvPuntoVenta.DataSource = LLenarDatos("TEmpleado").Tables[0];
        }
    }
}
