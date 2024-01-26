using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_CS_Agenda.Controllers;
using Proyecto_CS_Agenda.Models;

namespace Proyecto_CS_Agenda.Views
{
    public partial class EditRolContactoView : Form
    {

        public EditRolContactoView(RolContacto _Rol)
        {
            InitializeComponent();
            var rol = _Rol;
            txtRolName.Text = rol.Nombre;
            txtRolDesc.Text = rol.Descripcion;
            lbRolID.Text = rol.Id.ToString();


            if (rol.Estado == "Activo")
            {
                cbRolState.SelectedIndex = 0;
            }

            else
            {
                cbRolState.SelectedIndex = 1;
            }

            CargarContactosVinculados(rol.Id);
        }

        private void CargarContactosVinculados(int Id)
        {
            var rolContactoCtrl = new RolContactoController(new ConstSoft_agendaContext());
            var contactosVinculados = rolContactoCtrl.ObtenerContactosVinculados(Id);

            dgvLinkedContacts.DataSource = contactosVinculados;
            if (dgvLinkedContacts.Columns.Contains("ContactoAgenda") && dgvLinkedContacts.Columns.Contains("Usuarios") && dgvLinkedContacts.Columns.Contains("Rol"))
            {
                dgvLinkedContacts.Columns["ContactoAgenda"].Visible = false;
                dgvLinkedContacts.Columns["Usuarios"].Visible = false;
                dgvLinkedContacts.Columns["Rol"].Visible = false;
            }

            lbContactsLinked.Text = $"Contactos Vinculados: {contactosVinculados.Count}";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string newName = txtRolName.Text.Trim();
                string newDesc = txtRolDesc.Text;
                string newState = cbRolState.SelectedItem?.ToString();

                // Obtener el ID del rol
                if (int.TryParse(lbRolID.Text, out int roleId))
                {
                    // Obtener el objeto RolContacto actual
                    var rolContactoCtrl = new RolContactoController(new ConstSoft_agendaContext());
                    var rolContactoActual = rolContactoCtrl.ObtenerRolContactoPorId(roleId);

                    // Verificar si se encontró el rol
                    if (rolContactoActual != null)
                    {
                        rolContactoActual.Nombre = newName;
                        rolContactoActual.Descripcion = newDesc;
                        rolContactoActual.Estado = newState;

                        rolContactoCtrl.EditarRolContacto(roleId, rolContactoActual);

                        MessageBox.Show("Cambios guardados exitosamente");
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo encontrar el rol correspondiente");
                    }
                }
                else
                {
                    MessageBox.Show("Error al obtener el ID del rol");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los cambios: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
