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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        public static int cont_fila = 0;
        public static double total;
        private void btnColocar_Click(object sender, EventArgs e)
        {
           
            
                bool existe = false;
                int num_fila = 0;

                if(cont_fila==0)
                {
                    dataGridView1.Rows.Add(txtCodigo.Text, txtNombre.Text, txtPrecio.Text, txtCantidad.Text);
                    double importe = Convert.ToDouble(dataGridView1.Rows[cont_fila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[cont_fila].Cells[3].Value);
                    dataGridView1.Rows[cont_fila].Cells[4].Value = importe;

                    cont_fila++;
                }
                else
                {
                    foreach (DataGridViewRow Fila in dataGridView1.Rows)
                       {
                          if (Fila.Cells[0].Value.ToString()==txtCodigo.Text)
                             {
                                existe = true;
                                num_fila = Fila.Index;
                             }
                       }
                    if(existe == true)
                    {
                        dataGridView1.Rows[num_fila].Cells[3].Value = (Convert.ToDouble(txtCantidad.Text) + Convert.ToDouble(dataGridView1.Rows[num_fila].Cells[3].Value)).ToString();
                        double importe = Convert.ToDouble(dataGridView1.Rows[num_fila].Cells[2].Value) * +Convert.ToDouble(dataGridView1.Rows[num_fila].Cells[3].Value);
                        dataGridView1.Rows[num_fila].Cells[4].Value = importe;
                    }
                    else
                    {
                       dataGridView1.Rows.Add(txtCodigo.Text, txtNombre.Text, txtPrecio.Text, txtCantidad.Text);
                       double importe = Convert.ToDouble(dataGridView1.Rows[cont_fila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[cont_fila].Cells[3].Value);
                       dataGridView1.Rows[cont_fila].Cells[4].Value = importe;

                      cont_fila++;
                    }
                }
                total = 0;
                foreach (DataGridViewRow Fila in dataGridView1.Rows)
                {
                total += Convert.ToDouble(Fila.Cells[4].Value);
                }
                label8.Text = "s/."+ total.ToString();

        }

        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String cmd = "SELECT * FROM TProducto WHERE CodProducto =" + txtCodigo.Text;
            DataSet DS = Utilidades.Ejecutar(cmd);

            txtNombre.Text = DS.Tables[0].Rows[0]["NombreProducto"].ToString();
            txtPrecio.Text = DS.Tables[0].Rows[0]["PrecioUnitario"].ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(cont_fila>0)
            {
                total=total - (Convert.ToDouble(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value));
                label8.Text= "s/."+ total.ToString();

                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                cont_fila--;
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Consultas conPro = new Consultas();
            conPro.ShowDialog();
            if (conPro.DialogResult == DialogResult.OK) 
            {
                txtCodigo.Text = conPro.dataGridView1.Rows[conPro.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                txtNombre. Text= conPro.dataGridView1.Rows[conPro.dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                txtPrecio.Text= conPro.dataGridView1.Rows[conPro.dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
                txtCantidad.Focus();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        public virtual void Nuevo()
        {

        }
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Text="";
            txtNombre.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            label8.Text = "";
            dataGridView1.Rows.Clear();
            cont_fila = 0;
            
        }


       
    }
}
