using Microsoft.EntityFrameworkCore;
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
    public partial class EditUsuarioView : Form
    {
        private Usuario _us;
        private bool PssVerified;

        public EditUsuarioView(Usuario us)
        {
            InitializeComponent();
            _us = us;

            lbUserId.Text = _us.Id.ToString();

            cargarRolesCotacto();
            cargarRolesSystem();

            //cargar textbox
            _txtCedula.Text = _us.Cedula;
            _txtNames.Text = _us.Nombres;
            _txtLastames.Text = _us.Apellidos;


            verificarRolContacto();
            verificarRolSystem();

            _txtUsername.Text = _us.Username;
        }


        //cargar combobox's general data
        public void cargarRolesCotacto()
        {
            var _RolesContacto = new RolContactoController(new ConstSoft_agendaContext());
            try
            {
                var cbRoles = _RolesContacto.ObtenerTodosRolesContacto();
                _cbContactRol.DataSource = cbRoles.Select(rol => rol.Nombre).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los Roles: {ex.Message}");
            }
        }

        public void cargarRolesSystem()
        {
            var _RolesSystem = new RolSistemaController(new ConstSoft_agendaContext());
            try
            {
                var cbRoles = _RolesSystem.ObtenerTodosRoles();
                _cbSystemRol.DataSource = cbRoles.Select(rol => rol.Name).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los Roles: {ex.Message}");
            }
        }




        //cargar combobox's usaer data
        public void verificarRolContacto()
        {
            int idLinked = (int)_us.ContactId;
            var _Contacto = new ContactoController(new ConstSoft_agendaContext());
            Contacto handlerC = _Contacto.ObtenerContactoPorId(idLinked);

            if (handlerC != null)
            {
                int rolId = handlerC.RolId;
                var _Rol = new RolContactoController(new ConstSoft_agendaContext());
                RolContacto handlerRc = _Rol.ObtenerRolContactoPorId(rolId);

                int index = _cbContactRol.FindStringExact(handlerRc.Nombre.ToString());
                _cbContactRol.SelectedIndex = index;
            }

        }

        public void verificarRolSystem()
        {
            int idLinked = (int)_us.SystemRol;
            var _RolSys = new RolSistemaController(new ConstSoft_agendaContext());
            RolSistema handlerRS = _RolSys.ObtenerRolPorId(idLinked);

            if (handlerRS != null)
            {
                int index = _cbSystemRol.FindStringExact(handlerRS.Name.ToString());
                _cbSystemRol.SelectedIndex = index;
            }

        }

        //Boton verificar contrasena
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            var validate = new HashingManagerService();

            string hashedPss = _us.Password;
            if (validate.VerifyPassword(_txtPsNow.Text, hashedPss))
            {
                MessageBox.Show("Contraseña Correcta");
                PssVerified = true;
            }

            else
            {
                MessageBox.Show("ERROR: Contraseña Incorrecta, intenta nuevamente");
                PssVerified = false;
            }

        }



        //Guardar Rol Systema
        private int setRolSytem()
        {
            var _RolSys = new RolSistemaController(new ConstSoft_agendaContext());
            string RolSysValue = _cbSystemRol.SelectedItem?.ToString().Trim();
            RolSistema FindRS = _RolSys.ObtenerRolSysPorNombre(RolSysValue);

            int IdToSet = FindRS.Id;
            return IdToSet;
        }

        private void setRolContat()
        {
            var _RolContactCtrl = new RolContactoController(new ConstSoft_agendaContext());
            string RolContactValue = _cbContactRol.SelectedItem?.ToString().Trim();
            RolContacto FindRC = _RolContactCtrl.ObtenerRolContactporName(RolContactValue);

            int IdToSetToContact = FindRC.Id;


            var _contactCtrl = new ContactoController(new ConstSoft_agendaContext());
            Contacto Chandler = _contactCtrl.ObtenerContactoPorId((int)_us.ContactId);

            Chandler.RolId = IdToSetToContact;
            _contactCtrl.EditarContacto((int)_us.ContactId, Chandler);
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var _UserCtrl = new UsuarioController(new ConstSoft_agendaContext());

            String _Ci = _txtCedula.Text;
            String _Nombres = _txtNames.Text;
            String _Apellidos = _txtLastames.Text;
            String _Username = _txtUsername.Text.Trim();


            _us.Cedula = _Ci;
            _us.Nombres = _Nombres;
            _us.Apellidos = _Apellidos;
            _us.SystemRol = setRolSytem();

            _UserCtrl.EditarUsuario(_us.Id, _us);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }


        //Editar Credenciales
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            var _UserCtrl = new UsuarioController(new ConstSoft_agendaContext());
            var HashingService = new HashingManagerService();

            if (PssVerified == true)
            {
                _us.Username = _txtUsername.Text.Trim();

                // Verificar si se ingresó una nueva contraseña y si las contraseñas coinciden
                if (_PsNew != null && _PsNewConfirm != null &&
                    !string.IsNullOrEmpty(_PsNew.Text.Trim()) &&
                    _PsNew.Text.Trim() == _PsNewConfirm.Text.Trim())
                {
                    // Hashear y actualizar la nueva contraseña
                    _us.Password = HashingService.HashPassword(_PsNewConfirm.Text);
                }

                // Editar el usuario solo si se ha cambiado la contraseña o el nombre de usuario
                if (!string.IsNullOrEmpty(_PsNew.Text.Trim()) || _us.Username != _txtUsername.Text.Trim())
                {
                    _UserCtrl.EditarUsuario((int)_us.Id, _us);
                    MessageBox.Show("SE HAN EDITADO LAS CREDENCIALES");
                }
                else
                {
                    MessageBox.Show("No se realizaron cambios en las credenciales.");
                }
            }
            else
            {
                MessageBox.Show("No ha verificado la contraseña.");
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            _txtUsername.Text = _us.Username.Trim();
            _txtPsNow.Text = "";
            _PsNew.Text = "";
            _PsNewConfirm.Text = "";
        }
    }
}
