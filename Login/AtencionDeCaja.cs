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
    public partial class AtencionDeCaja : Form
    {
        public AtencionDeCaja()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void AtencionDeCaja_Load(object sender, EventArgs e)
        {
            string cmd = "SELECT *FROM TEmpleado WHERE CodEmpleado=" + VentanaLogin.codigo;
            DataSet DS = Utilidades.Ejecutar(cmd);

            textBox1.Text = DS.Tables[0].Rows[0]["Nombres"].ToString().Trim();
        }
        public static int Cont_Fila = 0;
        public static double total = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            bool existe = false;
            int Num_Fila = 0;
            if (Cont_Fila==0)
            {
                dataGridView1.Rows.Add(txtCodigo.Text, txtDescripcion.Text, txtPrecio.Text,txtCantidad.Text);
                double importe = Convert.ToDouble(dataGridView1.Rows[Cont_Fila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[Cont_Fila].Cells[3].Value);
                dataGridView1.Rows[Cont_Fila].Cells[4].Value = importe;
                Cont_Fila++;
            }
            else
            {
                foreach(DataGridViewRow Fila in dataGridView1.Rows)
                {
                    if (Fila.Cells[0].Value.ToString()==txtCodigo.Text)
                    {
                        existe = true;
                        Num_Fila = Fila.Index;
                    }
                }
                if(existe==true)
                {
                    dataGridView1.Rows[Num_Fila].Cells[3].Value = (Convert.ToDouble(txtCantidad.Text) + Convert.ToDouble(dataGridView1.Rows[Num_Fila].Cells[3].Value)).ToString();
                    double importe = Convert.ToDouble(dataGridView1.Rows[Num_Fila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[Num_Fila].Cells[3].Value);
                    dataGridView1.Rows[Num_Fila].Cells[4].Value = importe;
                }
                else
                {
                    dataGridView1.Rows.Add(txtCodigo, txtDescripcion, txtPrecio, txtCantidad);
                    double importe = Convert.ToDouble(dataGridView1.Rows[Cont_Fila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[Cont_Fila].Cells[3].Value);
                    dataGridView1.Rows[Cont_Fila].Cells[4].Value = importe;
                    Cont_Fila++;
                }
            }
        }

        private void btnDetalleProducto_Click(object sender, EventArgs e)
        {
            String cmd = "SELECT * FROM TProducto WHERE CodProducto =" + txtCodigo.Text;
            DataSet DS = Utilidades.Ejecutar(cmd);

            txtDescripcion.Text = DS.Tables[0].Rows[0]["NombreProducto"].ToString();
            txtPrecio.Text = DS.Tables[0].Rows[0]["PrecioUnitario"].ToString();
            
        }
    }
}
