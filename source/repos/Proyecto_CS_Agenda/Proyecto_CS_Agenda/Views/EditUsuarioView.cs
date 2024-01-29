using Guna.UI2.WinForms;
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

            lbUserId.Text = "Usuario: "+_us.Id.ToString();

            cargarRolesCotacto();
            cargarRolesSystem();

            //cargar textbox
            _txtCedula.Text = _us.Cedula;
            _txtNames.Text = _us.Nombres;
            _txtLastames.Text = _us.Apellidos;


            verificarRolContacto();
            verificarRolSystem();

            _txtUsername.Text = _us.Username.Trim();
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
                btnValidatePs.FillColor = Color.Green;
                btnValidatePs.Text = "Verificado";
            }

            else
            {
                MessageBox.Show("ERROR: Contraseña Incorrecta, intenta nuevamente");
                PssVerified = false;
            }

        }




        //Prohibido cambiar el rol de sistema Conflicto no resuelto entre las agendas,
        //el cambio implica la creacion de 2 agendas vinculadas a un mismo usuario lo que interviene en eventos como
        //ObtenerAgendaPorUsuarioID
        //asignar el rol del cb a la entidad
        /*private int setRolSytem()
        {
            var _RolSys = new RolSistemaController(new ConstSoft_agendaContext());
            string RolSysValue = _cbSystemRol.SelectedItem?.ToString().Trim();
            RolSistema FindRS = _RolSys.ObtenerRolSysPorNombre(RolSysValue);

            int IdToSet = FindRS.Id;
            return IdToSet;
        }*/


        //asignar el rol del cb a la entidad
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


        //Guardar campos de informacion legal y roles
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var _UserCtrl = new UsuarioController(new ConstSoft_agendaContext());
            setRolContat();

            String _Ci = _txtCedula.Text;
            String _Nombres = _txtNames.Text;
            String _Apellidos = _txtLastames.Text;
            String _Username = _txtUsername.Text.Trim();


            _us.Cedula = _Ci;
            _us.Nombres = _Nombres;
            _us.Apellidos = _Apellidos;

            //Prohibido cambiar el rol de sistema Conflicto no resuelto entre las agendas,
            //el cambio implica la creacion de 2 agendas vinculadas a un mismo usuario lo que interviene en eventos como
            //ObtenerAgendaPorUsuarioID
            //_us.SystemRol = setRolSytem();


            _UserCtrl.EditarUsuario(_us.Id, _us);

            /*
            //Prohibido cambiar el rol de sistema Conflicto no resuelto entre las agendas,
            //el cambio implica la creacion de 2 agendas vinculadas a un mismo usuario lo que interviene en eventos como
            //ObtenerAgendaPorUsuarioID

            //Creacion de agenda en Caso de que el Usuario tenga SystemRol Usuario
            if (_us.SystemRol == 1001)
            {
                
                var _agenda = new AgendumController(new ConstSoft_agendaContext());
                _UserCtrl.AgregarUsuario(_us);
                _agenda.AgregarAgenda(new Agendum { UserId = _us.Id });



                ///asignar los contactos golbales (de Rol Contacto 'Activo') a la agenda del usuario

                //obtener la agenda
                Agendum AgHandler = _agenda.ObtenerAgendaPorUserId(_us.Id);

                //obtener los contactos globales
                var contactoCtrl = new ContactoController(new ConstSoft_agendaContext());
                var contactosActivos = contactoCtrl.ObtenerContactosVinculadosARolActivo();

                //vincular agenda y contactos
                var agendaContactoCtrl = new AgendaContactoController(new ConstSoft_agendaContext());
                agendaContactoCtrl.VincularContactosAAgenda(AgHandler.Id, contactosActivos);
            }*/

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
              
                // Solo se edita password, Verificar si se ingresó una nueva contraseña y si las contraseñas coinciden
                if (_PsNew.Text != "" && _PsNewConfirm.Text != "" &&
                    _PsNew.Text == _PsNewConfirm.Text &&
                    _txtUsername.Text.Trim() == _us.Username.Trim())
                {
                    string stringPss = _PsNewConfirm.Text;
                    string HSstring = HashingService.HashPassword(stringPss);
                    _us.Password = HSstring;
                    _UserCtrl.EditarUsuario((int)_us.Id, _us);

                    PssVerified = false;
                    btnValidatePs.FillColor = Color.Gray;

                    MessageBox.Show("SE HA EDITADO LA CONTRASEÑA");
                }

                //Solo se ha editado el Username, verificar que los campos de nueva contrasena esten nulos
                else if (_txtUsername.Text != _us.Username && _PsNew.Text.Trim() == "" && _PsNewConfirm.Text.Trim() == "") 
                {
                    _us.Username = _txtUsername.Text;
                    _UserCtrl.EditarUsuario((int)_us.Id, _us);

                    PssVerified = false;
                    btnValidatePs.FillColor = Color.Gray;
                    btnValidatePs.Text = "Verificar";
                    MessageBox.Show("SE HA EDITADO EL USERNAME");
                }

                //Se editan ambas credenciales, verifica el valor de username es distinto y que los campos de nueva contrasena coinciden
                else if (_txtUsername.Text != _us.Username &&
                         _PsNew.Text != null && _PsNewConfirm.Text != null &&
                    _PsNew.Text.Trim() == _PsNewConfirm.Text.Trim())
                {
                    _us.Username = _txtUsername.Text;
                    string stringPss = _PsNewConfirm.Text;
                    string HSstring = HashingService.HashPassword(stringPss);
                    _us.Password = HSstring;
                    _UserCtrl.EditarUsuario((int)_us.Id, _us);

                    PssVerified = false;
                    btnValidatePs.FillColor = Color.Gray;
                    btnValidatePs.Text = "Verificar";
                    MessageBox.Show("SE HAN EDITADO AMBAS CREDENCIALES");

                }
            }
            else
            {
                MessageBox.Show("Verificar contraseña antes de realizar cualquier cambio.");
            }
        }

        //boton cancelar cambio en credenciales
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            _txtUsername.Text = _us.Username.Trim();
            _txtPsNow.Text = "";
            _PsNew.Text = "";
            _PsNewConfirm.Text = "";
        }
    }
}
