using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gasolinera.controladores;
using Gasolinera.Modelo;

namespace Gasolinera.vistas
{
    public partial class registro : Form
    {
        int selectedIndex=0;
        int selectedIndexMunicipio = 0;

        string acceso = "";
        
        public registro()
        {
            InitializeComponent();
            obtenerDepartamentos();
            selectedIndex = cmbDepartamentos.SelectedIndex;
            selectedIndex++;

         
            acceso = GUI_V_2.Properties.Settings.Default.token;
            obtenerUsuarios(acceso);
            obtenerMunicipios();
            desabilitarCampos();
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btbRegUsuarios_Click(object sender, EventArgs e)
        {

          
        }


        public async Task guardar(string acceso)
        {

            DataTable dt;
            User us = new User();
            us.nombre="Ricargo";
            us.apellido = "Rosi2harp";
            us.email = "prueba127@gmail.com";
            us.dui = "98789";
            us.sexo = 1;
            us.rol = 3;
            us.telefono = "73580618";
            us.password1 = "presupuestos012456789";

            string nombre = txtnombres.Text.Trim();
            string password = txtPassword.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string confirmarPassword = txtConfirmarContra.Text.Trim();
            string usuario = txtUsuario.Text.Trim();
            int rol = 0;
            string fecha = monthCalendar1.SelectionStart.Date.ToString("yyyy-MM-dd");
            string direccion = txtDireccion.Text.Trim();
            string nombreCompleto = apellido + "," + nombre;
            selectedIndexMunicipio = cmbMunicipios.SelectedIndex;
            Usuarios usuarioNuevo = new Usuarios();
            usuarioNuevo.Nombre = nombreCompleto;
            usuarioNuevo.Usuario = usuario;
            usuarioNuevo.Clave = confirmarPassword;
            usuarioNuevo.Telefono = telefono;
            usuarioNuevo.Fecha_nacimiento = fecha;
            usuarioNuevo.Direccion_corta = direccion;
            usuarioNuevo.Id_municipio = selectedIndexMunicipio;
            if (String.IsNullOrEmpty(nombre))
            {
                errorProvider1.SetError(txtnombres, "INGRESE EL USUARIO");
                txtnombres.Focus();
            }
            else if (String.IsNullOrEmpty(apellido))
            {
                errorProvider1.SetError(txtnombres, "");
                errorProvider1.SetError(txtApellido, "Ingrese sus apellidos");
                txtApellido.Focus();

            }
            else if (String.IsNullOrEmpty(usuario))
            {
                errorProvider1.SetError(txtApellido, "");
                errorProvider1.SetError(txtUsuario, "Ingrese su nombfd de usuario");
                txtUsuario.Focus();

            }
            else if(!rdCajero.Checked && !rbAdmin.Checked)
            {

                errorProvider1.SetError(txtUsuario, "");
                errorProvider1.SetError(groupBox2, "seleccion el rol");

            }else if (String.IsNullOrEmpty(telefono) )
            {
                errorProvider1.SetError(groupBox2, "");
                errorProvider1.SetError(txtTelefono, "Ingrese su numero de telefono");
                txtTelefono.Focus();
                

            }
            else if (String.IsNullOrEmpty(password))
            {
                errorProvider1.SetError(txtTelefono, "");
                errorProvider1.SetError(txtPassword, "Ingrese la contraseña");
                txtPassword.Focus();

            }
            else if (String.IsNullOrEmpty(confirmarPassword))
            {
                errorProvider1.SetError(txtPassword, "");
                errorProvider1.SetError(txtConfirmarContra, "repita la contraseña");
                txtConfirmarContra.Focus();

            }
            else if (password != confirmarPassword )
            {

                errorProvider1.SetError(txtPassword, "");
                MessageBox.Show("CONTRASEÑAS NO COINCIDEN");
                txtConfirmarContra.Focus();

            }
            else
            {
                if (rbAdmin.Checked)
                {
                    rol = 1;
                }
                else
                {
                    rol = 2;
                }
                usuarioNuevo.Id_rol = rol;


                if (String.IsNullOrEmpty(txtIdUsuario.Text))
                {
                    UsuariosController usuarioControlle = new UsuariosController();
                    await UsuariosController.guardar(usuarioNuevo, acceso);
                    limpiarCampos();
                }
                else
                {

                    usuarioNuevo.Id_usuario = Convert.ToInt32(txtIdUsuario.Text);
                    UsuariosController usuarioControlle = new UsuariosController();
                    await UsuariosController.modificar(usuarioNuevo, acceso);
                    limpiarCampos();

                }
                obtenerUsuarios(acceso);

            }
            

            //dtUsuairos.DataSource = dt;

        }
        public async Task obtenerDepartamentos()
        {

            DataTable dt;

            dt = (DataTable)await UsuariosController.obtenerDepartamentos();
            //cmbDepartamentos.ValueMember = "";
            //cmbDepartamentos.DisplayMember = "name";
            List<string> nombre = new List<string>(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
                nombre.Add((string)row["nombre"]);
            cmbDepartamentos.DataSource = nombre;
            

        }
        public async Task obtenerUsuarios(string token)
        {

            DataTable dt;

            UsuariosController us = new UsuariosController();
            dt = (DataTable) await UsuariosController.ObtenerDatos(token);

            dtUsuairos.DataSource = dt;

        }
        
       


        public async Task  obtenerMunicipios()
        {
             DataTable dt;
             

            dt = (DataTable)await UsuariosController.obtenerMunicipios(selectedIndex);
 
            List<string> nombre = new List<string>(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
                nombre.Add((string)row["nombre"]);
            cmbMunicipios.DataSource = nombre;

        }
        private void dtUsuairos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtnombres.Text = dtUsuairos.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtUsuario.Text = dtUsuairos.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPassword.Text = dtUsuairos.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtTelefono.Text = dtUsuairos.Rows[e.RowIndex].Cells[5].Value.ToString();
            monthCalendar1.SetDate(Convert.ToDateTime(dtUsuairos.Rows[e.RowIndex].Cells[6].Value.ToString()));
            txtDireccion.Text = dtUsuairos.Rows[e.RowIndex].Cells[7].Value.ToString();
            //txtnombres.Text = dtUsuairos.Rows[e.RowIndex].Cells[8].Value.ToString();
            int idrol = Convert.ToInt32(dtUsuairos.Rows[e.RowIndex].Cells[9].Value.ToString());
            selectedIndexMunicipio= Convert.ToInt32(dtUsuairos.Rows[e.RowIndex].Cells[8].Value.ToString());
            cmbMunicipios.SelectedIndex = selectedIndexMunicipio;

            txtIdUsuario.Text = dtUsuairos.Rows[e.RowIndex].Cells[1].Value.ToString();

            if (idrol == 1)
            {
                rbAdmin.Checked = true;


            }
            else
            {
                rdCajero.Checked = true;
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ob();
            guardar(acceso);
        }

        private void cmbDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = cmbDepartamentos.SelectedIndex;

            selectedIndex++;
            obtenerMunicipios();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            limpiarCampos();
        }
        public void limpiarCampos()
        {
            txtApellido.Text = "";
            txtConfirmarContra.Text = "";
            txtDireccion.Text = "";
            txtIdUsuario.Text = "";
            txtnombres.Text = "";
            txtPassword.Text = "";
            txtTelefono.Text = "";
            txtUsuario.Text = "";

        }
        public void desabilitarCampos()
        {
            txtApellido.Enabled = false;
            txtConfirmarContra.Enabled = false;
            txtDireccion.Enabled = false;
            txtIdUsuario.Enabled = false;
            txtnombres.Enabled = false;
            txtPassword.Enabled = false;
            txtTelefono.Enabled = false;
            txtUsuario.Enabled = false;
            rdCajero.Checked = false;
            rbAdmin.Checked = false;
                
        }
        public void habilitarCampos()
        {
            txtApellido.Enabled = !false;
            txtConfirmarContra.Enabled = !false;
            txtDireccion.Enabled = !false;
            txtIdUsuario.Enabled = !false;
            txtnombres.Enabled = !false;
            txtPassword.Enabled = !false;
            txtTelefono.Enabled = !false;
            txtUsuario.Enabled = !false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
        }
    }
}
