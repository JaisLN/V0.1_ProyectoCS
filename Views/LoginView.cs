using Proyecto_CS_Agenda.Controllers;
using Proyecto_CS_Agenda.Models;
using Proyecto_CS_Agenda.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_CS_Agenda.Views
{
    public partial class LoginView : Form
    {
        public LoginView()
        {
            InitializeComponent();
            btnLogin.Click += btnLogin_Click;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtbUser.Text;
            string password = txtbPassw.Text;

            var usuarioController = new UsuarioController(new p1ConstSoftContext());
            var hashingService = new HashingManagerService();

            var usuario = usuarioController.ObtenerTodosUsuarios().FirstOrDefault(u => u.Username == username);

            if (usuario != null && hashingService.VerifyPassword(password, usuario.Password))
            {
                // Las credenciales son válidas, puedes realizar acciones adicionales aquí
                MessageBox.Show("Inicio de sesión exitoso");
            }
            else
            {
                // Credenciales inválidas, puedes mostrar un mensaje de error o realizar otras acciones
                MessageBox.Show("Inicio de sesión fallido. Verifica tu nombre de usuario y contraseña.");
            }

        }
    }
}
