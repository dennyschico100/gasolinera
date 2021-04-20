using GUI_V_2.controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gasolinera.Modelo;
namespace GUI_V_2.vistas
{
    public partial class frmProductos : Form
    {
        int selectedIndex = 0;
        int selectedIndexProveedor= 0;

        string acceso = "";
        bool nuevoProducto = false;
        public frmProductos()
        {
            InitializeComponent();

            acceso = Properties.Settings.Default.token;
            obtenerProductos(acceso);
            desabilitarCampos();
            desabilitarBotones();
            obtenerProveedors();
            obtenerCategorias();
        }
        public async Task obtenerProductos(string token)
        {

            DataTable dt;

            dt = (DataTable)await ProductoController.ObtenerDatos(token);

            dtProductos.DataSource = dt;

        }

        public async Task guardarProducto(string acceso)
        {

            DataTable dt;
            
            string nombre = txtnombre.Text.Trim();
            string precio =txtPrecio.Text.Trim();
            string stock = txtStock.Text.Trim();
            int estado = 0;
            string fecha = monthCalendar1.SelectionStart.Date.ToString("yyyy-MM-dd");
            string imagen = imagenRuta.Text.Trim();
            int usuario = cmbUsuarios.SelectedIndex;
            selectedIndexProveedor = cmbProveedores.SelectedIndex;
            
            MessageBox.Show(acceso);

            if (String.IsNullOrEmpty(nombre))
            {
                errorProvider1.SetError(txtnombre, "INGRESE EL NOMBRE DEL PRODUCTO");
                txtnombre.Focus();
            }
            else if (precio == "")
            {
                errorProvider1.SetError(txtnombre, "");
                errorProvider1.SetError(txtPrecio, "Ingrese sus apellidos");
                txtPrecio.Focus();

            }
            
            else if (!rbdActivo.Checked && !rbdInactivo.Checked)
            {

                errorProvider1.SetError(txtPrecio, "");
                errorProvider1.SetError(groupBox2, "seleccion el rol");

            }
            else if (String.IsNullOrEmpty(stock))
            {
                errorProvider1.SetError(groupBox2, "");
                errorProvider1.SetError(txtStock, "Ingrese las existencias");
                txtStock.Focus();


            }
            else if (String.IsNullOrEmpty(imagen))
            {   
                errorProvider1.SetError(txtStock, "");
                errorProvider1.SetError(imagenRuta, "Ingrese la url de imagen");
                imagenRuta.Focus();

            } 
            
            else
            {
                if (rbdActivo.Checked)
                {
                   estado = 1;
                }
                else
                {
                    estado = 2;
                }

                Producto productos = new Producto();
                productos.Nombre = nombre;
                productos.Precio = Convert.ToDouble(precio);
                productos.Imagen = imagen;
                productos.Fecha_registro = fecha;
                productos.Cantidad_en_stock = Convert.ToInt32(stock);

                productos.Estado_producto = estado;
                productos.Id_proveedor = cmbProveedores.SelectionLength;
                productos.Id_categoria = cmbCategoria.SelectionLength;

                if (nuevoProducto)
                {   
                    await ProductoController.guardar(productos, acceso);
                    //limpiarCampos();
                    //desabilitarBotones();
                }
                else
                {   

                    
                    //limpiarCampos();
                    //desabilitarBotones();
                    

                }
                obtenerProductos(acceso);

            }


            //dtUsuairos.DataSource = dt;

        }

        public void desabilitarBotones()
        {
            btnCancelar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = false;
        }
        public async Task obtenerProveedors()
        {
            DataTable dt;


            dt = (DataTable)await ProveedorController.obtenerProveedores(acceso);

            List<string> nombre = new List<string>(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
                nombre.Add((string)row["nombre"]);
            cmbProveedores.DataSource = nombre;

        }

        public async Task obtenerCategorias()
        {
            DataTable dt;


            dt = (DataTable)await CategoriaController.obtenerCategorias(acceso);

            List<string> nombre = new List<string>(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
                nombre.Add((string)row["nombre"]);
            cmbCategoria.DataSource = nombre;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            guardarProducto(acceso);
        }

        private void txtStock_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;

        }
        public void limpiarCampos()
        {
            rbdActivo.Checked = false;
            rbdInactivo.Checked = false;
            txtStock.Text = "";
            txtnombre.Text = "";
            txtPrecio.Text = "";
            imagenRuta.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            limpiarCampos();
            desabilitarBotones();
        }
        public void habilitarCampos()
        {
           
            txtnombre.Enabled = !false;
            txtPrecio.Enabled = !false;
            txtStock.Enabled = !false;
            imagenRuta.Enabled = !false;
          
          

        }
        public void desabilitarCampos()
        {
            txtnombre.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;
            imagenRuta.Enabled = false;

        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            btnCancelar.Enabled = !false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = !false;
        }
    }
}
