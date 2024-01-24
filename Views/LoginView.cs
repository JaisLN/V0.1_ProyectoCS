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
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var usuarioCtrl = new UsuarioController(new p1ConstSoftContext());
            var rolSistemaCtrl = new RolSistemaController(new p1ConstSoftContext());
            var hashingService = new HashingManagerService();
            var _loginServices = new LoginServices(usuarioCtrl, rolSistemaCtrl,hashingService);
            {
                try
                {
                    string username = txtbUser.Text;
                    string password = txtbPassw.Text;

                    var validate = _loginServices.ValidarCredenciales(username, password);

                    if (validate != null)
                    {
                        MessageBox.Show("Inicio de sesión exitoso");

                        string validateRolSys = _loginServices.ValidarRolUsuario(validate.Id);

                        if (validateRolSys == "Admin")
                        {
                            AdminView form = new AdminView();
                            this.Hide();
                            form.Show();
                            MessageBox.Show($"Bienvenido {validateRolSys}, {validate.Nombres} {validate.Apellidos}");
                        }

                        else if (validateRolSys == "Usuario")
                        {
                            MessageBox.Show($"Bienvenido {validateRolSys}, {validate.Nombres} {validate.Apellidos}");
                        }


                        else
                        {
                            MessageBox.Show($"Valor inesperado de validateRolSys: {validateRolSys}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Inicio de sesión fallido. Verifica tu nombre de usuario y contraseña.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}
