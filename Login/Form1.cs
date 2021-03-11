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
    //new Conexion c = new Conexion();
    public partial class FormAlmacen : Form
    {
        
        public FormAlmacen()
        {
            InitializeComponent();
        }

        private void FormAlmacen_Load(object sender, EventArgs e)
        {

        }

        public DataSet LlenarDataGV(string tabla)
        {
            DataSet DS;
            string cmd = string.Format("SELECT *FROM" + tabla);
            DS = Utilidades.Ejecutar(cmd);
            return DS;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = string.Format("EXEC InsertarProductos'{0}','{1}','{2}'" , txtCodProducto.Text.Trim(), txtNombreProducto.Text.Trim(), txtMarca.Text.Trim(), txtUnidadMedida.Text.Trim(), txtUnidadesDisponibles.Text.Trim(), txtPrecioUnitario.Text.Trim());
                Utilidades.Ejecutar(cmd);

                MessageBox.Show("El registro se realizo correctamente");

                txtCodProducto.Text = " ";
                txtNombreProducto.Text = " ";
                txtMarca.Text = "";
                txtUnidadMedida.Text = "";
                txtUnidadesDisponibles.Text = "";
                txtPrecioUnitario.Text = "";
                
            }
            catch(Exception error)
            {
                MessageBox.Show("Imposible de registrar,El registro ya existe" + error.Message);
                txtCodProducto.Text = " ";
                txtNombreProducto.Text = " ";
                txtMarca.Text = "";
                txtUnidadMedida.Text = "";
                txtUnidadesDisponibles.Text = "";
                txtPrecioUnitario.Text = "";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //ELIMINAR
            try
            {
                string cmd = string.Format("EXEC EliminarProductos '{0}'", txtCodProducto.Text.Trim());
                Utilidades.Ejecutar(cmd);
                MessageBox.Show("Se ha borrado correctamente..!");
            }
            catch(Exception error)
            {
                MessageBox.Show("No se ha borrado ocurrrio algun error ...!" + error.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //MODIFICAR
            try
            {
                //faltamodificar
                string cmd = string.Format("modificar TProducto",txtCodProducto.Text.Trim());
                Utilidades.Ejecutar(cmd);
                MessageBox.Show("Se ha modificado correctamente..!");
            }
            catch (Exception error)
            {
                MessageBox.Show("No se ha modificado ocurrrio algun error ...!" + error.Message);
            }
        }
        //

        private void btnListar_Click(object sender, EventArgs e)
        {
            //LISTAR
            if (dgvAlmacen.Rows.Count == 0)
            { 
                dgvAlmacen.DataSource = LlenarDataGV("TProducto").Tables[0];
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodProducto_TextChanged(object sender, EventArgs e)
        {
            /*
       /  if (RbModificar.Checked == true)
            {
                if (c.ProductoRegistrado(Convert.ToInt32(txtCodProducto.Text)) > 0)
                {
                    c.LLenarTexBoxConsulta(Convert.ToInt32(txtCodProducto.Text), txtNombreProducto, txtMarca, txtUnidadMedida, txtUnidadesDisponibles, txtPrecioUnitario);
                    btnModificar.Enabled = true;
                }
                else
                {
                    txtNombreProducto.Text="";
                    txtMarca.Text = "";
                    txtUnidadMedida.Text = "";
                    txtUnidadesDisponibles.Text = "";
                    txtPrecioUnitario.Text = "";
                    btnModificar.Enabled = false;

                }*/
          //}
        }
    }
}
