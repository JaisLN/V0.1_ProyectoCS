using Proyecto_CS_Agenda.Controllers;
using Proyecto_CS_Agenda.Models;
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
    public partial class UsuarioView : Form
    {
        Usuario LogedUser;
        Agendum LogedAgenda;
        public UsuarioView(Usuario User)
        {
            InitializeComponent();

            LogedUser = User;

            var agCtrl = new AgendumController(new ConstSoft_agendaContext());
            LogedAgenda = agCtrl.ObtenerAgendaPorUserId(User.Id);

            updateCtosGlobalesdelUser();

            //tab 1 info lista de contactos
            CargarLista();


            //tab2 info lista de roles disponibles
            cargarRoles();

            //tab3 Informacion
            CargarUserData();
        }





        //Tab3 Informacion del Usuario Logeado*************************************************************************************
        private void CargarUserData()
        {
            var contactCtrl = new ContactoController(new ConstSoft_agendaContext());
            var rolContactCtrl = new RolContactoController(new ConstSoft_agendaContext());

            Contacto _contact = contactCtrl.ObtenerContactoPorId((int)LogedUser.ContactId);
            RolContacto _RolC = rolContactCtrl.ObtenerRolContactoPorId(_contact.RolId);

            //inf de Usuario
            txtT3Cedula.Text = LogedUser.Cedula.Trim();
            txtT3Rolcontact.Text = _RolC.Nombre.Trim();
            txtT3Nombres.Text = LogedUser.Nombres;
            txtT3Apellidos.Text = LogedUser.Apellidos;
            txtT3Username.Text = LogedUser.Username.Trim();


            //inf de Contacto
            txtT3Mail.Text = _contact.Mail.Trim();
            txtT3Telf1.Text = _contact.Telf1.Trim();
            txtT3Telf2.Text = _contact.Telf2.Trim();
            txtT3Address.Text = _contact.Direccion;

        }


        //guardar cambios a la informacion de contacto del usuario
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var contactCtrl = new ContactoController(new ConstSoft_agendaContext());
            Contacto _contact = contactCtrl.ObtenerContactoPorId((int)LogedUser.ContactId);

            _contact.Mail = txtT3Mail.Text.Trim();
            _contact.Telf1 = txtT3Telf1.Text.Trim();
            _contact.Telf2 = txtT3Telf2.Text.Trim();
            _contact.Direccion = txtT3Address.Text;

            contactCtrl.EditarContacto(_contact.Id, _contact);

            MessageBox.Show("Se ha cambiado la Informacion de Contacto");


            CargarUserData();
            CargarLista();
        }

        private void btnT3Cancel_Click(object sender, EventArgs e)
        {
            CargarUserData();
        }


        //Editar Credenciales

        private void AbrirVentanaEdicion(Usuario user)
        {

            UsuarioEditsCredentials formEdicion = new UsuarioEditsCredentials(user);
            DialogResult result = formEdicion.ShowDialog();


            if (result == DialogResult.OK)
            {
                CargarUserData();
            }
        }
        private void btnChangeCredentials_Click(object sender, EventArgs e)
        {
            if (LogedUser != null)
            {
                AbrirVentanaEdicion(LogedUser);
            }
        }





        //Tab 1 Lista de Contactos ***************************************************************************************************************

        //actualizar Contactos globales
        private void updateCtosGlobalesdelUser()
        {

            var agCtrl = new AgendumController(new ConstSoft_agendaContext());
            ///asignar los contactos golbales (de Rol Contacto 'Activo') a la agenda del usuario

            //obtener la agenda
            Agendum AgHandler = agCtrl.ObtenerAgendaPorUserId(LogedUser.Id);

            //obtener los contactos globales
            var contactoCtrl = new ContactoController(new ConstSoft_agendaContext());
            var contactosActivos = contactoCtrl.ObtenerContactosVinculadosARolActivo();

            //vincular agenda y contactos globales
            var agendaContactoCtrl = new AgendaContactoController(new ConstSoft_agendaContext());
            agendaContactoCtrl.VincularContactosAAgenda(AgHandler.Id, contactosActivos);
        }



        //cargar lista de contactos
        private void CargarLista()
        {

            try
            {
                var agCtoCtrl = new AgendaContactoController(new ConstSoft_agendaContext());
                var rowscontactosAg = agCtoCtrl.ObtenerContactosPorAgendaId(LogedAgenda.Id);

                var _ctoCtrl = new ContactoController(new ConstSoft_agendaContext());


                var contactosVinculados = new List<Contacto>();

                foreach (ContactoAgendum ca in rowscontactosAg)
                {
                    if (ca != null)
                    {
                        Contacto senderC = _ctoCtrl.ObtenerContactoPorId((int)ca.ContactoId);
                        contactosVinculados.Add(senderC);
                    }
                }

                dgbContactosDeUsuario.DataSource = contactosVinculados;
                if (dgbContactosDeUsuario.Columns.Contains("Rol") &&
                    dgbContactosDeUsuario.Columns.Contains("ContactoAgenda") &&
                    dgbContactosDeUsuario.Columns.Contains("Usuarios"))
                {
                    dgbContactosDeUsuario.Columns["Rol"].Visible = false;
                    dgbContactosDeUsuario.Columns["ContactoAgenda"].Visible = false;
                    dgbContactosDeUsuario.Columns["Usuarios"].Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}");
            }
        }


        //eliminar un contacto de la agenda de usuario logeado
        private void btnT1Delete_Click(object sender, EventArgs e)
        {
            var _UserCtrl = new UsuarioController(new ConstSoft_agendaContext());
            var _ContactCtrl = new ContactoController(new ConstSoft_agendaContext());
            var _agenda = new AgendumController(new ConstSoft_agendaContext());


            int UserTodlt = Convert.ToInt32(dgbContactosDeUsuario.SelectedRows[0].Cells["RolId"].Value);

            if( validateCto(UserTodlt)==true)
            {
                if (dgbContactosDeUsuario.SelectedRows.Count > 0)
                {
                    // Obtener el valor de la celda correspondiente al Id 
                    int idCtoToDelete = Convert.ToInt32(dgbContactosDeUsuario.SelectedRows[0].Cells["Id"].Value);


                    var agCtoCtrl = new AgendaContactoController(new ConstSoft_agendaContext());

                    //eliminar el contacto del Usuario de otras agendas
                    agCtoCtrl.EliminarContactoAgendumPorContactoID(idCtoToDelete);

                    //eliminar el contacto del usuario
                    _ContactCtrl.EliminarContacto(idCtoToDelete);

                    MessageBox.Show("Se ha eliminado el contacto");

                }
              
            }
            else if(validateCto(UserTodlt) != true)
            {
                MessageBox.Show("IMPOSIBLE ELIMINAR UN CONTACTO VINCULADO A UN USUARIO DEL SISTEMA");
            }

            else
            {
                MessageBox.Show("Por favor, selecciona un usuario antes de hacer clic en 'Eliminar'.");
            }

            CargarLista();
        }


        //ventata Edit contacto
        private void AbrirVentanaEditContacto(Contacto cto)
        {

            EditContact formEdicionUs = new EditContact(cto);
            DialogResult result = formEdicionUs.ShowDialog();


            if (result == DialogResult.OK)
            {
                CargarLista();
            }
        }


        //Comprobar si el contacto es valido para editar
        private bool validateCto(int id)
        {
            var _RolCtrl = new RolContactoController(new ConstSoft_agendaContext());
            string isvalidate = _RolCtrl.ObtenerEstadoRol(id);
            if(isvalidate == "Inactivo")
            {
                return true;
            }

            else
            {
                return false;
                MessageBox.Show("IMPOSIBLE EDITAR LA INFORMACION DE OTRO USUARIO");
            }
        }

        private void btnT1EditarContact_Click(object sender, EventArgs e)
        {
            var _Ctrl = new ContactoController(new ConstSoft_agendaContext());


            if (dgbContactosDeUsuario.SelectedRows.Count > 0)
            {
                int IdSelected = Convert.ToInt32(dgbContactosDeUsuario.SelectedRows[0].Cells["Id"].Value);
                Contacto ctoSelected = _Ctrl.ObtenerContactoPorId(IdSelected);

                // Verificar si se obtuvo el objeto correctamente
                if (ctoSelected != null && validateCto(ctoSelected.RolId) == true)
                {
                    AbrirVentanaEditContacto(ctoSelected);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un rol antes de hacer clic en 'Editar'.");
            }
        }




        //tab 2 Agregar contacto*************************************************************************************


        //cargar los roles no globales  o de estado inactivo
        private void cargarRoles()
        {
            var _RolesContacto = new RolContactoController(new ConstSoft_agendaContext());
            try
            {
                var cbRoles = _RolesContacto.ObtenerTodosRolesContacto();

                var rolesIn = new List<RolContacto>();
                foreach (RolContacto rc in cbRoles)
                {
                    if (_RolesContacto.ObtenerEstadoRol(rc.Id) == "Inactivo")
                    {
                        rolesIn.Add(rc);
                    }

                }

                cbT2LinkRol.DataSource = rolesIn.Select(rol => rol.Nombre).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los Roles: {ex.Message}");
            }
        }

        private void btnT2AddCto_Click(object sender, EventArgs e)
        {
            var _agCtoCtrl = new AgendaContactoController(new ConstSoft_agendaContext());
            var _rolContacto = new RolContactoController(new ConstSoft_agendaContext());
            string rolContact = cbT2LinkRol.SelectedItem?.ToString().Trim();
            var ctoCtrl = new ContactoController(new ConstSoft_agendaContext());

            try
            {

                string _mail = txtT2Mail.Text.Trim();
                string _namec = txtT2NameCto.Text.Trim();
                string _telf = txtT2Telf.Text.Trim();
                string _telf2 = txtT2Telf2.Text.Trim();
                string _adrress = txtT2Address.Text;

                var handRol = _rolContacto.ObtenerRolContactporName(rolContact);
                Contacto _cto = new Contacto
                {

                    NombreContact = _namec,
                    Mail = _mail,
                    Telf1 = _telf,
                    Telf2 = _telf2,
                    Direccion = _adrress,
                    RolId = handRol.Id
                };

                ctoCtrl.AgregarContacto(_cto);

                ContactoAgendum _ca = new ContactoAgendum
                {
                    ContactoId = _cto.Id,
                    AgendaId = LogedAgenda.Id
                };

                _agCtoCtrl.AgregarContactoAgenda(_ca);

            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error general: {ex.Message}");

            }
            CargarLista();
            vaciarcampos();
            MessageBox.Show("Contacto agregado a su agenda");
        }


        private void vaciarcampos()
        {
            txtT2Mail.Text = "";
            txtT2NameCto.Text = "";
            txtT2Telf.Text = "";
            txtT2Telf2.Text = "";
            txtT2Address.Text = "";
        }

        private void btnT2Cancel_Click(object sender, EventArgs e)
        {
            vaciarcampos();
        }


    }
}
