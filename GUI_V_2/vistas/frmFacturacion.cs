using GUI_V_2.controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Gasolinera.Modelo;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace GUI_V_2.vistas
{
    public partial class frmFacturacion : Form
    {
        DataTable table;
        string acceso = "";
        
        public frmFacturacion()
        {
            InitializeComponent();
            table = new DataTable();
            acceso = Properties.Settings.Default.token;
            table.Columns.Add("Id detalle factura", typeof(int));
            table.Columns.Add("Id producto", typeof(int));// data type int
            table.Columns.Add("cantidad ", typeof(string));
            table.Columns.Add("restados del stock", typeof(int));// datatype string
            table.Columns.Add("fecha", typeof(string));// datatype string
            table.Columns.Add("total", typeof(decimal));// data type int
            table.Columns.Add("id usuario", typeof(int));// data type int
            //table.Rows.Add(textBoxID.Text, textBoxFN.Text, textBoxLN.Text, textBoxAGE.Text);

            dtFacturacion.DataSource = table;
            btnAgregar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
          
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            int id = 0;   
            id = Convert.ToInt32(txtBuscar.Text);
            btnAgregar.Enabled = true;
            Producto  p = await ProductoController.obtenerPorId(id,acceso);
            txtIdProducto.Text = p.Id_producto.ToString();
            txtStock.Text = p.Cantidad_en_stock.ToString();
            txtnombre.Text = p.Nombre;
            txtPrecio.Text = p.Precio.ToString();


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            btnCancelar.Enabled = false;
            limpiarCampos();

        }
        public void limpiarCampos()
        {
            txtBuscar.Text = "";
            txtCantidad.Text = "";
            txtnombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string cantidad =txtCantidad.Text;
            string usuario = txtUsuario.Text;
            if (String.IsNullOrEmpty(cantidad))
            {   
                errorProvider1.SetError(txtCantidad,"INGRESA LA CANTIDAD");
                txtCantidad.Focus();
            }else if (String.IsNullOrEmpty(usuario))
            {

                errorProvider1.SetError(txtUsuario, "INGRESA EL ID");
                txtUsuario.Focus();

                errorProvider1.SetError(txtCantidad, "");
            }
            else
            {

                errorProvider1.SetError(txtUsuario, "");
                double total = Convert.ToDouble(txtPrecio.Text) * Convert.ToDouble(txtCantidad.Text);
                table.Rows.Add(table.Rows.Count + 1, txtIdProducto.Text, txtCantidad.Text, cantidad, DateTime.UtcNow.ToString("yyyy-MM-dd"), total,usuario);
                limpiarCampos();
                btnAgregar.Enabled = false;

            }
           

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
     (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
     (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
