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
        Producto p;
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
             int id = Convert.ToInt32(txtBuscar.Text);
             p = await ProductoController.obtenerPorId(id,acceso);
                

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            p = null;
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
            txtStock.Text = p.Cantidad_en_stock.ToString();
            txtnombre.Text = p.Nombre;
            txtPrecio.Text = p.Precio.ToString();
            double total = Convert.ToDouble(txtPrecio.Text) * Convert.ToInt32(txtCantidad.Text);
            table.Rows.Add(table.Rows.Count + 1, p.Id_producto, txtCantidad.Text, DateTime.UtcNow.ToString("yyyy-MM-dd"), total);
            limpiarCampos();

        }
    }
}
