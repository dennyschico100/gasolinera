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

        int selectedIndexUnidad = 0;
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
            obtenerUnidadesMedida();

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
            bool estado = true;
            string fecha = monthCalendar1.SelectionStart.Date.ToString("yyyy-MM-dd");
            string imagen = imagenRuta.Text.Trim();
            string usuario = txtUsuario.Text.Trim();
            selectedIndexProveedor = cmbProveedores.SelectedIndex;
            
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
            else if (String.IsNullOrEmpty(usuario))
            {
                errorProvider1.SetError(txtPrecio, "");
                errorProvider1.SetError(txtUsuario, "Ingrese el usuario");
                txtUsuario.Focus();

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
                   estado = true;
                }
                else
                {
                    estado = false;
                }

                Producto productos = new Producto();
                productos.Nombre = nombre;
                productos.Precio = Convert.ToDouble(precio);
                productos.Imagen = imagen;
                productos.Fecha_registro = fecha;
                productos.Cantidad_en_stock = Convert.ToInt32(stock);

                productos.Estado_producto = estado;
                productos.Id_proveedor = cmbProveedores.SelectedIndex+1;
                productos.Id_categoria = cmbCategoria.SelectedIndex + 1;
                productos.Id_usuario = Convert.ToInt32(usuario);
                productos.Id_unidad = cmbMedida.SelectedIndex +1;
                await ProductoController.guardar(productos, acceso);
                if (nuevoProducto)
                {   
                    
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

            obtenerProductos(acceso);
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
        public async Task obtenerUnidadesMedida()
        {
            DataTable dt;


            dt = (DataTable)await UnidadMedidaController.obtenerMedidas(acceso);

            List<string> nombre = new List<string>(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
                nombre.Add((string)row["nombre_unidad"]);
            cmbMedida.DataSource = nombre;

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
            
            habilitarCampos();
            btnCancelar.Enabled = !false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = !false;

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
            desabilitarCampos();
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

        private void dtProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtnombre.Text = dtProductos.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPrecio.Text = dtProductos.Rows[e.RowIndex].Cells[3].Value.ToString();
            monthCalendar1.SetDate(Convert.ToDateTime(dtProductos.Rows[e.RowIndex].Cells[5].Value.ToString()));
            txtStock.Text = dtProductos.Rows[e.RowIndex].Cells[7].Value.ToString();
            //txtnombres.Text = dtUsuairos.Rows[e.RowIndex].Cells[8].Value.ToString();
            int estado = Convert.ToInt32(dtProductos.Rows[e.RowIndex].Cells[7].Value.ToString());
            //cmbMunicipios.SelectedIndex = selectedIndexMunicipio;
            selectedIndexProveedor = Convert.ToInt32(dtProductos.Rows[e.RowIndex].Cells[9].Value.ToString());
            selectedIndex = Convert.ToInt32(dtProductos.Rows[e.RowIndex].Cells[11].Value.ToString());

            if (estado == 1)
            {
                rbdActivo.Checked = true;


            }
            else
            {
                rbdInactivo.Checked = true;
            }
            btnEliminar.Enabled = true;
            //txtIdUsuario.Enabled = true;

            btnEditar.Enabled = true;
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {

        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbMedida_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
