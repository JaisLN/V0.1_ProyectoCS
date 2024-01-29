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
    public partial class EditContact : Form
    {
        Contacto _ctoToEdit;
        public EditContact(Contacto _cto)
        {
            InitializeComponent();

            _ctoToEdit = _cto;

            setCtoInfo();
            cargarRoles();
        }

        private void setCtoInfo()
        {
            lbId.Text = "Contacto ID: "+ _ctoToEdit.Id;
            txtName.Text = _ctoToEdit.NombreContact;
            txtMail.Text = _ctoToEdit.Mail.Trim();
            txtTelf1.Text = _ctoToEdit.Telf1.Trim();
            txtTelf2.Text = _ctoToEdit.Telf2.Trim();
            txtAddress.Text = _ctoToEdit.Direccion;
        }

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

                cbRolcto.DataSource = rolesIn.Select(rol => rol.Nombre).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los Roles: {ex.Message}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var _ctoCtrl = new ContactoController(new ConstSoft_agendaContext());
            var _rolContacto = new RolContactoController(new ConstSoft_agendaContext());

            string _mail = txtMail.Text.Trim();
            string _namec = txtName.Text;
            string _telf = txtTelf1.Text.Trim();
            string _telf2 = txtTelf2.Text.Trim();
            string _adrress = txtAddress.Text;


            string rolContact = cbRolcto.SelectedItem?.ToString().Trim();
            var handRol = _rolContacto.ObtenerRolContactporName(rolContact);

            _ctoToEdit.NombreContact = _namec;
            _ctoToEdit.Mail = _mail;
            _ctoToEdit.Telf1 = _telf;
            _ctoToEdit.Direccion = _adrress;
            _ctoToEdit.RolId = handRol.Id;

            _ctoCtrl.EditarContacto(_ctoToEdit.Id, _ctoToEdit);

            MessageBox.Show("Cambios guardados exitosamente");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            setCtoInfo();
        }
    }
}
