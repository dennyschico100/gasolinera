using Gasolinera.Modelo;
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
using GUI_V_2.Modelo;
using GUI_V_2.controladores;

namespace Gasolinera.vistas
{
    public partial class loginFrm : Form
    {
        public loginFrm()
        {
            InitializeComponent();
        }

        private void textBox2_ParentChanged(object sender, EventArgs e)
        {

        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {

            iniciarSessionAsync();
            
        }
        public async Task iniciarSessionAsync()
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (String.IsNullOrEmpty(usuario))
            {
                errorProvider1.SetError(txtUsuario, "INGRESE EL USUARIO");
                txtUsuario.Focus();
            }
            else if (String.IsNullOrEmpty(password))
            {
                errorProvider1.SetError(txtUsuario, "");
                errorProvider1.SetError(txtPassword, "Ingrese una contraseña");
                txtPassword.Focus();
            }
            else
            {

                Login login = new Login();
                login.Email = usuario;
                login.Password = password;
                bool res = await LoginController.login(login);

                if (res)
                {
                    this.Hide();

                }
                else
                {

                    MessageBox.Show("Credenciales incorrectas", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }
        private void btnIniciar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
