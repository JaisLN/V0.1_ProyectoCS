﻿using Proyecto_CS_Agenda.Controllers;
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
    public partial class AdminView : Form
    {
        public AdminView()
        {
            InitializeComponent();

            //tabGestionRol
            CargarDatosDataGridViewtab1();

            //tabGestionEmpleados(usuarios del sistema)
            cargarDatosDGVtab2();
            cargarRolesCotacto();

        }



        //tabGestionRol********************************************************************************************************************
        private void CargarDatosDataGridViewtab1()
        {
            var _rolContactoCtrl = new RolContactoController(new ConstSoft_agendaContext());
            try
            {
                var roles = _rolContactoCtrl.ObtenerTodosRolesContacto();

                dgvListSystemRol.DataSource = roles;

                // Ocultar la columna de usuarios 
                if (dgvListSystemRol.Columns.Contains("Contactos"))
                {
                    dgvListSystemRol.Columns["Contactos"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}");
            }
        }

        private void btnAddRol_Click(object sender, EventArgs e)
        {
            var _rolContactoCtrl = new RolContactoController(new ConstSoft_agendaContext());
            try
            {
                string nombreRol = txtbContactRolName.Text.Trim();
                string descripcionRol = txtbContactRolDesc.Text;
                string estadoRol = cbContactRolState.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(estadoRol))
                {
                    MessageBox.Show("Por favor, selecciona un estado para el rol.");
                    return;
                }

                // Crear un nuevo objeto RolSistema con los valores obtenidos
                RolContacto nuevoRol = new RolContacto { Nombre = nombreRol, Descripcion = descripcionRol, Estado = estadoRol };
                _rolContactoCtrl.AgregarRolContacto(nuevoRol);
                CargarDatosDataGridViewtab1();

                MessageBox.Show("Rol agregado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el rol: {ex.Message}");
            }
        }

        private void btnDeleteRol_Click(object sender, EventArgs e)
        {
            var _rolContactoCtrl = new RolContactoController(new ConstSoft_agendaContext());
            if (dgvListSystemRol.SelectedRows.Count > 0)
            {
                // Obtener el valor de la celda correspondiente al Id (asumiendo que la columna Id tiene el nombre "Id")
                int idToDelete = Convert.ToInt32(dgvListSystemRol.SelectedRows[0].Cells["Id"].Value);

                _rolContactoCtrl.EliminarRolContacto(idToDelete);
                CargarDatosDataGridViewtab1();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un rol antes de hacer clic en 'Eliminar'.");
            }
        }

        private void AbrirVentanaEdicion(RolContacto rol)
        {

            EditRolContactoView formEdicion = new EditRolContactoView(rol);
            DialogResult result = formEdicion.ShowDialog();


            if (result == DialogResult.OK)
            {
                CargarDatosDataGridViewtab1();
            }
        }

        private void btnEditRol_Click(object sender, EventArgs e)
        {
            if (dgvListSystemRol.SelectedRows.Count > 0)
            {
                // Obtener el objeto RolSistema seleccionado
                RolContacto rolSeleccionado = dgvListSystemRol.SelectedRows[0].DataBoundItem as RolContacto;

                // Verificar si se obtuvo el objeto correctamente
                if (rolSeleccionado != null)
                {
                    // Abrir la ventana de edición y pasar el objeto como parámetro
                    AbrirVentanaEdicion(rolSeleccionado);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un rol antes de hacer clic en 'Editar'.");
            }
        }





        //tabGestionEmpleados(usuarios no administradores con acceso al sistema)*************************************************************
        public void cargarDatosDGVtab2()
        {
            var _rolUsersCtrl = new UsuarioController(new ConstSoft_agendaContext());
            try
            {
                var Uroles = _rolUsersCtrl.ObtenerTodosUsuarios();

                dgvSystemUsers.DataSource = Uroles;

                // Ocultar la columna de usuarios Contact, SystemRolNavigation, Agenda
                if (dgvSystemUsers.Columns.Contains("Contact") &&
                    dgvSystemUsers.Columns.Contains("SystemRolNavigation") &&
                    dgvSystemUsers.Columns.Contains("Agenda"))
                {
                    dgvSystemUsers.Columns["Contact"].Visible = false;
                    dgvSystemUsers.Columns["SystemRolNavigation"].Visible = false;
                    dgvSystemUsers.Columns["Agenda"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos al GridView: {ex.Message}");
            }
        }

        //para precargar la lista de roles de contacto al controlador especificado
        public void cargarRolesCotacto()
        {
            var _RolesContacto = new RolContactoController(new ConstSoft_agendaContext());
            try
            {
                var cbRoles = _RolesContacto.ObtenerTodosRolesContacto();
                cbRolContacto.DataSource = cbRoles.Select(rol => rol.Nombre).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los Roles: {ex.Message}");
            }
        }

        public Contacto CrearContactoParaVincular()
        {
            var _rolContacto = new RolContactoController(new ConstSoft_agendaContext());
            var _ContactCtrl = new ContactoController(new ConstSoft_agendaContext());

            string rolContact = cbRolContacto.SelectedItem?.ToString().Trim();

            try
            {
                if (string.IsNullOrEmpty(rolContact))
                {
                    MessageBox.Show("Selecciona un rol de contacto válido.");
                    return null;
                }

                var handRol = _rolContacto.ObtenerRolContactporName(rolContact);

                if (handRol != null)
                {
                    string NombreContacto = _txtNombres.Text + " " + _txtApellidos.Text;
                    Contacto _contacto = new Contacto
                    {
                        NombreContact = NombreContacto,
                        Mail = "****",
                        Telf1 = "***",
                        Telf2 = "***",
                        Direccion = "***",
                        RolId = handRol.Id
                    };
                    _ContactCtrl.AgregarContacto(_contacto);
                    MessageBox.Show($"Creado {_contacto.Id}, {_contacto.NombreContact}");
                    return _contacto;
                }
                else
                {
                    MessageBox.Show("Error: No se encontró el rol de contacto especificado.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error general: {ex.Message}");
                return null;
            }
        }

        private void btnTab2Save_Click(object sender, EventArgs e)
        {

            var _hashing = new HashingManagerService();
            var _UserCtrl = new UsuarioController(new ConstSoft_agendaContext());
            var _rolContacto = new RolContactoController(new ConstSoft_agendaContext());

            try
            {

                int valorSeleccionado = 0;
                if (rbAdminS.Checked) { valorSeleccionado = 1000; }
                else if (rbUserS.Checked) { valorSeleccionado = 1001; }

                string cedula = _txtCedula.Text.Trim();
                string nombres = _txtNombres.Text;
                string apellidos = _txtApellidos.Text;
                string username = _txtUsername.Text.Trim();
                string password = _txtPassword.Text.Trim();

                Contacto _contactohandler = CrearContactoParaVincular();


                // Crear un usuario vinculando el Contacto previamente creado
                Usuario nuevoUser = new Usuario
                {
                    Cedula = cedula,
                    Nombres = nombres,
                    Apellidos = apellidos,
                    Username = username,
                    Password = _hashing.HashPassword(password),
                    SystemRol = valorSeleccionado,
                    ContactId = _contactohandler.Id
                };

                _UserCtrl.AgregarUsuario(nuevoUser);
                cargarDatosDGVtab2();

                MessageBox.Show("Empleado Usuario agregado exitosamente.\n" +
                                $"Vinculado el contacto {_contactohandler.Id} al usuario: \n" +
                                $"{nuevoUser.Nombres} {nuevoUser.Apellidos}");


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear al nuevo usuario: {ex.Message}");
            }
        }


        //validacion de los textbox ***********************************
        private void _txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void _txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void _txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }


        //Eliminar un Usuario
        private void btnTab2Delete_Click(object sender, EventArgs e)
        {
            var _UserCtrl = new UsuarioController(new ConstSoft_agendaContext());
            if (dgvSystemUsers.SelectedRows.Count > 0)
            {
                // Obtener el valor de la celda correspondiente al Id 
                int idToDelete = Convert.ToInt32(dgvSystemUsers.SelectedRows[0].Cells["Id"].Value);

                _UserCtrl.EliminarUsuario(idToDelete);
                cargarDatosDGVtab2();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un usuario antes de hacer clic en 'Eliminar'.");
            }
        }

        private void AbrirVentanaEditUsuario(Usuario us)
        {

            EditUsuarioView formEdicionUs = new EditUsuarioView(us);
            DialogResult result = formEdicionUs.ShowDialog();


            if (result == DialogResult.OK)
            {
                cargarDatosDGVtab2();
            }
        }


        //ir a la venata para Editar Usuario Seleccionado
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var _UserCtrl = new UsuarioController(new ConstSoft_agendaContext());

            
            if (dgvSystemUsers.SelectedRows.Count > 0)
            {
                int IdSelected = Convert.ToInt32(dgvSystemUsers.SelectedRows[0].Cells["Id"].Value);
                Usuario UserSelected = _UserCtrl.ObtenerUsuarioPorId(IdSelected);

                // Verificar si se obtuvo el objeto correctamente
                if (UserSelected != null)
                {
                    AbrirVentanaEditUsuario(UserSelected);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un rol antes de hacer clic en 'Editar'.");
            }
        }
    }
}
