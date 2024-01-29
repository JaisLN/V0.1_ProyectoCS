using Proyecto_CS_Agenda.Models;
using Proyecto_CS_Agenda.Services;
using Proyecto_CS_Agenda.Controllers;
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
    public partial class UsuarioEditsCredentials : Form
    {
        Usuario LogedUser;
        private bool PssVerified;
        public UsuarioEditsCredentials(Usuario user)
        {
            InitializeComponent();
            LogedUser = user;

            lbUserID.Text = "Usuario ID: " + LogedUser.Id;
            _txtUsername.Text = LogedUser.Username.Trim();

        }

        private void btnValidatePs_Click(object sender, EventArgs e)
        {
            var validate = new HashingManagerService();

            string hashedPss = LogedUser.Password;
            if (validate.VerifyPassword(_txtPsNow.Text, hashedPss))
            {
                MessageBox.Show("Contraseña Correcta");
                PssVerified = true;
                btnValidatePs.FillColor = Color.Green;
                btnValidatePs.Text = "Verificado";
            }

            else
            {
                MessageBox.Show("ERROR: Contraseña Incorrecta, intenta nuevamente");
                PssVerified = false;
            }
        }

        private void btnDoChanges_Click(object sender, EventArgs e)
        {
            var _UserCtrl = new UsuarioController(new ConstSoft_agendaContext());
            var HashingService = new HashingManagerService();

            if (PssVerified == true)
            {

                // Solo se edita password, Verificar si se ingresó una nueva contraseña y si las contraseñas coinciden
                if (_PsNew.Text != "" && _PsNewConfirm.Text != "" &&
                    _PsNew.Text == _PsNewConfirm.Text &&
                    _txtUsername.Text.Trim() == LogedUser.Username.Trim())
                {
                    string stringPss = _PsNewConfirm.Text;
                    string HSstring = HashingService.HashPassword(stringPss);
                    LogedUser.Password = HSstring;
                    _UserCtrl.EditarUsuario((int)LogedUser.Id, LogedUser);

                    PssVerified = false;
                    btnValidatePs.FillColor = Color.Gray;

                    MessageBox.Show("SE HA EDITADO LA CONTRASEÑA");
                }

                //Solo se ha editado el Username, verificar que los campos de nueva contrasena esten nulos
                else if (_txtUsername.Text != LogedUser.Username && _PsNew.Text.Trim() == "" && _PsNewConfirm.Text.Trim() == "")
                {
                    LogedUser.Username = _txtUsername.Text;
                    _UserCtrl.EditarUsuario((int)LogedUser.Id, LogedUser);

                    PssVerified = false;
                    btnValidatePs.FillColor = Color.Gray;
                    btnValidatePs.Text = "Verificar";
                    MessageBox.Show("SE HA EDITADO EL USERNAME");
                }

                //Se editan ambas credenciales, verifica el valor de username es distinto y que los campos de nueva contrasena coinciden
                else if (_txtUsername.Text != LogedUser.Username &&
                         _PsNew.Text != null && _PsNewConfirm.Text != null &&
                    _PsNew.Text.Trim() == _PsNewConfirm.Text.Trim())
                {
                    LogedUser.Username = _txtUsername.Text;
                    string stringPss = _PsNewConfirm.Text;
                    string HSstring = HashingService.HashPassword(stringPss);
                    LogedUser.Password = HSstring;
                    _UserCtrl.EditarUsuario((int)LogedUser.Id, LogedUser);

                    PssVerified = false;
                    btnValidatePs.FillColor = Color.Gray;
                    btnValidatePs.Text = "Verificar";
                    MessageBox.Show("SE HAN EDITADO AMBAS CREDENCIALES");

                }
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Verificar contraseña antes de realizar cualquier cambio.");
            }
        }

        private void btnCancelChanges_Click(object sender, EventArgs e)
        {
            _txtUsername.Text = LogedUser.Username.Trim();
            _txtPsNow.Text = "";
            _PsNew.Text = "";
            _PsNewConfirm.Text = "";
        }
    }
}
