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
            var usuarioCtrl = new UsuarioController(new ConstSoft_agendaContext());
            var rolSistemaCtrl = new RolSistemaController(new ConstSoft_agendaContext());
            var hashingService = new HashingManagerService();
            var _loginServices = new LoginService(usuarioCtrl, rolSistemaCtrl,hashingService);
            {

                try
                {
                    string _txusername = txtbUser.Text.Trim();
                    string _txpassword = txtbPassw.Text;


                    var validate = _loginServices.ValidarCredenciales(_txusername, _txpassword);
                    if (validate != null)
                    {
                        MessageBox.Show("Inicio de sesión exitoso");

                        int validateRolSys = _loginServices.ValidarRolUsuario(validate.Id);

                        if (validateRolSys == 1000)
                        {
                            AdminView form = new AdminView();
                            this.Hide();
                            form.Show();
                            MessageBox.Show($"Bienvenido {validateRolSys}, {validate.Nombres} {validate.Apellidos}");
                        }

                        else if (validateRolSys == 1001)
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
